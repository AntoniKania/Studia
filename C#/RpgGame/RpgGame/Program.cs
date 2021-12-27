using System;
//using static System.Console;
using System.IO;
using System.Threading;
using System.Data.SQLite;
using System.Collections.Generic;
//using Microsoft.Data.Sqlite;

//dotnet add package Newtonsoft.Json --version 13.0.1


namespace RpgGame
{   
    class Program
    {
        public static string cs = "Data Source=./sqliteDB.db";
        public static void SqlShowPrice(string item, string location = "")
        {
            int n = 2;
            if (location == "user")
                n = 3;
            using var con = new SQLiteConnection(cs);
            con.Open();
            string command = "SELECT * FROM Items WHERE Name = '" + item + "'";
            using var cmd1 = new SQLiteCommand(command, con);
            using SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                Console.WriteLine($"{reader1.GetInt32(n)}" + "$");
            }
            con.Close();
        }
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
                if(!hero1.Items.Contains(reader1.GetString(1)))
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
        public static void Loading()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
        }
        
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Fight Club");
            Console.WriteLine("Choose Game Mode:");
            Console.WriteLine("[1] New Game");
            Console.WriteLine("[2] Load Game");
            Console.WriteLine("[3] Multiplayer");
            Console.WriteLine("[4] Quit Game");

            bool choosing = true;
            while (choosing == true)
            {
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        System.Console.WriteLine("Create Your Hero");
                        choosing = false;
                        Singleplayer.NewHero();
                        break;
                    case '2':
                        Console.Clear();
                        start:
                        List<string> fileNames = new List<string>();
                        string[] filePaths = Directory.GetFiles("./saves", "*.*");
                        int i = 0;
                        string fileName;
                        foreach (string file in filePaths)
                        {
                            fileName = file.Replace(@"./saves\", "").Replace(".json", "");
                            fileNames.Add(fileName);
                            if (fileName != "!!!template")
                            { 
                                Console.WriteLine("[" + i + "] " + fileNames[i] + "       " + File.GetLastWriteTime(file).ToString("dd/MM/yy HH:mm:ss"));
                            }
                            i++;
                        }

                        //choosing = true;
                        //while (choosing == true)
                        //Singleplayer.Preparation(Hero.Load(fileNames[info.KeyChar]));
                     
                        var info2 = Console.ReadKey();
                        try
                        {
                            while (choosing == true)
                            {
                                switch (info2.KeyChar)
                                {
                                    case '1':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[1]));
                                        break;
                                    case '2':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[2]));
                                        break;
                                    case '3':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[3]));
                                        break;
                                    case '4':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[4]));
                                        break;
                                    case '5':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[5]));
                                        break;
                                    case '6':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[6]));
                                        break;
                                    case '7':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[7]));
                                        break;
                                    case '8':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[8]));
                                        break;
                                    case '9':
                                        Console.Clear();
                                        choosing = false;
                                        Singleplayer.Preparation(Hero.Load(fileNames[9]));
                                        break;

                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.Write(ex.ToString());
                            Console.WriteLine("Iserted value is out of range, try again:");
                            goto start;
                        }
                        
                        
                        choosing = false;
                        break;
                        
                    case '3':
                        Console.Clear();
                        Multiplayer.NewHero();
                        choosing = false;
                        break;
                    case '4':
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            
            MainMenu();
        }
    }

}