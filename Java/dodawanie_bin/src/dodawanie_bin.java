

public class Konwertowanie {
    public static void drukuj(int[] liczby){
        for (int i = 0; i< liczby.length; i++)
            System.out.print(liczby[i] + " ");
        System.out.println();

    }
    public static int[] konwertuj(int x, int n) {
        int[] zw = new int[n];
        for(int i=0; i<n; i++){
            zw[n-1-i]=x%2;
            x=x/2;
        }
        return zw;
    }
    public static int konwertuj10(int[] lista){
        int waga = 1;
        int wartosc10 = 0;
        int koniec=lista.length-1;
        waga=waga<<koniec;
        for(int i=0; i<=lista.length; i++){
            wartosc10 += lista[i]*waga;
            waga/=2;

        }
        return wartosc10;
    }
    public static void main(String[] args) {
        int[] listaA = konwertuj(23,6);
        drukuj(listaA);
        int[] listaB = konwertuj(52,6);
        drukuj(listaB);
        int[] listaW = {0, 0, 0, 0, 0, 0, 0};
        int przeniesienie = 0;
        int sumaBit = 0;

        for (int i = listaA.length - 1; i >= 0; i--){

            sumaBit = listaA[i] + listaB[i] + przeniesienie;

            if (sumaBit == 0){
                listaW[i] = 0;

            }
            else if (sumaBit == 1){
                listaW[i] = 1;
                przeniesienie = 0;
            }
            else if (sumaBit == 2){
                listaW[i] = 0;
                przeniesienie = 1;
            }
            else if (sumaBit == 3){
                listaW[i] = 1;
                przeniesienie = 1;
            }
        }
        //listaW[0] = przeniesienie;
        //drukuj(listaA);
        //drukuj(listaB);
        drukuj(listaW);
        //System.out.println("suma = " + konwertuj10(listaW));
    }

}
