using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ds
{
    public class read_message
    {
        public void DecryptAll(string message)
        {
            var Split = message.Split(".");
            byte[] user = { }, iv = { }, key = { }, Emessage = { };
            user = Convert.FromBase64String(Split[0]);
            iv = Convert.FromBase64String(Split[1]);
            key = Convert.FromBase64String(Split[2]);
            Emessage = Convert.FromBase64String(Split[3]);
            string username = Encoding.UTF8.GetString(user);

            byte[] decryptedkey = KeyDecryption(key, username, true);
            string mesazhi = Decrypt(Emessage, iv, decryptedkey);
            Console.WriteLine("Marresi: " + username);
            Console.WriteLine("Mesazhi: " + mesazhi);

            if (Split.Length > 4)
            {
                byte[] sender = { }, nenshkrimi = { };
                sender = Convert.FromBase64String(Split[4]);
                nenshkrimi = Convert.FromBase64String(Split[5]);
                bool valid = verifikim(Encoding.UTF8.GetString(sender), Emessage, nenshkrimi);
                Console.WriteLine("Derguesi: " + Encoding.UTF8.GetString(sender));
                Console.WriteLine(valid ? "Nenshkrimi: valid" : "Nenshkrimi: Mungon celsi publik i derguesit");
            }
        }

        private static byte[] KeyDecryption(byte[] Data, string RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string getRSA = File.ReadAllText("../../../../keys/" + RSAKey + ".xml");
                    RSA.FromXmlString(getRSA);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }

                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private static string Decrypt(byte[] encryptedMessage, byte[] iv, byte[] key)
        {
            // Set encryption settings -- Use password for both key and init. vector
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            provider.Mode = CipherMode.CBC;
            provider.Key = key;
            provider.IV = iv;
            provider.Padding = PaddingMode.ISO10126;


            ICryptoTransform transform = provider.CreateDecryptor();
            CryptoStreamMode mode = CryptoStreamMode.Write;


            // Set up streams and decrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
            cryptoStream.FlushFinalBlock();

            // Read decrypted message from memory stream
            byte[] decryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);

            // Encode deencrypted binary data to base64 string
            string message = Encoding.UTF8.GetString(decryptedMessageBytes);

            return message;
        }

        
        // Verifikojme nenshkrimin me qelsin publik te derguesit
        private bool verifikim(string sender, byte[] desmesazhi, byte[] nenshkrimi)
        {
            RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
            if (!File.Exists("../../../../keys/" + sender + ".pub.xml"))
                return false;
            string getRSA = File.ReadAllText("../../../../keys/" + sender + ".pub.xml");
            objRSA.FromXmlString(getRSA);
            bool verified = objRSA.VerifyData(desmesazhi, new SHA1CryptoServiceProvider(), nenshkrimi);
            if (verified)
                return true;
            else
                return false;
        }
    }
}