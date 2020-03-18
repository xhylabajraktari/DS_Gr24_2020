public class Tap_code {
	package Llogaritja;
	import java.util.Scanner;
	public class tap_code {

		
			//Metoda kryesore 
		    public static void main ( String [] args )
		    {
		        Scanner input = new Scanner( System.in );
		        System.out.print( "Deshironi te konvertoni nga Anglisht ne Tap (po ose jo)? " );
		        String answer = input.nextLine();
		        if( answer.equals( "po" ) )
		        {
		        System.out.println( "Ju lutem shenoni tekstin qe deshironi ta konvertoni ne Tap: " );
		        String english = input.nextLine();
		        System.out.println( stringToTap( english ) );
		        }

		        if (answer.equalsIgnoreCase( "jo" ) )
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
		        String morse = toEncode;
		      //tabela matricore 5x5 e tap-code.
		        if (toEncode.equalsIgnoreCase("a"))
		            morse = ". .";
		        if (toEncode.equalsIgnoreCase("b"))
		            morse = ". ..";
		        if (toEncode.equalsIgnoreCase("c"))
		            morse = ". ...";
		        if (toEncode.equalsIgnoreCase("d"))
		            morse = ". ....";
		        if (toEncode.equalsIgnoreCase("e"))
		            morse = ". .....";
		        if (toEncode.equalsIgnoreCase("f"))
		            morse = ".. .";
		        if (toEncode.equalsIgnoreCase("g"))
		            morse = ".. ..";
		        if (toEncode.equalsIgnoreCase("h"))
		            morse = ".. ...";
		        if (toEncode.equalsIgnoreCase("i"))
		            morse = ".. ....";
		        if (toEncode.equalsIgnoreCase("j"))
		            morse = ".. .....";
		        if (toEncode.equalsIgnoreCase("l"))
		            morse = "... .";
		        if (toEncode.equalsIgnoreCase("m"))
		            morse = "... ..";
		        if (toEncode.equalsIgnoreCase("n"))
		            morse = "... ...";
		        if (toEncode.equalsIgnoreCase("o"))
		            morse = "... ....";
		        if (toEncode.equalsIgnoreCase("p"))
		            morse = "... .....";
		        if (toEncode.equalsIgnoreCase("q"))
		            morse = ".... .";
		        if (toEncode.equalsIgnoreCase("r"))
		            morse = ".... ..";
		        if (toEncode.equalsIgnoreCase("s"))
		            morse = ".... ...";
		        if (toEncode.equalsIgnoreCase("t"))
		            morse = ".... ....";
		        if (toEncode.equalsIgnoreCase("u"))
		            morse = ".... .....";
		        if (toEncode.equalsIgnoreCase("v"))
		            morse = "..... .";
		        if (toEncode.equalsIgnoreCase("w"))
		            morse = "..... ..";
		        if (toEncode.equalsIgnoreCase("x"))
		            morse = "..... ...";
		        if (toEncode.equalsIgnoreCase("y"))
		            morse = "..... ....";
		        if (toEncode.equalsIgnoreCase("z"))
		            morse = "..... .....";
		        return morse;}
		    //Funksioni per me dekodu germat e alfabetit ne tap-code.
		    public static String decode (String toEncode) {
		        String morse = toEncode;

		        if (toEncode.equalsIgnoreCase(". ."))
		            morse = "a";
		        if (toEncode.equalsIgnoreCase(". .."))
		            morse = "b";
		        if (toEncode.equalsIgnoreCase(". ..."))
		            morse = "c";
		        if (toEncode.equalsIgnoreCase(". ...."))
		            morse = "d";
		        if (toEncode.equalsIgnoreCase(". ....."))
		            morse = "e";
		        if (toEncode.equalsIgnoreCase(".. ."))
		            morse = "f";
		        if (toEncode.equalsIgnoreCase(".. .."))
		            morse = "g";
		        if (toEncode.equalsIgnoreCase(".. ..."))
		            morse = "h";
		        if (toEncode.equalsIgnoreCase(".. ...."))
		            morse = "i";
		        if (toEncode.equalsIgnoreCase(".. ....."))
		            morse = "j";
		        if (toEncode.equalsIgnoreCase("... ."))
		            morse = "l";
		        if (toEncode.equalsIgnoreCase("... .."))
		            morse = "m";
		        if (toEncode.equalsIgnoreCase("... ..."))
		            morse = "n";
		        if (toEncode.equalsIgnoreCase("... ...."))
		            morse = "o";
		        if (toEncode.equalsIgnoreCase("... ....."))
		            morse = "p";
		        if (toEncode.equalsIgnoreCase(".... ."))
		            morse = "q";
		        if (toEncode.equalsIgnoreCase(".... .."))
		            morse = "r";
		        if (toEncode.equalsIgnoreCase(".... ..."))
		            morse = "s";
		        if (toEncode.equalsIgnoreCase(".... ...."))
		            morse = "t";
		        if (toEncode.equalsIgnoreCase(".... ....."))
		            morse = "u";
		        if (toEncode.equalsIgnoreCase("..... ."))
		            morse = "v";
		        if (toEncode.equalsIgnoreCase("..... .."))
		            morse = "w";
		        if (toEncode.equalsIgnoreCase("..... ..."))
		            morse = "x";
		        if (toEncode.equalsIgnoreCase("..... ...."))
		            morse = "y";
		        if (toEncode.equalsIgnoreCase("..... ....."))
		            morse = "z";
		       
		        	return morse;}
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
		       String[] morseChars = text.split(" ");
		     //Paraqitja e gjdo karakteri qe jep shfrytezuesi .
		       for (int i = 0; i < morseChars.length; i++)
		       {
		           //Select the next morse character
		           selectedEnglish = morseChars[i];
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

		       return newEnglish;
		    }
		
	
}
