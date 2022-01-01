using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace RpgGame
{
    public class Singleplayer
    {
        string cs = "Data Source=./sqliteDB.db";
        public static void Writting(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(3);
            }
            Console.WriteLine();
        }
        public static bool Confirm(string message)
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to " + message);
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            while (true)
            {
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        return true;
                    case '2':
                        return false;
                }
            }
        }
        public static bool Fight(Hero hero1, Hero enemy)
        {
            bool isChapterOne = false;
            if ((new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name == "ChapterOne")
                isChapterOne = true;

            while (true)
            {
            start:
                Console.Clear();
                System.Console.WriteLine("Player's HP: " + hero1.Hp + "    " + enemy.Name + "'s HP: " + enemy.Hp);
                System.Console.WriteLine("FIGHT!!!");
                Console.WriteLine("[1] Attack");
                Console.WriteLine("[2] Spell");
                Console.WriteLine("[3] Heal");
                Console.WriteLine("[4] Exit");

                if (enemy.Damage > 0)
                    Console.WriteLine(enemy.Name + " deals " + enemy.Damage + " damage");
                bool choosing = true;
                bool attack = false;

                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            hero1.Attack(enemy);
                            attack = true;
                            choosing = false;
                            break;
                        case '2':
                            hero1.Spell(enemy);
                            attack = true;
                            choosing = false;
                            break;
                        case '3':
                            hero1.Healing();
                            choosing = false;
                            break;
                        case '4':
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to leave the fight?");
                            Console.WriteLine("[1] Yes");
                            Console.WriteLine("[2] No");
                            while (true)
                            {
                                var info2 = Console.ReadKey();
                                switch (info2.KeyChar)
                                {
                                    case '1':
                                        if (isChapterOne == true)
                                            Program.MainMenu();
                                        else
                                            Preparation(hero1);
                                        break;
                                    case '2':
                                        goto start;
                                }
                            }

                    }
                    if (enemy.Hp <= 0)
                        return true;
                    Console.Clear();
                    System.Console.WriteLine("Player's HP: " + hero1.Hp + "    " + enemy.Name + "'s HP: " + enemy.Hp);
                    System.Console.WriteLine("FIGHT!!!");
                    Console.WriteLine("[1] Attack");
                    Console.WriteLine("[2] Spell");
                    Console.WriteLine("[3] Heal");
                    Console.WriteLine("[4] Exit");
                    if (attack == true)
                        Console.WriteLine(hero1.Name + " deals " + hero1.Damage + " damage");
                    else
                        Console.WriteLine("Hp +" + hero1.HpDifference);
                    Console.Write(enemy.Name + "'s turn");
                    Program.Loading();
                    enemy.Attack(hero1);
                    Console.WriteLine();
                }

                if (hero1.Hp <= 0)
                    return false;
            }
        }
        public static void NewHero()
        {

            Console.Write("Type name of your hero: ");
            string name = Console.ReadLine();
            
            Console.Clear();
            Console.WriteLine("Choose class of your Hero:");
            Console.WriteLine("[1] Ninja  (Strength: 4, Dexterity: 8, Intelligence 4)\r\n[2] Samurai  (Strength: 8, Dexterity: 3, Intelligence: 3)\r\n[3] Monk  (Strength: 3, Dexterity: 4, Intelligence: 8)");
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
                Console.WriteLine("You got " + i + " More Points to Spend");
                Console.WriteLine("[1] Strenght: " + hero1.Strength + "   [2] Dexterity: " + hero1.Dexterity + "   [3] Intelligence: " + hero1.Intelligence);
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
            Storyline(hero1, "Bird", 4, 140);
            //ChapterOne(hero1);
        }
        public static void Storyline(Hero hero1, string enemyName, int strength, int enemyHp)
        {
            if (hero1.FinishedLevel == 0)
            {
                Writting("Once upon a time there lived on the borders of a great forest a woodman and his wife who had one little daughter, a sweet, kind child, whom every one loved. She was the joy of her mother’s heart, and to please her, the good woman made her a little scarlet cloak and hood, and the child looked so pretty in it that everybody called her " + hero1.Name);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Writting("One day her mother told her she meant to send her to her grandmother—a very old woman who lived in the heart of the wood—to take her some fresh butter and new-laid eggs and a nice cake. " + hero1.Name + " was very pleased to be sent on this errand, for she liked to do kind things, and it was so very long since she had seen her grandmother that she had almost forgotten what the dame looked like.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Writting("The sun was shining brightly, but it was not too warm under the shade of the old trees, and " + hero1.Name + " sang with glee as she gathered a great bunch of wild flowers to give to her grandmother. She sang so sweetly that a bird dove flew down from a tree and followed her. " + hero1.Name + " as a " + hero1.MyClass + " don't like to be follow, so she decided that she will kill a bird.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            if (hero1.FinishedLevel == 1)
            {
                Writting(hero1.Name + " was not in a hurry, and there were many things to amuse her in the wood. She ran after the white and yellow butterflies that danced before her, and sometimes she caught one, but she always let it go again, for she never liked to hurt any creature.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Writting("But this time it was diffrent, she accidentally bite one of butterflies head off. The headless butterfly rised to an enormous size and attacked " + hero1.Name + ".");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            if (hero1.FinishedLevel == 2)
            {
                Writting("By and by " + hero1.Name + " reached her grandmother’s house, and tapped at the door.");
                Writting("“Come in,” said the Grandma, in a squeaking voice. “Pull the string, and the latch will come up.”");
                Writting(hero1.Name + " thought grandmother must have a cold, she spoke so hoarsely; but she went in at once, and there lay her granny, as she thought, in bed.");
                Writting("“Come here, dear,” said the Grandma, “and let me kiss you,” and " + hero1.Name + " obeyed.");
                Writting("But when " + hero1.Name + " saw her Grandma she felt frightened. She had nearly forgotten grandmother, but she did not think she had been so ugly.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Writting("“Grandmamma,” she said, “what a great nose you have.”");
                Writting("“All the better to smell with, my dear”");
                Writting("“And, grandmamma, what large ears you have.”");
                Writting("“All the better to hear with, my dear.”");
                Console.WriteLine();
                Writting("At this point " + hero1.Name + " was sure that it's wolf, not her real Grandmother. She heard simular stories before, so she decided she will take him by suprised so she attacked him.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            if (hero1.FinishedLevel == 3)
            {
                Writting("It turned out it actually was her grandma who had a cold. Bunch of guards immediately forced the doors and barge in, because I forgot to mention but her Grandma was Queen of Yamatai");
                Writting("Guards were about to kill " + hero1.Name + " but just out of nowhere some sort of dragon rip off the rooftop and started talking something, but not for long because brave or rather afreid for her life " + hero1.Name + " attacked the Dragon.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        start:
            Console.Clear();
            Console.Write("Fight!");
            Program.Loading();
            Hero enemy1 = new Hero(enemyName, "enemy", strength, 8, 4, enemyHp);
            if (Fight(hero1, enemy1) == true)
            {
                Console.Clear();
                Console.WriteLine("You won the Fight!");
                Thread.Sleep(1000);
                hero1.Hp = hero1.MaxHp;
                hero1.Cash += 200;
                hero1.Exp += 500;
                hero1.FinishedLevel += 1;
                if (hero1.Exp % 1000 == 0)
                    hero1.LevelUp();
                hero1.Save();
                Preparation(hero1);
            }
            else
            {
                Console.Clear();
                hero1.Hp = hero1.MaxHp;
                Console.WriteLine("You lose");
                Console.WriteLine("[1] Try Again");
                Console.WriteLine("[2] Exit");
                bool choosing;
                choosing = true;
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            goto start;
                        case '2':
                            Console.Clear();
                            Preparation(hero1);
                            break;
                    }
                }
                hero1.Hp = hero1.MaxHp;
                goto start;
            }
        }
        public static void Preparation(Hero hero1)
        {
            if (hero1.FinishedLevel == 4)
            {
                Writting("Congratulations now there are no witness that " + hero1.Name + " have killed her Grandma!");
                Writting("You can blame it on dragon and come out on the hero :)");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You’ve finished the main story quest line!");
                Console.WriteLine("Press any key to conntinue...");
                Console.ReadKey();
                Program.MainMenu();
            }
        start:
            Console.Clear();
            Console.WriteLine(hero1.Name + "    lvl:" + hero1.Level + "    " + hero1.Cash + "$" + "    EXP:" + hero1.Exp);
            Console.WriteLine("[1] Next Quest");
            Console.WriteLine("[2] Shop");
            Console.WriteLine("[3] Save & Exit to Main Menu");
            //Console.WriteLine("[5] Save & Exit to Desktop");
            bool choosing;
            choosing = true;
            while (choosing == true)
            {
                var info = Console.ReadKey();
                switch (info.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        if (hero1.FinishedLevel == 1)
                            Storyline(hero1, "Enormous Headless Butterfly", 6, 140);
                        else if (hero1.FinishedLevel == 2)
                            Storyline(hero1, "Grandma or Wolf, who knows?", 8, 150);
                        else if (hero1.FinishedLevel == 3)
                            Storyline(hero1, "Some Sort of Dragon", 9, 160);
                        choosing = false;
                        break;
                    case '2':
                        Console.Clear();
                        Shop(hero1);
                        choosing = false;
                        break;
                    case '3':
                        Console.Clear();
                        hero1.Save();
                        Program.MainMenu();
                        choosing = false;
                        break;
                }
            }

        }
        public static void Shop(Hero hero1)
        {
        start:
            Console.Clear();
            Console.WriteLine("Welcome in your local shop!       " + hero1.Cash + "$" + "    EXP:" + hero1.Exp);
            Console.WriteLine("Your Equipment:");
            int n = 1;
            foreach (string item in hero1.Items)
            {
                Console.Write(n + "." + item + "        ");
                Program.SqlShowPrice(item, "user");
                n++;
            }

            //Program.SqlShow(hero1);
            Console.WriteLine("Smith's Equipment: ");
            Program.SqlShow(hero1);
            //itemy kowala
            Console.WriteLine("[1] Buy");
            Console.WriteLine("[2] Sell");
            Console.WriteLine("[3] Exit Shop");
            bool choosing;
            choosing = true;
            while (choosing == true)
            {
                var info2 = Console.ReadKey();
                switch (info2.KeyChar)
                {
                    case '1':
                        choosing = false;
                        Buy(hero1);
                        break;
                    case '2':
                        Console.Clear();
                        Sell(hero1);
                        choosing = false;
                        break;
                    case '3':
                        Console.Clear();
                        hero1.Save();
                        Preparation(hero1);
                        choosing = false;
                        break;
                }
            }

        }
        static void Buy(Hero hero1)
        {
        buying:
            Console.Clear();
            Console.WriteLine("Insert number of item you want to buy.     " + hero1.Cash + "$");
            Console.WriteLine("[1] Back");
            List<string> list = Program.SqlShow(hero1, true);
            //Program.SqlShow(hero1, true);
            //wyswietlanie bazy danych z opcja wyboru
            bool choosing;
            choosing = true;
            try
            {
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Shop(hero1);
                            choosing = false;
                            break;
                        case '2':
                            Console.Clear();
                            Item item = new Item(list[0]);
                            if (Confirm("buy this item " + item.Name + "?") == true && hero1.Cash >= item.ShopPrice)
                            {
                                hero1.AddItem(item);
                                Console.WriteLine("You bought " + item.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto buying;
                        case '3':
                            Console.Clear();
                            Item item1 = new Item(list[1]);
                            if (Confirm("item") == true)
                            {
                                hero1.AddItem(item1);
                                Console.WriteLine("You bought " + item1.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '4':
                            Console.Clear();
                            Item item2 = new Item(list[2]);
                            if (Confirm("item") == true)
                            {
                                hero1.AddItem(item2);
                                Console.WriteLine("You bought " + item2.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '5':
                            Console.Clear();
                            if (Confirm("item") == true)
                            {

                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '6':
                            Console.Clear();
                            if (Confirm("item") == true)
                            {

                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '7':
                            Console.Clear();
                            if (Confirm("item") == true)
                            {

                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '8':
                            Console.Clear();
                            if (Confirm("item") == true)
                            {

                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                        case '9':
                            Console.Clear();
                            if (Confirm("item") == true)
                            {

                            }
                            else
                                goto buying;
                            choosing = false;
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Iserted value out of range, try again:");
                goto buying;
            }
        }
        static void Sell(Hero hero1)
        {
        selling:
            Console.Clear();
            Console.WriteLine("Insert number of item you want to sell.     " + hero1.Cash + "$");
            Console.WriteLine("[1] Back");
            int n = 2;
            foreach (string item in hero1.Items)
            {
                Console.Write("[" + n + "]" + item + "        ");
                Program.SqlShowPrice(item, "user");
                n++;
            }
            bool choosing;
            choosing = true;
            try
            {
                while (choosing == true)
                {
                    var info = Console.ReadKey();
                    switch (info.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Shop(hero1);
                            choosing = false;
                            break;
                        case '2':
                            Console.Clear();
                            Item item = new Item(hero1.Items[0]);
                            if (Confirm("sell this item " + item.Name + "?") == true)
                            {
                                hero1.SellItem(item);
                                Console.Clear();
                                Console.WriteLine("You sold " + item.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto selling;
                        case '3':
                            Console.Clear();
                            Item item1 = new Item(hero1.Items[1]);
                            if (Confirm("sell this item " + item1.Name + "?") == true)
                            {
                                hero1.SellItem(item1);
                                Console.Clear();
                                Console.WriteLine("You sold " + item1.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto selling;
                        case '4':
                            Console.Clear();
                            Item item2 = new Item(hero1.Items[2]);
                            if (Confirm("item") == true)
                            {
                                hero1.AddItem(item2);
                                Console.WriteLine("You bought " + item2.Name);
                                Thread.Sleep(700);
                                Shop(hero1);
                                break;
                            }
                            else
                                goto selling;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Iserted value out of range, try again:");
                goto selling;
            }
        }
    }
}
