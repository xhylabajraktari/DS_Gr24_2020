using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;


namespace ds
{
    public class JWT_token
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        public void generateToken(string user)
        {
            RSACryptoServiceProvider rsakey = new RSACryptoServiceProvider();
            string getRSA = File.ReadAllText("../../../../keys/" + user + ".xml");
            rsakey.FromXmlString(getRSA);
            rsakey.ExportRSAPrivateKey();

            // Create Security key using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            //var securityKey = new SymmetricSecurityKey(key);
            var securityKey = new RsaSecurityKey(rsakey);

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new SigningCredentials
                (securityKey, SecurityAlgorithms.RsaSha256);

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
            {
                {"exp: ", DateTimeOffset.UtcNow.AddMinutes(20).ToUnixTimeSeconds()},
                {"name", user}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            Console.WriteLine("Token: " + tokenString);
        }

        public void Login(string user, string password)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;database=keys;username=root;password=;CharSet=utf8";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MyConn2.Open();
                string query = "select * from shfrytezuesit where perdoruesi ='" + user + "'"; 
                MySqlDataReader ex;
                MySqlCommand cmd = new MySqlCommand(query, MyConn2);  
                ex = cmd.ExecuteReader();
                if (ex.HasRows)
                {
                    if (ex.Read())
                    {
                        string dbPassword = ex["password"].ToString();
                        string dbSalt = ex["salt"].ToString();

                        string SaltPassword = dbSalt + password;
                        byte[] byteSaltPw = Encoding.UTF8.GetBytes(SaltPassword);

                        byte[] byteHashSaltPw = (new SHA1CryptoServiceProvider().ComputeHash(byteSaltPw));
                        string SaltedHashPassword = Convert.ToBase64String(byteHashSaltPw);

                        if (dbPassword == SaltedHashPassword)
                        {
                            generateToken(user);
                        }
                        else
                            Console.WriteLine("Fjalekalimi/Shfrytezuesi i gabuar!");
                    }
                }
                else
                {
                    Console.WriteLine("Fjalekalimi/Shfrytezuesi i gabuar!", "Information");
                }
            }
            catch
            {
                Console.WriteLine("Connection Error", "Information");
            }
        }

        public bool status(string JWTtoken)
        {
            JwtSecurityToken token = handler.ReadJwtToken(JWTtoken);

            IEnumerable<Claim> GetUser = token.Claims;
            String nameClaim = GetUser.FirstOrDefault(user => user.Type.ToString().Equals("name")).Value;
            DateTimeOffset DT = GetExpiry(JWTtoken);

            Console.WriteLine("User: " + nameClaim);
            Console.WriteLine("Skadimi: " + DT.LocalDateTime);
            if (DT < DateTimeOffset.Now)
            {
                return false;
            }

            if (!File.Exists("../../../../keys/" + nameClaim + ".pub.xml"))
            {
                return false;
            }

            if (!VerifyJWT_RS256_Signature(JWTtoken, nameClaim, out string error))
            {
                Console.WriteLine(error);
                return false;
            }

            return true;
        }

        // Marrim daten e skadimit te tokenit nga UNIX_time
        public DateTimeOffset GetExpiry(string tokenString)
        {
            var token = handler.ReadJwtToken(tokenString);

            var Datetime = token.Payload.First().Value;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Datetime.GetHashCode());
            return dateTimeOffset;
        }


        // Verifikojme nenshkrimi e tokenit me qelsin publik te shfrytezuesit
        public bool VerifyJWT_RS256_Signature(string jwt, string publik, out string errorMessage)
        {
            string publicKey = "";
            string exponent = "";

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../keys/" + publik + ".pub.xml");

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("Modulus");
            for (int i = 0; i < elemList.Count; i++)
            {
                publicKey = elemList[i].InnerXml;
            }

            XmlNodeList elemListt = doc.GetElementsByTagName("Exponent");
            for (int i = 0; i < elemList.Count; i++)
            {
                exponent = elemListt[i].InnerXml;
            }


            if (string.IsNullOrEmpty(jwt))
            {
                errorMessage = "Error verifying JWT token signature: Javascript Web Token was null or empty.";
                return false;
            }

            var jwtArray = jwt.Split('.');
            if (string.IsNullOrEmpty(publicKey))
            {
                errorMessage =
                    "Error verifying JWT token signature: Well known RSA Public Key modulus was null or empty.";
                return false;
            }

            if (string.IsNullOrEmpty(exponent))
            {
                errorMessage =
                    "Error verifying JWT token signature: Well known RSA Public Key exponent was null or empty.";
                return false;
            }

            try
            {
                string publicKeyFixed =
                    (publicKey.Length % 4 == 0 ? publicKey : publicKey + "====".Substring(publicKey.Length % 4))
                    .Replace("_", "/").Replace("-", "+");
                var publicKeyBytes = Convert.FromBase64String(publicKeyFixed);

                var jwtSignatureFixed =
                    (jwtArray[2].Length % 4 == 0 ? jwtArray[2] : jwtArray[2] + "====".Substring(jwtArray[2].Length % 4))
                    .Replace("_", "/").Replace("-", "+");
                var jwtSignatureBytes = Convert.FromBase64String(jwtSignatureFixed);

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(
                    new RSAParameters()
                    {
                        Modulus = publicKeyBytes,
                        Exponent = Convert.FromBase64String(exponent)
                    }
                );

                SHA256 sha256 = SHA256.Create();
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(jwtArray[0] + '.' + jwtArray[1]));

                RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");
                if (!rsaDeformatter.VerifySignature(hash, jwtSignatureBytes))
                {
                    errorMessage = "Error verifying JWT token signature: hash did not match expected value.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error verifying JWT token signature: " + ex.Message;
                return false;
                //throw ex;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}