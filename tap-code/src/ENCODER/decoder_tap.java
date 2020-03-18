package ENCODER;

import java.util.Scanner;

public class decoder_tap {

	private String original;
	private String tcode;
	private char[] regular;
	private char[] tap;

	decoder_tap(String m){original=m;}
	//Funksioni per me dekodu germat e alfabetit ne tap-code.

			static String decoder(String x) 
			{ 
			
				switch (x) 
				{ 
				//Konvertimi i matrices 5x5
				case". .":
					
					return "a";
				case". ..": 
					return"b";
				case". ...":
					return "c";
				case". ....":
					return "e";
				case". .....":
					return "f";
				case ".. .":
					return "g";
				case ".. ..":
					return"h"; 
				case ".. ...":
					return "i";
				case ".. ....":
					return "j"; 
				case".. .....": 
					return "k"; 
				case"... .":
					return "l";
				case "... ..":
					return "m"; 
				case"... ...": 
					return "n"; 
				case "... ....": 
					return "o"; 
				case "... .....": 
					return"p";
				case".... .": 
					return "q"; 
				case ".... ..": 
					return"r"; 
				case ".... ...": 
					return "s"; 
				case ".... ....": 
					return "t";
				case ".... .....": 
					return "u"; 
				case "..... .": 
					return "v"; 
				case "..... ..": 
					return "w"; 
				case "..... ...": 
					return "x"; 
				case "..... ....": 
					return"y"; 
				case "..... .....": 
					return "z"; 
				//double space per mi dallu shkonjat mes veti 
				case "  ":
				return "";
				} 
					return ""; 
			} 
			
			
			//Konvertimi i tekstit
			public String getTapCode()
			{ 
				 
				tcode="";
				//Paraqitja e gjdo pike qe shenohet ne console.
				for (int i = 0;i<original.length(); i++) 
					tcode+=decoder(original.substring(i));
				return tcode;
				
			} 
			public String getOriginal() {
				return original;
			}

		
			public static void main (String[] args) 
			{ 
				System.out.println("Jepe teksin: ");
				Scanner input=new Scanner(System.in);
				String original=input.nextLine();
				decoder_tap message=new decoder_tap(original);
				System.out.println("Teksti '"+message.getOriginal()+"' ne tap code eshte:\n" +message.getTapCode());
			}
		



	
	
}
