import java.util.Random;

public class WyszukiwanieBinarne {
    static Random przypadkowe = new Random();

    public static void drukuj(int[] liczby) {
        for(int i = 0; i < liczby.length; i++) {
            System.out.print(liczby[i] + " ");
        }
        System.out.println();
    }
    static int wyszukaj(int[] lista, int wartosc){
        int srodek = 0;
        int odPoz = 0;
        int doPoz = lista.length - 1;
        while(!(odPoz > doPoz)){
            srodek = odPoz + (doPoz - odPoz)/2;
            if(wartosc<lista[srodek])
                doPoz = srodek - 1;
            else if (wartosc>lista[srodek])
                odPoz = srodek + 1;
            else
                return srodek;
        }
        return odPoz;
    }
    public static int[] stworzListe(int n) {
        int[] lista = new int[n];
        for( int i = 0; i < n; i++) {
            lista[i] = przypadkowe.nextInt(200);
        }
        return lista;
    }
    static  int[] sortujb(int[] lista) {
        int doPozycji = lista.length - 1;
        boolean posortowane;
        do {
            posortowane = true;
            for (int i = 0; i < doPozycji ; i++)

                if (lista[i] > lista[i + 1]) {
                    int bufor = lista[i];
                    lista[i] = lista[i + 1];
                    lista[i + 1] = bufor;
                    posortowane = false;
                }
            doPozycji--;
        } while (!posortowane);
        return lista;
    }

    public static void main(String[] args) {
        int n = 10;
        int[] lista = stworzListe(n);
        System.out.println("Stworzona lista:");
        drukuj(lista);
        sortujb(lista); //sortowanie bąbelkowe
        System.out.println("Posortowana lista:");
        drukuj(lista);
        int wartosc = 15;
        int indeks = wyszukaj(lista, wartosc);
        System.out.println("Podana wartość (" + wartosc + ") powinna znalezc sie na pozycji " + indeks + " w stworzonej liście.");

    }
}
