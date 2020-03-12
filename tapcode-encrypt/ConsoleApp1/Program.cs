using System; 

class KERKESA1
{

	static string Encrypt(char x)
	{

		switch (x)
		{
			case 'a':
				return ". .  ";
			case 'b':
				return ". ..  ";
			case 'c':
				return ". ...  ";
			case 'd':
				return ". ....  ";
			case 'e':
				return ". .....  ";
			case 'f':
				return ".. .  ";
			case 'g':
				return ".. ..  ";
			case 'h':
				return ".. ...  ";
			case 'i':
				return ".. ....  ";
			case 'j':
				return ".. .....  ";
			case 'k':
				return ". ...  ";
			case 'l':
				return "... .  ";
			case 'm':
				return "... ..  ";
			case 'n':
				return "... ...  ";
			case 'o':
				return "... ....  ";
			case 'p':
				return "... .....  ";
			case 'q':
				return ".... .  ";
			case 'r':
				return ".... ..  ";
			case 's':
				return ".... ...  ";
			case 't':
				return ".... ....  ";
			case 'u':
				return ".... .....  ";
			case 'v':
				return "..... .  ";
			case 'w':
				return "..... ..  ";
			case 'x':
				return "..... ...  ";
			case 'y':
				return "..... ....  ";
			// for space 
			case 'z':
				return "..... .....  ";
			case ' ':
				return "/  ";
		}
		return "";
	}

	static void TapCode(string s)
	{
		
		for (int i = 0; i < s.Length; i++)
			Console.Write(Encrypt(s[i]));
		Console.WriteLine();
	}

	
	public static void Main()
	{
		string s = "neser";
		TapCode(s);
	}
}


