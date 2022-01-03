using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Data.SQLite;
using System.Collections.Generic;



namespace RpgGame
{
    public class Hero
    {   
        public string Name;
        public int Strength;
        public int Dexterity;
        public int Intelligence;
        public int Hp;
        public int Exp;
        public int MaxHp;
        public int HpDifference;
        public int Damage;
        public string MyClass;
        public int Cash;
        public int Armor;
        public int Level;
        public int FinishedLevel;
        public List<string> Items = new List<string>();

        Random rng = new Random();
        public static string cs = "Data Source=./sqliteDB.db";

        public void Init(int strength = 5, int dexterity = 5, int intelligence = 5, int hp = 100, int exp = 0)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Hp = hp;
            MaxHp = hp;
            Exp = exp;
            Cash = 0;
            Level = 1;
            FinishedLevel = 0;
        }

        public Hero(string name, string myclass, int strength = 0, int dexterity = 0, int intelligence = 0, int hp = 0)
        {
            MyClass = myclass;
            Name = name;
            switch (myclass)
            {
                case "ninja": Init(4, 8, 4, 100); break;
                case "samurai": Init(8, 3, 3, 100); break;
                case "monk": Init(3, 4, 8, 100); break;
                default: Init(strength, dexterity, intelligence, hp); break;
            }
        }
        public void LevelUp()
        {
            Console.Clear();
            Console.WriteLine("You leveled up!");
            Console.WriteLine("Strength +3");
            Console.WriteLine("Dexterity +3");
            Console.WriteLine("Intelligence +3");
            Console.WriteLine("Max health +10");
            Console.WriteLine("Cash +100$");
            Console.WriteLine("Press any key to continue...");

            Strength += 3;
            Dexterity += 3;
            Intelligence += 3;
            MaxHp += 10;
            Cash += 100;
            Level++;

            Console.ReadKey();
            Console.Clear();
        }
        public void Attack(Hero opponent)
        {
            int random = rng.Next(13, 16);
            if (random == 13)
            {
                Console.WriteLine(Name + " missed!");
                Thread.Sleep(700);
            }
            else
            {
                Damage = Convert.ToInt32((1.2 * Strength + 0.5 * Dexterity) * rng.Next(13, 16) * 0.1);
                opponent.Hp -= Damage;
            }
            if (opponent.Hp < 0) { opponent.Hp = 0; }
        }
        public void Spell(Hero opponent)
        {
            Console.Clear();
            if (MyClass == "ninja")
                Console.WriteLine("Choose Spell You Want to use: \n\r[1] Vortex   [2] Aperes   [3] Augarbus ");
            else if (MyClass == "samurai")
                Console.WriteLine("Choose Spell You Want to use: \n\r[1] Mobilecto   [2] Exteortia   [3] Immius ");
            else
                Console.WriteLine("Choose Spell You Want to use: \n\r[1] Mobiaris   [2] Relorgio   [3] Increnulsis ");
            Console.ReadKey();
            int random = rng.Next(13, 16);
            if (random == 13)
            {
                Console.WriteLine(Name + " missed!");
            }
            else
            {
                Damage = Convert.ToInt32((Intelligence + 0.5 * Dexterity) * random * 0.1);
                opponent.Hp -= Damage;
            } 
            if (opponent.Hp < 0) { opponent.Hp = 0; }
        }
        public void Healing(double multi = 1)
        { 
            int oldHp = Hp;
            if (Hp < MaxHp)
                Hp += Convert.ToInt32((Intelligence + 0.5 * Dexterity + 0.5 * Strength) * rng.Next(13, 16) * 0.1 * multi);
            if (Hp > MaxHp)
                Hp = MaxHp;
            HpDifference = Hp - oldHp;
        }
        public void Save()
        {
            List<string> heroItems = new List<string>();
            Console.Clear();
            Directory.CreateDirectory("./saves");
            string path = "./saves/" + Name + ".json";
            if (!File.Exists(path))
            {
                string sourceFile = "./saves/!!!template.json";
                File.Copy(sourceFile, path, true);
            }
            string data = File.ReadAllText(path);
            JObject Hero = JObject.Parse(data);
            Hero["MyClass"] = MyClass;
            Hero["Strength"] = Strength;
            Hero["Dexterity"] = Dexterity;
            Hero["MaxHp"] = MaxHp;
            Hero["Armor"] = Armor;
            Hero["Level"] = Level;
            Hero["FinishedLevel"] = FinishedLevel;
            Hero["Cash"] = Cash;
            Hero["Intelligence"] = Intelligence;
            Hero["Exp"] = Exp;
            Hero["Name"] = Name;
            foreach (string item in Hero["Items"])
                heroItems.Add(item);
            //foreach (string item in Items)
            //  if (!heroItems.Contains(item))
            //    Hero["Items"].Append(item);
            JsonSerializer.Serialize(Items);
            File.WriteAllText(path, Hero.ToString());
            Console.WriteLine("Progress Saved!");
            Thread.Sleep(1000);
        }
        public static Hero Load(string name)
        {
            name = "./saves/" + name + ".json";
            string heroString = File.ReadAllText(name);
            JObject heroJson = JObject.Parse(heroString);
            string heroName = (string)heroJson["Name"];
            string heroClass = (string)heroJson["MyClass"];
            Hero hero = new Hero(heroName, heroClass);
            hero.Strength = (int)heroJson["Strength"];
            hero.Dexterity = (int)heroJson["Dexterity"];
            hero.Intelligence = (int)heroJson["Intelligence"];
            foreach (string item in heroJson["Items"])
                hero.Items.Add(item);
            hero.Exp = (int)heroJson["Exp"];
            hero.MaxHp = (int)heroJson["MaxHp"];
            hero.Cash = (int)heroJson["Cash"];
            hero.Armor = (int)heroJson["Armor"];
            hero.Level = (int)heroJson["Level"];
            hero.FinishedLevel = (int)heroJson["FinishedLevel"];
            hero.Hp = hero.MaxHp;

            return hero;
        }
        public void AddItem(Item item)
        {
            Items.Add(item.Name);
            Strength += item.StrengthPoints;
            Dexterity += item.DexterityPoints;
            Armor += item.ArmorPoints;
            Cash -= item.ShopPrice;
        }
        public void SellItem(Item item)
        {
            Items.Remove(item.Name);
            Strength -= item.StrengthPoints;
            Dexterity -= item.DexterityPoints;
            Armor -= item.ArmorPoints;
            Cash += item.UserPrice;
        }
    }
}
