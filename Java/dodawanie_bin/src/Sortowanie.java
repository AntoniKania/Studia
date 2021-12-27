import java.util.Random;

public class Sortowanie {

    static Random przypadkowe=new Random();
    static void sortuj(int[] lista) { //bubble sort
        int doPoz = lista.length-1;
        boolean posortowany;
        do {
            posortowany = true;
            for (int i = 0; i<doPoz-i; i++)
                if(lista[i] > lista[i+1]) {
                    int pom = lista[i];
                    lista[i] = lista[i+1];
                    lista[i+1] = pom;
                    posortowany = false;

                }
        }while (!posortowany);

        drukuj(lista);
    }
    static void drukuj (int[] lista) {
        for(int i = 0; i < lista.length; i++)
            System.out.print(lista[i] + " ");
        System.out.println();
    }

    static void sortujW (int [] lista) { //sortowanie przez wstawianie
        int koniec = lista.length-1;
        for( int i = 0; i < lista.length; i++){
            for (int j=i; j>lista[j]>lista[j-1];j--) {
        }
            System.out.println();
    }
    public static void main(String[] args) {
        int n = 30;
        int tab[] = new int[n];
        for(int i = 0; i < tab.length; i++)
            tab[i] = przypadkowe.nextInt(100);
        drukuj(tab);
        sortuj(tab);



    }
}
