using System;
//using static System.Console;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//dotnet add package Newtonsoft.Json --version 13.0.1


namespace project
{
    public class Hero
    {
        public string Name;
        public static int Strength;
        public static int Dexterity;
        public static int Intelligence;
        static int Hp;
        static int Exp;

        static void Init(int strength = 5, int dexterity = 5, int intelligence = 5, int hp = 100, int exp = 0)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Hp = hp;
            Exp = exp;
        }

        public int GetStrength() { return Strength; }
        public int GetDexterity() { return Dexterity; }
        public int GetIntelligence() { return Intelligence; }
        public int GetHp() { return Hp; }
        public void AddStrength(int z = 1) { Strength += z; }
        public void AddDexterity(int z = 1) { Dexterity += z; }
        public void AddIntelligence(int z = 1) { Intelligence += z; }

        public Hero(string name, string myclass, int strength = 0, int dexterity = 0, int intelligence = 0)
        {
            Name = name;
            switch (myclass)
            {
                case "ninja": Init(4, 8, 4, 100); break;
                case "samurai": Init(8, 3, 3, 100); break;
                case "monk": Init(3, 4, 8, 100); break;
                default: Init(strength, dexterity, intelligence); break;
            }
        }
        public void LevelUp()
        {
            Console.WriteLine("You leveled up !");
            Console.WriteLine("Attack +3");
            Console.WriteLine("Max health +10");
            Console.WriteLine("Heal +5");
            Console.ReadLine();
            Console.Clear();

            Strength += 2;
            Dexterity += 2;
            Intelligence += 2;
            Hp += 10;

        }

        public void Save()
        {
            string path = "./" + Name + ".json";
            File.Create(path);
            string data = File.ReadAllText(path);
            JObject Hero = JObject.Parse(data);
            //File.WriteAllText("./hero2.json", Hero.ToString());

        }
    }
    class Program
    {
        static bool Multiplayer;

        static void NewHero()
        {
            //Hero hero = new Hero(name, type);
            //Console.WriteLine(hero.Name + " Str:{" + str + "} Dex:{" + dex + "} Int:{" + inte + "}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
            System.Console.Write("Podaj nazwe swojego bohatera: ");
            string name = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Wybierz klase swojego bohatera:");
            System.Console.WriteLine("[1] Ninja  (Strength: 4, Dexterity: 8, Intelligence 4)\r\n[2] Samurai  (Strength: 8, Dexterity: 3, Intelligence: 3)\r\n[3] Monk  (Strength: 3, Dexterity: 4, Intelligence: 😎");
            string type = "";
            bool choosing = true;
            while (choosing == true)
            {
                //string input = Console.ReadLine();
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        System.Console.WriteLine("ninja");
                        type = "ninja";
                        choosing = false;
                        break;
                    case '2':
                        System.Console.WriteLine("samurai");
                        type = "samurai";
                        choosing = false;
                        break;
                    case '3':
                        System.Console.WriteLine("monk");
                        type = "monk";
                        choosing = false;
                        break;
                }
            }
            Hero hero1 = new Hero(name, type);
            //string type = Console.ReadLine();
            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                System.Console.WriteLine("Masz " + i + " dodatkowych punktow do wydania");
                System.Console.WriteLine("[1] Strenght: " + hero1.GetStrength() + "   [2] Dexterity: " + hero1.GetDexterity() + "   [3] Intelligence: " + hero1.GetIntelligence());
                choosing = true;
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            hero1.AddStrength();
                            choosing = false;
                            break;
                        case '2':
                            Console.Clear();
                            hero1.AddDexterity();
                            choosing = false;
                            break;
                        case '3':
                            Console.Clear();
                            hero1.AddIntelligence();
                            choosing = false;
                            break;
                    }
                }

            }
            ChapterOne();
        }

        static void MainMenu()
        {
            //var info = Console.ReadKey();
            Console.Clear();
            System.Console.WriteLine("Fight Club");
            System.Console.WriteLine("Wybierz tryb gry:");
            System.Console.WriteLine("[1] New Game");
            System.Console.WriteLine("[2] Load Game");

            //ConsoleKeyInfo keyPressed = ReadKey();

            bool choosing = true;

            while (choosing == true)
            {
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        Multiplayer = false;
                        Console.Clear();
                        System.Console.WriteLine("Create Your Hero");
                        choosing = false;
                        NewHero();
                        break;
                    case '2':
                        Multiplayer = true;
                        Console.Clear();
                        System.Console.WriteLine("Choose Save:");
                        choosing = false;
                        break;
                }
            }

            //hero1.Save();
            //NewHero(name, type, str, dex, inte);
            //Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }
        public void Fight(Hero enemy)
        {
            Console.Clear();
            System.Console.WriteLine("Player's HP: " + hero1.GetHp() + "    Enemy's HP: " + enemy.GetHp());
            System.Console.WriteLine("FIGHT!!!");

        }
        public void ChapterOne()
        {
            System.Console.WriteLine("Walka z 1. bossem");
            Hero enemy1 = new Hero("enemy1", "enemy", 6, 8, 140);
            while (hero1.GetHp() > 0 || enemy1.GetHp())
            {
                Fight(enemy1);
            }

        }
        static void Main(string[] args)
        {
            MainMenu();
        }
    }

}