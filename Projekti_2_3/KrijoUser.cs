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
            
            int RandomSalt = new Random().Next(100000, 1000000);
            string salt = RandomSalt.ToString();
           
            SHA1CryptoServiceProvider objHash = new SHA1CryptoServiceProvider();
            string saltPassword = salt + password;
            byte[] byteSaltPassword = Encoding.UTF8.GetBytes(saltPassword);
            byte[] byteHashSaltedPassword = objHash.ComputeHash(byteSaltPassword);

            string savedPasswordHash = Convert.ToBase64String(byteHashSaltedPassword);
            string savedSaltHash = salt;


            try  
            {
                //Te database ja jep databazen qe e ke kriju ti edhe te password ja jep passworidn e localhost
                // Munet qe local host mos me pas password e len zbrazet
                string MyConnection2 = "datasource=localhost;database=keys;username=root;password=;CharSet=utf8";

                String Query = "INSERT INTO shfrytezuesit VALUES" + "('" + userpath + "','" + savedPasswordHash + "','" + savedSaltHash + "')";               
               
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
               
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                MySqlDataReader MyReader2; 
              
                MyConn2.Open();  
                user(userpath);
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
                throw new Exception("Celsi " + filepath + " ekziston");
            }
        }
        
    }
}