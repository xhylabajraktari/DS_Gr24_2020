using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;


namespace ds
{
    public class KrijoUser
    {
      
        public void Insert_Pass(string userpath, string password)  
        {  
            //Hash Password  
            
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            try  
            {  
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                
                //Te database ja jep databazen qe e ke kriju ti edhe te password ja jep passworidn e localhost
                // nMunet qe local host mos me pas password e len zbrazet
                string MyConnection2 = "datasource=localhost;database=keys;username=root;password=;CharSet=utf8";
                
                 
                String Query = "INSERT INTO users VALUES" + "('" + userpath + "','" + savedPasswordHash + "')";               
               
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
               
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                MySqlDataReader MyReader2;  
                MyConn2.Open();  
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader2.Read())  
                {                     
                }  
                MyConn2.Close();  
                Console.WriteLine("Eshte krijuar shfrytezuesi " + userpath);
            }  
            catch (Exception ex)  
            {   
                throw new Exception(ex.Message);  
            }  
        }
        
        public void user(string filepath)
        {
            if (!System.IO.File.Exists("../../../../keys//" + filepath + ".xml")) {

                // Generate a public/private key using RSA  
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
                // Read  private key in a string  

                string Pstr = RSA.ToXmlString(true);
                    
                // Save Private key
                System.IO.File.WriteAllText("../../../../keys//" + filepath + ".xml", Pstr);
                   


                // Get key into public parameters  
                string RsaPublic = RSA.ToXmlString(false);

                System.IO.File.WriteAllText("../../../../keys//" + filepath + ".pub.xml", RsaPublic);

                Console.WriteLine("Qelsi publik " + filepath + " u ruajt ne dir keys");
                Console.WriteLine("Qelsi privat " + filepath + " u ruajt ne dir keys");
            }
            else {
                Console.WriteLine("Celsi " + filepath + " ekziston");
            }
        }
        
    }
}