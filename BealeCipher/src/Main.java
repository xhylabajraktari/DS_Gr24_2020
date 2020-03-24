import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.println("Jepe permbajtjen e librit.txt : ");
        String book = sc.nextLine();

        int count = 0;
        int acount = 0;

        List<String> words = new ArrayList<>();       //Per fjale
        List<Integer> numbers = new ArrayList<>();    //Per numera
        StringBuilder sb = new StringBuilder();       //Per rezultatin ne fund

        //Krijome for pershkake se duhet te kaloj neper secilen fjale tek libri.txt
        for (int i = 0; i < book.length(); i++) {
            String check = String.valueOf(book.charAt(i));
            if (check.equals(" ")) {

                words.add(book.substring(count, i));
                count = i;
            }
        }
        words.add(book.substring(count, book.length()));

        System.out.println("Percakto fjaline ne baze te pozites nga libri.txt : ");
     
        String cipher = sc.nextLine().trim();

        for (int i = 0; i < cipher.length(); i++) {
            String acheck = String.valueOf(cipher.charAt(i));
            if (acheck.equals(",")) {

                int numcipher = Integer.parseInt(cipher.substring(acount, i).trim());
                numbers.add(numcipher);
                acount = i + 1;

            }
        }
        numbers.add(Integer.parseInt(cipher.substring(acount, cipher.length()).trim()));
        //Tek words nga libri e merr vetem shkronjen e pare qe eshte ne baze te asaj pozite qe ka pase dhe paraqitet rezultati
        for (Integer number : numbers) {
            int single = number - 1;
            String aword = words.get(single);
            Character aletter = aword.charAt(1);
            sb.append(aletter);

        }
        System.out.println(sb);

    }
}
