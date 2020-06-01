using System;
using System.Text;
using MySql.Data.MySqlClient;

namespace ds
{
    public class FshiUser
    {
        public void delete(string user)
        {

            if (System.IO.File.Exists("../../../../keys/" + user + ".xml") &&
                System.IO.File.Exists("../../../../keys/" + user + ".pub.xml"))
            {

                System.IO.File.Delete("../../../../keys/" + user + ".pub.xml");
                System.IO.File.Delete("../../../../keys/" + user + ".xml");

                Console.WriteLine("Qelsi publik " + user + " u fshi nga dir keys");
                Console.WriteLine("Qelsi privat " + user + " u fshi nga dir keys");
                DatabaseDelete(user);
            }
            else if (!System.IO.File.Exists("../../../../keys/" + user + ".xml") &&
                     System.IO.File.Exists("../../../../keys/" + user + ".pub.xml"))
            {

                System.IO.File.Delete("../../../../keys/" + user + ".pub.xml");
                Console.WriteLine("Qelsi publik " + user + " u fshi nga dir keys");
                DatabaseDelete(user);
                
            }
            else
            {
                Console.WriteLine("Celsi " + user + " nuk ekziston");
            }
        }
        
        private void DatabaseDelete(string userpath)
        {
           
            try
            {
                
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                
               
                //Te database ja jep databazen qe e ke kriju ti edhe te password ja jep passworidn e localhost
                // nMunet qe local host mos me pas password e len zbrazet
                string MyConnection2 = "datasource=localhost;database=keys;username=root;password=;CharSet=utf8";
                
                String Query = "DELETE FROM users WHERE USER=" + "'" + userpath + "';";  
                            
               
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
               
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                MySqlDataReader MyReader2;  
                MyConn2.Open();  
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader2.Read())  
                {                     
                }  
                MyConn2.Close();  
                Console.WriteLine("Eshte fshire shfrytezuesi " + userpath);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}