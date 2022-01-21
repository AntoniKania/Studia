import java.util.Random;

public class SortowaniePrzezScalanie {
    static Random przypadkowe = new Random();

    static Trojka[] listaTrojek = new Trojka[100];
    static int lista[] = new int[16];
    static int pomocnicza[] = new int[lista.length];

    public static void drukuj(int[] liczby) {
        for(int i = 0; i < liczby.length; ++i)
            System.out.print(liczby[i] + " ");
        System.out.println();
    }
    static void scal(int odPoz, int srodek, int doPoz){
        int i = odPoz;
        int j = srodek + 1;
        for(int k = odPoz; k <= doPoz; k++){
            if(i>srodek) lista[k] = pomocnicza[j++];
            else if (j>doPoz) lista[k] = pomocnicza[i++];
            else{
                if(pomocnicza[j]<pomocnicza[i]) lista[k] = pomocnicza[j++];
                else lista[k] = pomocnicza[i++];
            }
        }
    }
    public static int utworzTrojki(int n){
        int number = 0;
        int tr1, tr2, tr3;
        for(int zakres=2;zakres<n+1;zakres*=2){
            for(int x=0; x<n; x += zakres){
                tr1=x; tr2=x+(zakres -1)/2;
                tr3 = x + zakres - 1;
                listaTrojek[number++] = new Trojka(tr1, tr2, tr3);
            }
        }
        return number;
    }
    static void drukujTrojki(int ile) {
        for(int i = 0; i<ile; i++) {
            System.out.println("[" + listaTrojek[i].x + " " + listaTrojek[i].y + " " + listaTrojek[i].z + "]");
        }
    }
    static void przepisanieListy() {
        for (int k = 0; k < lista.length; k++)
            pomocnicza[k] = lista[k];
        drukuj(pomocnicza);
    }
    public static void stworzListe(int n) {
        for( int i = 0; i < n; i++) {
            lista[i] = przypadkowe.nextInt(200);
        }
    }
    public static void main(String[] args) {
        int n = 16;
        stworzListe(n);
        System.out.println("Liczba powtałych trójek:");
        int ile = utworzTrojki(n); //tworzenie trojek, oraz sprawdzanie liczby wygenerwanej ilosci list trojek
        System.out.println(ile);
        System.out.println("Indeksy kolejnych trójek:");
        drukujTrojki(ile);
        System.out.println("Powstałe listy pomocnicze:");
        for(int j = 0; j < ile; j++){
            if (listaTrojek[j].x == 0) przepisanieListy();
            scal(listaTrojek[j].x, listaTrojek[j].y, listaTrojek[j].z);
        }
        System.out.println();
        System.out.println("Lista powstała po sortowaniu przez scalanie:");
        drukuj(lista);
    }
}
class Trojka {
    int x, y, z;
    public Trojka(int x, int y, int z) {
        this.x=x;
        this.y=y;
        this.z=z;
    }
}
