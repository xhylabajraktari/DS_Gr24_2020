using System;
using System.Security.Cryptography;
using System.Xml;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {
            KrijoUser U = new KrijoUser();
            FshiUser F = new FshiUser();

            if (args.Length == 0)
            {
                Console.WriteLine("Miresevini te Siguria!");
                Console.WriteLine("Per te ekzekutuar komanden create user shtyp : ds create-user <name>");
                Console.WriteLine("Per te ekzekutuar komanden delete user shtyp : ds delete-user <name>");
                Console.WriteLine("Per te ekzekutuar komanden eport key  shtyp  : ds export-key <public|private><name>[path]");
                Console.WriteLine("Per te ekzekutuar komanden import key shtyp  : ds import-key <name><path>");
                Environment.Exit(1);
            }


            if (args[0] == "create-user")
            {
                try
                {
                    string user = args[1];

                    Console.Write("Jepni fjalekalimin: ");
                    string password = Console.ReadLine();
                    Console.Write("Perserit fjalekalimin: ");


                    string perserit_password = Console.ReadLine();

                    if (password == perserit_password)
                    {
                        U.user(user);
                        U.Insert_Pass(user, password);
                    }
                    else
                    {
                        throw new Exception("Fjalekalimet nuk perputhen!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (args[0] == "delete-user")
            {
                try
                {
                    string user = args[1];
                    F.delete(user);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            if (args[0] == "export-key")
            {
                if (args[1] == "public")
                {
                    if (System.IO.File.Exists("../../../../keys/" + args[2] + ".pub.xml"))
                    {
                        System.IO.StreamReader export =
                            new System.IO.StreamReader("../../../../keys/" + args[2] + ".pub.xml");


                        String exportedKey = export.ReadToEnd();
                        if (args.Length < 4)
                        {
                            Console.WriteLine(exportedKey);
                        }
                        else
                        {
                            System.IO.File.WriteAllText(args[3], exportedKey);
                            Console.WriteLine("Celsi publik u ruajt ne file " + args[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Celsi publik " + args[2] + " nuk ekziston!");
                    }
                }
                else if (args[1] == "private")
                {
                    if (System.IO.File.Exists("../../../../keys/" + args[2] + ".xml"))
                    {
                        System.IO.StreamReader export =
                            new System.IO.StreamReader("../../../../keys/" + args[2] + ".xml");

                        String exportedKey = export.ReadToEnd();
                        if (args.Length < 4)
                        {
                            Console.WriteLine(exportedKey);
                        }
                        else
                        {
                            System.IO.File.WriteAllText(args[3], exportedKey);
                            Console.WriteLine("Celsi privat u ruajt ne file " + args[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Celsi privat " + args[2] + " nuk ekziston!");
                    }
                }
            }
            if (args[0] == "import-key")
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
                try
                {
                    string importedkey = System.IO.File.ReadAllText(args[2]);
                    //import.Close();
                    RSA.FromXmlString(importedkey);


                    if (!System.IO.File.Exists("../../../../keys/" + args[1] + ".pub.xml"))
                    {
                        // Private/Public check?
                        string publicKey = new string(importedkey);
                        bool Private = publicKey.Contains("Q");
                        if (Private)
                        {
                            System.IO.File.WriteAllText("../../../../keys/" + args[1] + ".xml", importedkey);
                            Console.WriteLine("Celsi privat " + args[1] + " u ruajt ne dir keys");

                            string RSAPublic = RSA.ToXmlString(false);


                            System.IO.File.WriteAllText("../../../../keys/" + args[1] + ".pub.xml", RSAPublic);
                            Console.WriteLine("Celsi publik " + args[1] + " u ruajt ne dir keys");
                        }
                        else
                        {
                            System.IO.File.WriteAllText("../../../../keys/" + args[1] + ".pub.xml", importedkey);
                            Console.WriteLine("Celsi publik " + args[1] + " u ruajt ne dir keys");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Celsi " + args[1] + " ekziston paraprakisht!");
                    }
                }

                catch
                {
                    Console.WriteLine("Fajlli i dhene nuk eshte qels valid!");
                }
            }
        }
    }
}