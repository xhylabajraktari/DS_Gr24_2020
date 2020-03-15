package komanda2;
import java.util.Scanner;
public class RailFenceCipher {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		System.out.print("Shkruani tekstin : ");
		String plainText=in.nextLine();
		System.out.print("Shkruani nr. e qelsit: ");
		int key =in.nextInt();
		String en=encryption(plainText,key);
		System.out.print("Teksti i enkriptuar : ");
		System.out.println(en);
		String den=decryption(en,key);
		System.out.print("Teksti i dekriptuar : ");
		System.out.println(den);
		
		
	}
 static String encryption(String text,int key) {
	 String encryptedText="";
	 boolean check=false;   //Kontrollimi nese pozita e shkronjes eshte poshte ose larte
	 int j=0;
	 int row=key;    //Rreshtat jane aq sa jan key
	 int col=text.length();   //Kolonatt jane aq sa eshte teksti i gjate
	 char[][] a= new char[row][col];
	 for(int i=0;i<col;i++) {
		 if(j==0||j==key-1)    //Shikimi nese j eshte ne fillim te row ose ne fund te row
			 check = !check;   //Ndrrimi check sepse nese eshte top do te shkoj down 
		 a[j][i]=text.charAt(i);//Shtimi i shkronjave ne poziten e tyre 
		 if(check)
			 j++;//e rrisim j
		 else 
			j--;//e zvogelojme j
		
	 }
	 //Leximi rresht per rresht
	 for(int i=0;i<row;i++) {
		 for(int k=0;k<col;k++) {
		if(a[i][k]!=0)
			encryptedText+=a[i][k];
		 }
		 
	 }
	 // Paraqitja e matrices
	 for(int i=0;i<row;i++) {
		 for(int k=0;k<col;k++) {
		 System.out.print(a[i][k]+"");
		 }
		 System.out.println();
	 }
	 return encryptedText;
 }
 static String decryption(String text ,int key) {
	 String decryptedText="";
	 boolean check=false;
	 int j=0;
	 int row=key;
	 int col=text.length();
	 //Na duhet matrica
	 char[][] a= new char[row][col];
	 for(int i=0;i<col;i++) {
		 if(j==0||j==key-1)
			 check = !check;
		 a[j][i]='*';
		 if(check)
			 j++;
		 else 
			j--;
		
	 }
	 
	 int index=0;
	 check=false;
	 for (int i=0;i<row;i++) {
	 for(int k=0;k<col;k++) {
	 if(a[i][k]=='*' && index<col) {
		 a[i][k]=text.charAt(index++);
	 }}}
 
	 //Paraqitja e tekstit te dekriptuar
 j=0;
	 for(int i=0;i<col;i++) {
		 if(j==0||j==key-1)
			 check = !check;
		decryptedText+=a[j][i];
		 if(check)
			 j++;
		 else 
			j--;
		
	 }
	 return decryptedText;
 }
 
}
