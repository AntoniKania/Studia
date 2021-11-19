using System;

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

        static void NewHero(string name, string type, int str, int dex, int inte)
        {
            Hero hero = new Hero(name, type);
            Console.WriteLine(hero.Name + " Str:{" + str + "} Dex:{" + dex + "} Int:{" + inte + "}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
        }

        static void Main(string[] args)
        {
            System.Console.Write("Podaj nazwe swojego bohatera: ");
            string name = Console.ReadLine();
            System.Console.Write("Podaj klase swojego bohatera ");
            string type = Console.ReadLine();
            System.Console.Write("Podaj ilosc punktow sily: ");
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

