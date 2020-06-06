using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ds
{
    public class write_message
    {
        UTF8Encoding e = new UTF8Encoding();

        public void EncryptALL(string RSAuser, string message, string token = null)
        {
            byte[] userbytes = e.GetBytes(RSAuser);

            byte[] iv = new byte[8];
            byte[] key = new byte[8];
            Random r = new Random();
            r.NextBytes(iv);
            r.NextBytes(key);
            string Writebytes = Convert.ToBase64String(userbytes);
            byte[] encryptedkey = Encryption(key, RSAuser, true);
            string EncryptMessageDES = EncryptDES(message, iv, key);

            string getivbyte = Convert.ToBase64String(iv);

            string getkeybyte = Convert.ToBase64String(encryptedkey);

            if (token == null)
            {
                Console.WriteLine(Writebytes + "." + getivbyte + "." + getkeybyte + "." + EncryptMessageDES);
            }
            else
            {
                byte[] sender = JWTStatus(token);
                string senderS = Convert.ToBase64String(sender);

                string digitalsignature = nenshkruajTxt(EncryptMessageDES, e.GetString(sender));
                Console.WriteLine(Writebytes + "." + getivbyte + "." + getkeybyte + "." + EncryptMessageDES + "." +
                                  senderS + "." + digitalsignature);
            }
        }

        private static byte[] Encryption(byte[] Data, string RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string getRSA = File.ReadAllText("../../../../keys/" + RSAKey + ".xml");
                    RSA.FromXmlString(getRSA);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }

                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static string EncryptDES(string message, byte[] iv, byte[] key)
        {
            // Encode message and password
            byte[] messageBytes = ASCIIEncoding.ASCII.GetBytes(message);


            // Set encryption settings -- Use password for both key and init. vector
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            provider.Mode = CipherMode.CBC;
            provider.Key = key;
            provider.IV = iv;
            provider.Padding = PaddingMode.ISO10126;


            ICryptoTransform transform = provider.CreateEncryptor();
            CryptoStreamMode mode = CryptoStreamMode.Write;


            // Set up streams and encrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read the encrypted message from the memory stream
            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            // Encode the encrypted message as base64 string
            string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);

            return encryptedMessage;
        }

        JWT_token dt = new JWT_token();

        
        // Nese tokeni nuk eshte valid komanda deshton
        public byte[] JWTStatus(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken T = handler.ReadJwtToken(token);
            DateTimeOffset DT = dt.GetExpiry(token);
            IEnumerable<Claim> GetUser = T.Claims;
            String sender = GetUser.FirstOrDefault(user => user.Type.ToString().Equals("name")).Value;

            if (DT < DateTimeOffset.Now || !File.Exists("../../../../keys/" + sender + ".pub.xml") || !dt.VerifyJWT_RS256_Signature(token, sender, out string error))
            {
                throw new Exception("Tokeni nuk eshte valid!");
            }

            return e.GetBytes(sender);
        }


        // Nenshkruajme des mesazhin me RSA qelsin privat te dergusit
        private string nenshkruajTxt(string message, string sender)
        {
            RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
            byte[] bytePlainText = Convert.FromBase64String(message);

            string getRSA = File.ReadAllText("../../../../keys/" + sender + ".xml");
            objRSA.FromXmlString(getRSA);

            byte[] byteSignedText = objRSA.SignData(bytePlainText, new SHA1CryptoServiceProvider());

            return Convert.ToBase64String(byteSignedText);
        }
    }
}