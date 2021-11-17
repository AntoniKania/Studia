using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

// dotnet add package MySql.Data --version 8.0.27

namespace chmsql
{
    class Program
    {
        static double Sum(double a, double b)
        {
            return a + b;
        }

        static void Execut()
        {
            // stworzyć bazę danych
        }

        static void CreateDatabase()
        {
            // stworzyć bazę danych
        }

        static void AddUser(string login, string email, string passwd)
        {
            // dodawanie urzytkownika
        }

        static void Main(string[] args)
        {

            double a = 12, b = 34;

            Console.WriteLine(Sum(a, b));

            // Co chcesz zrobić
            // >> CreateDatabase - stwórz
            // >> AddUser - podaj login, podaj email, podaj hasło


            /*
            string connStr = "server=localhost;user=root;database=infa;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
              Console.WriteLine("Connecting to MySQL...");
              conn.Open();

              string sql = "INSERT INTO users VALUES (null, 'malpiszon', 'malpiszon@gmail.com', '#tajneHaslo123')";
              MySqlCommand cmd = new MySqlCommand(sql, conn);
              cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }
            */
            /*
            try
            {
              Console.WriteLine("Connecting to MySQL...");
              conn.Open();

              string sql = "SELECT COUNT(*) FROM users";
              MySqlCommand cmd = new MySqlCommand(sql, conn);
              object result = cmd.ExecuteScalar();
              if (result != null)
              {
                int count = Convert.ToInt32(result);
                Console.WriteLine("Number of countries in the users database is: " + count);
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }

            try
            {
              Console.WriteLine("Connecting to MySQL...");
              conn.Open();

              string sql = "SELECT * FROM users";
              MySqlCommand cmd = new MySqlCommand(sql, conn);
              MySqlDataReader response = cmd.ExecuteReader();
              while (response.Read())
              {
                Console.WriteLine(response[0] + " " + response[1] + " " + response[2] + " " + response[3]);
              }
              response.Close();
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            */
        }
    }
}