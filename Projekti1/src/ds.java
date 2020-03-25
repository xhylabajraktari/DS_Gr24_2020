import java.util.Scanner;


public class ds {

    public static Scanner in = new Scanner(System.in);

    public static void main(String[] args) {
   
        int ch = in.nextInt();
        System.out.print("\n");
        while (ch != 0) {
            switch (ch) {
   
               case 1:
            	   
            	    System.out.print("---------------------\n");
                    System.out.print("<< TAP_CODE CIPHER >>\n");
                    System.out.print("---------------------\n\n");
                    tap_code t=new tap_code();
                    t.main(args);
                  
                    
                    break;
                   
               case 2:
                	 System.out.print("----------------------\n");
                     System.out.print("<< RAIL_FENCE CIPHER >>\n");
                     System.out.print("----------------------\n\n");
                     rail_fence r = new rail_fence();
                     r.main(args);

                     break;
               case 3:
                     System.out.print("---------------------\n");
                     System.out.print("<<  BEALE >>\n");
                     System.out.print("---------------------\n\n");
                     beale_cipher b=new beale_cipher();
                     b.main(args);
                     
                     break;

               default:
                    System.out.println("Shtyp ndermjete (1-3) !!\n\n");
            }
           
            ch = in.nextInt();
            System.out.print("\n");
        }
        System.out.print("Faleminderit :)\n");
    }

    public static void menu() {
        System.out.print("Shtyp 1 per te perdorur komanden Tap Code .\n");
        System.out.print("Shtyp 2 per te perdorur komanden Rail Fence .\n");
        System.out.print("Shtyp 3 per te perdorur komanden Beale .\n\n");
        System.out.print("Shtyp 0 per mbyllje .\n\n");
        System.out.print("Shtyp njerin nga numerat (0,1,2,3) : ");
    }
}