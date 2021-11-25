using System;
using System.Data;
using static System.Console;

using MySql.Data;
using MySql.Data.MySqlClient;



// dotnet add package MySql.Data --version 8.0.27

namespace chmsql
{
    class Program
    {
        static void CreateDatabase(string nazwa)
        {
          Console.Clear();
          string connStr = "server=localhost;user=root;database=infa;port=3306;password=";
          MySqlConnection conn = new MySqlConnection(connStr);
          try
          {     
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            string sql = "CREATE TABLE " + nazwa + " (id BIGINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT, login VARCHAR(32) UNIQUE NOT NULL, emial VARCHAR(64) UNIQUE NOT NULL, password VARCHAR(32) NOT NULL, PRIMARY KEY (id))";
            System.Console.WriteLine("Utworzono baze danych o nazwie " + nazwa);
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.ToString());
          }
          Main();

        }

        static void AddUser()
        {

          string connStr = "server=localhost;user=root;database=infa;port=3306;password=";
          MySqlConnection conn = new MySqlConnection(connStr);

          System.Console.Write("Podaj Imie i Nazwisko: ");
          string name = "'" + Console.ReadLine() + "'";
          System.Console.Write("Podaj email uzytkownika: ");
          string email = "'" + Console.ReadLine() + "'";
          System.Console.Write("Podaj date urodzenia uzytkownika: ");
          string birth = "'" + Console.ReadLine() + "'";
          try
          {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            string sql = "INSERT INTO users VALUES ( null ," + name + "," + email + "," + birth + ")";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            System.Console.WriteLine("Dodano uzytkownika");
            
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.ToString());
          }
          
          Main();
        }
      
        static void Main()
        {
            
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("[1] Utworzyc Nowa Baze Danych Klientow");           
            Console.WriteLine("[2] Dodaj klienta");
            Console.WriteLine("[3] Zakoncz Program");

            
            ConsoleKeyInfo keyPressed = ReadKey();

            if (keyPressed.Key == ConsoleKey.D1)
            {
              Console.Clear();
              Console.WriteLine("Podaj nazwe Bazy Danych: ");
              string nazwa = Console.ReadLine();
              CreateDatabase(nazwa);
            }
            if (keyPressed.Key == ConsoleKey.D2)
            {
              Console.Clear();        
              AddUser();
            }
            if (keyPressed.Key == ConsoleKey.D3)
            {
              Console.Clear();
              return;
            }
            
        }
    }
}