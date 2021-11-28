using System;
using static System.Console;

namespace project
{
    public class Hero
    {
        public string Name;
        static int Strength;
        static int Dexterity;
        static int Intelligence;
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

        public Hero(string name, string myclass)
        {
            Name = name;
            switch (myclass)
            {
                case "warior": Init(8, 5, 2, 100); break;
                case "assassin": Init(3, 8, 4, 90); break;
                case "sorcerer": Init(4, 2, 9, 100); break;
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

            //attack += 3;
            //maxHealth += 10;
            Hp += 10;

        }
    }
    class Program
    {
        static bool Multiplayer;

        static void NewHero(string name, string type, int str, int dex, int inte)
        {
            Hero hero = new Hero(name, type);
            Console.WriteLine(hero.Name + " Str:{" + str + "} Dex:{" + dex + "} Int:{" + inte + "}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }

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
            System.Console.WriteLine("[1] Assassin [2] Warrior [3] Sorcerer ");
            string type = "";
            choosing = true;
            while (choosing == true)
            {
                //string input = Console.ReadLine();
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        System.Console.WriteLine("assassin");
                        type = "assassin";
                        choosing = false;
                        break;
                    case '2':
                        System.Console.WriteLine("warrior");
                        choosing = false;
                        break;
                    case '3':
                        System.Console.WriteLine("soccer");
                        choosing = false;
                        break;
                }
                
            }
            //string type = Console.ReadLine();
            System.Console.WriteLine("Podaj ilosc punktow sily: ");
            int str = int.Parse(Console.ReadLine());
            System.Console.Write("Podaj dex swojego bohatera: ");
            int dex = int.Parse(Console.ReadLine());
            System.Console.Write("Podaj inteligencje swojego bohatera: ");
            int inte = int.Parse(Console.ReadLine());

            
            NewHero(name, type, str, dex, inte);

            //Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }
    }

}

