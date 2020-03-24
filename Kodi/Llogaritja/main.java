package Llogaritja;
//importimi i klasave
import Llogaritja.tap_code;
import Llogaritja.BealeCipher;
import Llogaritja.RailFence;
public class main {
	public static void main(String[] args) {
		//krijimi i objeketeve per klasat perkatese
		tap_code t=new tap_code();
		BealeCipher b=new BealeCipher();
		RailFence r=new RailFence();
		System.out.println("---------------------------TAP CODE-------------------------------");
		System.out.println("Teksti i dhene ne tap code eshte:" +t.stringToTap("neser"));
		System.out.println("Teksti i dhene ne English nga tap eshte :"+t.stringToEnglish("... ... . ..... .... ... . ..... .... .."));
		System.out.println("\n\n");
		
		System.out.println("Teksti i dhene ne RailFence me celes 3 eshte: "+r.encryption("neser",3));
		System.out.println("Teksti i dhene ne English eshte me celes 3 eshte: "+r.decryption("nrees",3));
	}
}
