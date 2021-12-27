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

        static void Init(int strength = 5, int dexterity = 5, int intelligence = 5, int hp = 100)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Hp = hp;
        }

        public int GetStrength() { return Strength; }
        public int GetDexterity() { return Dexterity; }
        public int GetIntelligence() { return Intelligence; }
        public int GetHp() { return Hp; }
        public void AddStrength() { Strength += 1; }
        public void AddDexterity() { Dexterity += 1; }
        public void AddIntelligence() { Intelligence += 1; }

        public Hero(string name, string myclass)
        {
            Name = name;
            switch (myclass)
            {
                case "ninja": Init(4, 8, 4, 100); break;
                case "samurai": Init(8, 3, 3, 100); break;
                case "monk": Init(3, 4, 8, 100); break;
                default: Init(); break;
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
            string data = File.ReadAllText("./" + Name + ".json");
            JObject Hero = JObject.Parse(data);
        }
    }
    class Program
    {
        static bool Multiplayer;

        /*static void NewHero(string name, string type, int str, int dex, int inte)
        {
            Hero hero = new Hero(name, type);
            Console.WriteLine(hero.Name + " Str:{" + str + "} Dex:{" + dex + "} Int:{" + inte + "}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }
        */
        static void Main(string[] args)
        {
            //var info = Console.ReadKey();

            System.Console.WriteLine("Fight Club");
            System.Console.WriteLine("Wybierz tryb gry:");
            System.Console.WriteLine("[1] Singleplayer");
            System.Console.WriteLine("[2] Multiplayer");

            //ConsoleKeyInfo keyPressed = ReadKey();

            bool choosing = true;

            while (choosing == true)
            {
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        Multiplayer = false;
                        System.Console.WriteLine("Tryb Singleplayer");
                        choosing = false;
                        break;
                    case '2':
                        Multiplayer = true;
                        System.Console.WriteLine("Tryb Multiplayer");
                        choosing = false;
                        break;
                }
            }

            System.Console.Write("Podaj nazwe swojego bohatera: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Wybierz klase swojego bohatera:");
            System.Console.WriteLine("[1] Ninja  (Strength: 4, Dexterity: 8, Intelligence 4)\r\n[2] Samurai  (Strength: 8, Dexterity: 3, Intelligence: 3)\r\n[3] Monk  (Strength: 3, Dexterity: 4, Intelligence: 8)");
            string type = "";
            choosing = true;
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
            System.Console.WriteLine("Sworzyles jakiegos debila es?");
            hero1.Save();

            int str = int.Parse(Console.ReadLine());
            System.Console.Write("Podaj dex swojego bohatera: ");
            int dex = int.Parse(Console.ReadLine());
            System.Console.Write("Podaj inteligencje swojego bohatera: ");
            int inte = int.Parse(Console.ReadLine());

            //NewHero(name, type, str, dex, inte);

            //Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }
    }

}

