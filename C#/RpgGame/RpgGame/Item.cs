using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RpgGame
{
    public class Item
    {
        public static string cs = "Data Source=./sqliteDB.db";
        public int ShopPrice;
        public int UserPrice;
        public string Name;
        public int StrengthPoints;
        public int DexterityPoints;
        public int ArmorPoints; 

        public static List<string> SqlShow(Hero hero1, bool choice = false)
        {
            List<string> itemslist = new List<string>();
            int cost;
            int i = 1;
            string command = "";
            string symbol = "\0.";
            if (choice == true)
            {
                symbol = "[]";
                i = 2;
            }

            using var con = new SQLiteConnection(cs);
            con.Open();
            command = "SELECT * FROM Items";
            /*
            if (location == "shop")
                command = "SELECT * FROM Items WHERE Is_in_shop = 1";
            else if (location == "hero")
                command = "SELECT * FROM Items WHERE Is_in_shop = 0";
            */
            using var cmd1 = new SQLiteCommand(command, con);
            using SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (!hero1.Items.Contains(reader1.GetString(1)))
                {
                    Console.Write(symbol[0]);
                    Console.Write(i);
                    Console.Write(symbol[1]);
                    Console.WriteLine($"{reader1.GetString(1)}" + "     " + $"{reader1.GetInt32(2)}" + "$");
                    itemslist.Add(reader1.GetString(1));
                    i++;
                }
            }
            con.Close();
            return itemslist;
        }
        public Item (string name)
        {
            Name = name;
            using var con = new SQLiteConnection(cs);
            con.Open();
            string command = "SELECT * FROM Items WHERE Name = '" + name + "'";
            using var cmd1 = new SQLiteCommand(command, con);
            using SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                this.ShopPrice = reader1.GetInt32(2);
                this.StrengthPoints = reader1.GetInt32(3);
                this.DexterityPoints = reader1.GetInt32(4);
                this.ArmorPoints = reader1.GetInt32(5);
            }
            con.Close();
        }
    }
}
