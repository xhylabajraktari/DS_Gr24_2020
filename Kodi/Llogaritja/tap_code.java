package Llogaritja;
import java.util.Scanner;//importimi i paketes 
public class tap_code {

				//Metoda kryesore 
			    public static void main ( String [] args )
			    {
			        Scanner input = new Scanner( System.in );
			        System.out.print( "Deshironi te konvertoni nga Anglisht ne Tap (po ose jo)? " );
			        String answer = input.nextLine();//Pjesa ku lejohet qe klienti te jep pergjigjje
			        if( answer.equals( "po" ) )//Unaza e cila analizon pergjigjjet e klientit dhe ne baze saj e lidh ate me pjesen e caktuar te projktit
			        {
			        System.out.println( "Ju lutem shenoni tekstin qe deshironi ta konvertoni ne Tap: " );
			        String english = input.nextLine();
			        System.out.println( stringToTap( english ) );
			        }
				
			        if (answer.equalsIgnoreCase( "jo" ) )//Unaza e cila analizon pergjigjjet e klientit dhe ne baze saj e lidh ate me pjesen e caktuar te projktit
			        {
			            System.out.print( "Tap ne Anglisht? " );
			            String answer2 = input.nextLine();
			            if (answer2.equalsIgnoreCase( "po" ) )
			            {
			                System.out.println( "Ju lutem shenoni tekstin qe deshironi ta konvertoni ne Anglisht " );
			                String code = input.nextLine();
			                System.out.println( stringToEnglish( code ) );
			            }
			        }
			    }
			    //Funksioni per me dekodu germat e alfabetit ne tap-code.
			    public static String encode (String toEncode)
			    {
			        String tap = toEncode;
			      //tabela matricore 5x5 e tap-code.
			        if (toEncode.equalsIgnoreCase("a"))
			            tap = ". .";
			        if (toEncode.equalsIgnoreCase("b"))
			            tap = ". ..";
			        if (toEncode.equalsIgnoreCase("c"))
			            tap = ". ...";
			        if (toEncode.equalsIgnoreCase("d"))
			            tap = ". ....";
			        if (toEncode.equalsIgnoreCase("e"))
			            tap = ". .....";
			        if (toEncode.equalsIgnoreCase("f"))
			            tap = ".. .";
			        if (toEncode.equalsIgnoreCase("g"))
			            tap = ".. ..";
			        if (toEncode.equalsIgnoreCase("h"))
			            tap = ".. ...";
			        if (toEncode.equalsIgnoreCase("i"))
			            tap = ".. ....";
			        if (toEncode.equalsIgnoreCase("j"))
			            tap = ".. .....";
			        if (toEncode.equalsIgnoreCase("l"))
			            tap = "... .";
			        if (toEncode.equalsIgnoreCase("m"))
			            tap = "... ..";
			        if (toEncode.equalsIgnoreCase("n"))
			            tap = "... ...";
			        if (toEncode.equalsIgnoreCase("o"))
			            tap = "... ....";
			        if (toEncode.equalsIgnoreCase("p"))
			            tap = "... .....";
			        if (toEncode.equalsIgnoreCase("q"))
			            tap = ".... .";
			        if (toEncode.equalsIgnoreCase("r"))
			            tap = ".... ..";
			        if (toEncode.equalsIgnoreCase("s"))
			            tap = ".... ...";
			        if (toEncode.equalsIgnoreCase("t"))
			            tap = ".... ....";
			        if (toEncode.equalsIgnoreCase("u"))
			            tap = ".... .....";
			        if (toEncode.equalsIgnoreCase("v"))
			            tap = "..... .";
			        if (toEncode.equalsIgnoreCase("w"))
			            tap = "..... ..";
			        if (toEncode.equalsIgnoreCase("x"))
			            tap = "..... ...";
			        if (toEncode.equalsIgnoreCase("y"))
			            tap = "..... ....";
			        if (toEncode.equalsIgnoreCase("z"))
			            tap = "..... .....";
			        return tap;}
			    //Funksioni per me dekodu germat e alfabetit ne tap-code.
			    public static String decode (String toEncode) {
			        String tap = toEncode;

			        if (toEncode.equalsIgnoreCase(". ."))
			            tap = "a";
			        if (toEncode.equalsIgnoreCase(". .."))
			            tap = "b";
			        if (toEncode.equalsIgnoreCase(". ..."))
			            tap = "c";
			        if (toEncode.equalsIgnoreCase(". ...."))
			            tap = "d";
			        if (toEncode.equalsIgnoreCase(". ....."))
			            tap = "e";
			        if (toEncode.equalsIgnoreCase(".. ."))
			            tap = "f";
			        if (toEncode.equalsIgnoreCase(".. .."))
			            tap = "g";
			        if (toEncode.equalsIgnoreCase(".. ..."))
			            tap = "h";
			        if (toEncode.equalsIgnoreCase(".. ...."))
			            tap = "i";
			        if (toEncode.equalsIgnoreCase(".. ....."))
			            tap = "j";
			        if (toEncode.equalsIgnoreCase("... ."))
			            tap = "l";
			        if (toEncode.equalsIgnoreCase("... .."))
			            tap = "m";
			        if (toEncode.equalsIgnoreCase("... ..."))
			            tap = "n";
			        if (toEncode.equalsIgnoreCase("... ...."))
			            tap = "o";
			        if (toEncode.equalsIgnoreCase("... ....."))
			            tap = "p";
			        if (toEncode.equalsIgnoreCase(".... ."))
			            tap = "q";
			        if (toEncode.equalsIgnoreCase(".... .."))
			            tap = "r";
			        if (toEncode.equalsIgnoreCase(".... ..."))
			            tap = "s";
			        if (toEncode.equalsIgnoreCase(".... ...."))
			            tap = "t";
			        if (toEncode.equalsIgnoreCase(".... ....."))
			            tap = "u";
			        if (toEncode.equalsIgnoreCase("..... ."))
			            tap = "v";
			        if (toEncode.equalsIgnoreCase("..... .."))
			            tap = "w";
			        if (toEncode.equalsIgnoreCase("..... ..."))
			            tap = "x";
			        if (toEncode.equalsIgnoreCase("..... ...."))
			            tap = "y";
			        if (toEncode.equalsIgnoreCase("..... ....."))
			            tap = "z";
			       
			        	return tap;}
			    public static String stringToTap( String text )
			    {

			        String newText = "";
			        String selectedChar;
			        String convertedChar;
			      //Paraqitja e gjdo karakteri qe jep shfrytezuesi.
			        for (int i = 0; i < text.length(); i++)
			        {
			        	//Selekton karakterin e ardhshem 
			           
			            selectedChar = text.charAt(i) + "";

			            // Konverton karakterin 
			            convertedChar = encode(selectedChar);

			            if (convertedChar.equals(" ")) // " " I ndan secilen fjale qe jepet.
			            {
			                newText = newText + "| ";
			            }
			            //Shton tekstin e konvertuar dhe shton space.
			           
			            else
			            {
			                newText = newText + convertedChar;
			                if (!convertedChar.equals(" "))
			                {
			                    newText = newText + " ";
			                }
			            }
			        }

			        return newText;
			    }

			    public static String stringToEnglish( String text )
			    {
			       String newEnglish = ""; //Deklaron String per newEnglish
			       String selectedEnglish; //Deklaron String per selectedEnglish
			       String convertedEnglish; //Deklaron String per convertedEnglish
			       String[] tapChars = text.split(" ");
			     //Paraqitja e gjdo karakteri qe jep shfrytezuesi .
			       for (int i = 0; i < tapChars.length; i++)
			       {	
			           //Selekton tap karakterin e ardhshem 
			           selectedEnglish = tapChars[i];
			           boolean endsWithWordSeparator = selectedEnglish.endsWith("|");
			           if(endsWithWordSeparator) selectedEnglish = selectedEnglish.substring(0, selectedEnglish.length() - 1);
			           // Konverton ne String
			           convertedEnglish = decode(selectedEnglish);

			           newEnglish = newEnglish + convertedEnglish;
			           if (endsWithWordSeparator) 
			           {
			               newEnglish = newEnglish + " ";
			           }
			       }

			       return newEnglish; //kthen newEnglish
			    }
			
		
	}
