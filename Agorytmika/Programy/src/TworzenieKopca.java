import java.util.Random;

public class TworzenieKopca {
    static Random przypadkowe = new Random();

    public static void drukuj(int[] liczby) {
        for(int i = 0; i < liczby.length; i++) {
            System.out.print(liczby[i] + " ");
        }
        System.out.println();
    }
    public static int[] stworzListe(int n) {
        int[] lista = new int[n];
        for( int i = 1; i < n; i++) {
            lista[i] = przypadkowe.nextInt(200);
        }
        return lista;
    }
    static boolean czyJestKopcem(int[] lista) {
        int dlugosc = lista.length;
        boolean jestKopcem = true;
        for(int k =1; k<lista.length; k++) {
            if(2*k>=dlugosc) return true;
            jestKopcem = lista[k] >= lista[2*k];
            if(2*k+1>= dlugosc) return jestKopcem;
            jestKopcem = jestKopcem && lista[k]>=lista[2*k+1];
            if (!jestKopcem) return false;
        }
        return true;
    }
    static int[] zanurzanie(int[] lista, int k){
        int j;
        int N = lista.length - 1;
        while(2*k<=N) {
            j = 2*k;
            if(j<N && lista[j] < lista[j+1]) j++;
            if(!(lista[k]<lista[j])) break;
            int pom = lista[k];
            lista[k] = lista[j];
            lista[j] = pom;
            k=j;
        }
        return lista;
    }
    static int[] utworzKopiec(int[] lista) {
        int N = lista.length;
        for (int k=N/2; k>=1; k--) {
            zanurzanie(lista, k);
        }
        return lista;
    }
    public static void main(String[] args) {
        int n = 15;
        int[] lista = stworzListe(n);
        System.out.println("Stworzona lista:");
        drukuj(lista);
        if (czyJestKopcem(lista)) System.out.println("Lista jest kopcem"); //sprawdzanie czy lista jest kopcem
        else {
            System.out.println("Lista nie jest kopcem, tworze kopiec...");
            utworzKopiec(lista); //tworzenie kopca
        }
        drukuj(lista);
        if (czyJestKopcem(lista)) System.out.println("Lista jest kopcem");
        else System.out.println("Lista nie jest kopcem, algorytm posiada błąd");
    }
}
