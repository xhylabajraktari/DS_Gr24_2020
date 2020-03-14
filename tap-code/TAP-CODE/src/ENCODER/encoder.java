package ENCODER;

import java.util.Scanner;
public class encoder {
	
private String original;
private String tcode;
private char[] tap;
encoder(String m)
	{
	original=m;
	}
//Funksioni per me dekodu germat e alfabetit ne tap-code.
		static String TAPEncode(char x) 
		{ 
		
			switch (x) 
			{ //tabela matricore 5x5 e tap-code.
				case 'a': 
					return ". ."; 
				case 'b': 
					return ". .."; 
				case 'c': 
					return ". ..."; 
				case 'd': 
					return ". ...."; 
				case 'e': 
					return ". ....."; 
				case 'f': 
					return ".. ."; 
				case 'g': 
					return ".. .."; 
				case 'h': 
					return ".. ..."; 
				case 'i': 
					return ".. ...."; 
				case 'j': 
					return ".. ....."; 
				case 'k': 
					return ". ..."; 
				case 'l': 
					return "... .";
				case 'm': 
					return "... .."; 
				case 'n': 
					return "... ..."; 
				case 'o': 
					return "... ...."; 
				case 'p': 
					return "... ....."; 
				case 'q': 
					return ".... ."; 
				case 'r': 
					return ".... .."; 
				case 's': 
					return ".... ..."; 
				case 't': 
					return ".... ...."; 
				case 'u': 
					return ".... ....."; 
				case 'v': 
					return "..... ."; 
				case 'w': 
					return "..... .."; 
				case 'x': 
					return "..... ..."; 
				case 'y': 
					return "..... ...."; 
				// for space 
				case 'z': 
					return "..... ....."; 
				case' ':
					return" ";
			
			}
			return ""; 
		} 
		//Konvertimi i tekstin ne tap-code
		public String getTapCode()
		{ 
			 
			tcode="";
			//Paraqitja e gjdo karakteri qe shenohet ne console.
			for (int i = 0;i<original.length(); i++) 
				tcode+=TAPEncode(original.charAt(i))+ " ";
			return tcode;
		} 
		
		//Metoda per shenimin ne console.
		public String getOriginal() {
			return original;
		}

	
		public static void main (String[] args) 
		{ 
			Scanner input=new Scanner(System.in);
			System.out.println("Jepe teksin: ");
			String original=input.nextLine();
			encoder message=new encoder(original);
			System.out.println("Teksti '"+message.getOriginal()+"' ne tap code eshte:\n" +message.getTapCode());
		} 
	} 
