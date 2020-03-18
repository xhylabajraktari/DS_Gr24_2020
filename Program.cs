using System;
using System.Collections;
using System.Collections.Generic;

namespace TapCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> lettersAlllist = new List<char>();
            for (char letter = 'A'; letter <= 'Z'; letter++) // Lisa e shkronjave te alfabetit
            {
                lettersAlllist.Add(letter);
            }
            lettersAlllist.Remove('K'); // K-ja pasqyrohet me ane te shkronjes C kshtu qe ska nevoje me fut ne liste

            var alphabet = new Queue<char>(25); // Krijohet nje Queue qe i ruan me rend shkornjat e alfabetit
            for (int i = 0; i < lettersAlllist.Count; i++)
            {
                alphabet.Enqueue(lettersAlllist[i]);
            }

            // Matrica e shkronjave se bashku me informatat mbi rreshtin (X), kolonen(y) dhe Shkronjen perkatese
            var letterMatrix = new Cell[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var letter = alphabet.Dequeue();
                    letterMatrix[i, j] = new Cell(i + 1, j + 1, letter); // + 1 se aray ja nis prej 0-s ndersa matrica eshte e kodume prej 1 deri ne 5
                }
            }

            Console.WriteLine("Matrica e Tap-Cod-it");
            ShowMatrix(letterMatrix);
            Console.WriteLine("-------------------------");

            Console.Write("Shruani tekstin qe doni me enkodu: ");
            var stringToEncode = Console.ReadLine();
            var encodedString = Encode(letterMatrix, stringToEncode.ToUpper());
            Console.WriteLine("\nTeksti: '" + stringToEncode + "' pas encodimit eshte:\n " + encodedString);

            Console.WriteLine("_--------------------------------_");
            Console.WriteLine("Shkuarni teksin qe doni me dekodu: ");
            var stringToDecode = Console.ReadLine();
            var decodedString = Decode(letterMatrix, stringToDecode);
            Console.WriteLine("\nTeksti: '" + stringToDecode + "' pas decodimit eshte:\n " + decodedString);

            Console.Read();
        }


        public static string Encode(Cell[,] letterMatrix, string input)
        {
            var arrNumbers = new List<int>(input.Length * 2); // *2 pasi qe per secilen shkronje duhet me dit X-in(rreshti) dhe Y-in(kolonen)
            var encodedString = "";
            for (int i = 0; i < input.Length; i++)
            {
                var lInfo = GetLetterInfo(letterMatrix, input[i]);
                arrNumbers.Add(lInfo.X);
                arrNumbers.Add(lInfo.Y);
            } 

            for (int i = 0; i < arrNumbers.Count; i++) // Numrat e fituar nga rreshtat dhe kolonat e shkronjave i kthjme ne pika per enkodim
            {
                encodedString += ConvertNumberToDots(arrNumbers[i]) + " ";
            }
            return encodedString; // rezultati i enkodimit
        }

        public static string Decode(Cell[,] letterMatrix, string input)
        {
            var str = input.Split(' '); // ndahet vlera qe do te dekodohet ne baze te hapesirave edhe krijohet array me pikat e dhena si input
            var cellsToDecode = new List<EncodedCell>(str.Length / 2);  // vendi ku ruhen pikat (x dhe y) per dekodim
            EncodedCell c = new EncodedCell();

            for (int i = 0; i < str.Length; i++) // algorimti i merr cdo 2 elemente te pikave per shkak se dy elemente e formojne ni numer, njana per x tjetra per y
            {
                if (i % 2 == 0)
                {
                    c.X_Encoded = str[i];
                }
                else
                {
                    c.Y_Encoded = str[i];
                    cellsToDecode.Add(c);
                    c = new EncodedCell();
                }
            }

            var decodedString = "";
            for (int i = 0; i < cellsToDecode.Count; i++)
            {
                char s = GetEncodedCellInfo(letterMatrix, cellsToDecode[i]); // per secilen njesi te encoded cell gjehet shkronja perkatese qe i takon edhe ruhet ne decodedString
                decodedString += s;
            }
            return decodedString; // rezutati i dekodimit
        }

        public static Cell GetLetterInfo(Cell[,] letterMatrix, char letterToSearch) //  e lyp shkronjen e kerkuar ne matric, edhe i mer informata e saj (x-in edhe y-nin) rresht & kolone
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var mCell = letterMatrix[i, j];
                    if (mCell.Letter == letterToSearch)
                    {
                        return mCell;
                    }
                }
            }
            return null;
        }

        public static char GetEncodedCellInfo(Cell[,] letterMatrix, EncodedCell encodedCell)  // dy njesi me pika apo EncodedCell jau gjen shkronjen perkatese qe i perket
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var cell = letterMatrix[i, j];
                    if(cell.X == encodedCell.X_Encoded.Length && cell.Y == encodedCell.Y_Encoded.Length)
                    {
                        return cell.Letter;
                    }
                }
            }
            return '0';
        }

        public static string ConvertNumberToDots(int nr) // e konverton gjatesina e numrave ne pika per enkodim
        {
            var str = "";
            for (int i = 0; i < nr; i++)
            {
                str += ".";
            }
            return str;
        }

        public static void ShowMatrix(Cell[,] matrix)  // Shfaq tabelen e alfabetit
        {
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i, j].Letter + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
