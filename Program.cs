using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {
            KrijoUser U = new KrijoUser();
            FshiUser F = new FshiUser();
            write_message w = new write_message();
            read_message r = new read_message();
            JWT_token J = new JWT_token();


            if (args.Length == 0)
            {
                Console.WriteLine("Miresevini te Siguria!");
                Console.WriteLine("Per te ekzekutuar komanden create user shtyp : ds create-user <name>");
                Console.WriteLine("Per te ekzekutuar komanden delete user shtyp : ds delete-user <name>");
                Console.WriteLine("Per te ekzekutuar komanden login shtyp : ds login <name>");
                Console.WriteLine("Per te ekzekutuar komanden status : ds status <name>");
                Console.WriteLine(
                    "Per te ekzekutuar komanden export key  shtyp  : ds export-key <public|private><name>[path]");
                Console.WriteLine("Per te ekzekutuar komanden import key shtyp  : ds import-key <name><path>");
                Console.WriteLine(
                    "Per te ekzekutuar komanden write message key shtyp  : ds write-message <name><message>[token]");
                Console.WriteLine("Per te ekzekutuar komanden read mesage shtyp  : ds read-message <ciphermessage>");
                Environment.Exit(1);
            }


            if (args[0] != "create-user" && args[0] != "delete-user" && args[0] != "export-key" && args[0] != "import-key" 
                && args[0] != "write-message" && args[0] != "read-message" && args[0] != "login" && args[0] != "status")
                Console.WriteLine("Komande e gabuar!");


            if (args[0] == "create-user")
            {
                try
                {
                    string user = args[1];

                    Console.Write("Jepni fjalekalimin: ");
                    string password = Console.ReadLine();
                    Console.Write("Perserit fjalekalimin: ");

                    if (!Regex.IsMatch(password, "^(?=.{6,}$)(?=.*[a-zA-Z])(?=.*[0-9\\W]).*$"))
                        throw new Exception(
                            "Password must be at least 6 characters long, must contain at least a number or symbol and a letter");
                    string perserit_password = Console.ReadLine();

                    if (password == perserit_password)
                    {
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

            if (args[0] == "write-message")
            {
                try
                {
                    Console.WriteLine();
                    switch (args.Length)
                    {
                        case 3:
                            w.EncryptALL(args[1], args[2]);
                            break;
                        case 4:
                            w.EncryptALL(args[1], args[2], args[3]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (args[0] == "read-message")
            {
                r.DecryptAll(args[1]);
            }

            if (args[0] == "login")
            {
                Console.Write("Shtyp passwordin: ");
                string password = Console.ReadLine();
                J.Login(args[1], password);
            }

            if (args[0] == "status")
            {
                bool status = J.status(args[1]);

                if (status)
                {
                    Console.WriteLine("Valid: po");
                }
                else
                {
                    Console.WriteLine("Valid: jo");
                }
            }
        }
    }
}