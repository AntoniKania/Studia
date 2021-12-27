using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    public class Multiplayer
    {
        public static void Fight(Hero hero1, Hero hero2, int n = 0)
        {
            bool end;
            end = false;
            while (end == false)
            {
                start: 
                Console.Clear();
                Console.WriteLine("Now playing: " + hero1.Name);
                if (n % 2 == 0)
                    Console.WriteLine(hero1.Name + "'s HP: " + hero1.Hp + "    " + hero2.Name + "'s HP: " + hero2.Hp);
                else
                    Console.WriteLine(hero2.Name + "'s HP: " + hero2.Hp + "    " + hero1.Name + "'s HP: " + hero1.Hp);
                Console.WriteLine("FIGHT!!!");
                Console.WriteLine("[1] Attack");
                Console.WriteLine("[2] Spell");
                Console.WriteLine("[3] Heal");
                bool choosing = true;
                bool attack = false;

                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            hero1.Attack(hero2);
                            attack = true;
                            choosing = false;
                            break;
                        case '2':
                            hero1.Spell(hero2);
                            attack = true;
                            choosing = false;
                            break;
                        case '3':
                            hero1.Healing(0.6);
                            choosing = false;
                            break;
                        case '4':
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to leave the fight? You will lose unsaved data.");
                            Console.WriteLine("[1] Yes");
                            Console.WriteLine("[2] No");
                            while (true)
                            {
                                var info2 = Console.ReadKey();
                                switch (info2.KeyChar)
                                {
                                    case '1':
                                        Program.MainMenu();
                                        break;
                                    case '2':
                                        goto start;
                                }
                            }
                    }

                    Console.Clear();
                    Console.WriteLine("Now playing: " + hero1.Name);
                    if (n % 2 == 0)
                        Console.WriteLine(hero1.Name + "'s HP: " + hero1.Hp + "    " + hero2.Name + "'s HP: " + hero2.Hp);
                    else
                        Console.WriteLine(hero2.Name + "'s HP: " + hero2.Hp + "    " + hero1.Name + "'s HP: " + hero1.Hp);
                    Console.WriteLine("FIGHT!!!");
                    Console.WriteLine("[1] Attack");
                    Console.WriteLine("[2] Spell");
                    Console.WriteLine("[3] Heal");
                    if (attack == true)
                        Console.WriteLine(hero1.Name + " Deals " + hero1.Damage + " Damage");
                    else
                        Console.WriteLine("Hp +" + hero1.HpDifference);
                    if (hero2.Hp > 0)
                    {
                        Console.Write(hero2.Name + " turn");
                        Program.Loading();
                        n++;
                        Fight(hero2, hero1, n);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(hero1.Name + " wins!");
                        Console.WriteLine("Press any button");
                        Console.ReadKey();
                        Program.MainMenu();
                    }
                    //Console.WriteLine();
                }
            }
        }

        public static void NewHero()
        {
            Console.WriteLine("(Player1) Create Your Hero");
            Console.Write("Type name of your hero: ");
            string name = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Choose class of your Hero:");
            System.Console.WriteLine("[1] Ninja  (Strength: 4, Dexterity: 8, Intelligence 4)\r\n[2] Samurai  (Strength: 8, Dexterity: 3, Intelligence: 3)\r\n[3] Monk  (Strength: 3, Dexterity: 4, Intelligence: 8)");
            string type = "";
            bool choosing = true;
            while (choosing == true)
            {
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

            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                System.Console.WriteLine("You got " + i + " More Points to Spend");
                System.Console.WriteLine("[1] Strenght: " + hero1.Strength + "   [2] Dexterity: " + hero1.Dexterity + "   [3] Intelligence: " + hero1.Intelligence);
                choosing = true;
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            hero1.Strength += 1;
                            choosing = false;
                            break;
                        case '2':
                            Console.Clear();
                            hero1.Dexterity += 1;
                            choosing = false;
                            break;
                        case '3':
                            Console.Clear();
                            hero1.Intelligence += 1;
                            choosing = false;
                            break;
                    }
                }

            }
            Console.WriteLine("You've Created your Hero!");
            NewHero2(hero1);
        }
        public static void NewHero2(Hero hero1)
        {
            Console.WriteLine("(Player2) Create Your Hero");
            Console.Write("Type name of your Hero: ");
            string name = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Choose class of your Hero:");
            System.Console.WriteLine("[1] Ninja  (Strength: 4, Dexterity: 8, Intelligence 4)\r\n[2] Samurai  (Strength: 8, Dexterity: 3, Intelligence: 3)\r\n[3] Monk  (Strength: 3, Dexterity: 4, Intelligence: 8)");
            string type = "";
            bool choosing = true;
            while (choosing == true)
            {
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
            Hero hero2 = new Hero(name, type);

            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                System.Console.WriteLine("You got " + i + " More Points to Spend");
                System.Console.WriteLine("[1] Strenght: " + hero2.Strength + "   [2] Dexterity: " + hero2.Dexterity + "   [3] Intelligence: " + hero2.Intelligence);
                choosing = true;
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            hero2.Strength += 1;
                            choosing = false;
                            break;
                        case '2':
                            Console.Clear();
                            hero2.Dexterity += 1;
                            choosing = false;
                            break;
                        case '3':
                            Console.Clear();
                            hero2.Intelligence += 1;
                            choosing = false;
                            break;
                    }
                }
            }
            Console.WriteLine("You've Created your Hero!");
            Fight(hero1, hero2);
            //Console.WriteLine("The Winner is: " + Fight(hero1, hero2));   
        }
    }
}
