using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
     class Game
    {
        public List<Weapon> Weapons { get; set; }

        public List<Armor> Armors { get; set; }

        public List<Monster> Monsters { get; set; }

        public Random factor { get; set; }

        public Game(int maxPower, int maxHealth)
        {

            string[] WeaponNames =new string[] { "Long Knife", "Short Knife","Long Spear","Short Gun","Hand Gun","Boxing Glove","Bow" };
            string[] ArmorNames = new string[] { "Common Shield", "Golden Shield", "Shield Spikes", "Cold Light Clothes", "Hauberk", "Golden Armor", "Silver Armor" };
            string[] MonsterNames = new string[] { "Long Arm Monkey ", "Short Dragon", "Golden Lion", "Green Wolf", "Spider", "Giant Dragon", "Bat" };

            Weapons = new List<Weapon>();
            Armors = new List<Armor>();
            Monsters = new List<Monster>();
            factor = new Random();

            for (int i = 0; i < WeaponNames.Length; i++)
            {
                Weapons.Add(new Weapon(WeaponNames[i], factor.Next(1, maxPower)));
                Armors.Add(new Armor(ArmorNames[i], factor.Next(1, maxPower)));
                Monsters.Add(new Monster(MonsterNames[i], factor.Next(maxHealth / 2, maxHealth), factor.Next(maxPower / 2, maxPower), factor.Next(1, maxPower)));
            }
        }

        public void Start(int HeroOriginalHealth, int maxPower)
        {
            Console.WriteLine("Please enter your character name: ");

            var hero = new Hero(Console.ReadLine(), HeroOriginalHealth, maxPower, maxPower, factor);
            var selection = MenuSelection();
            var exit = false;

            Console.Clear();
            Console.WriteLine($"Welcome, {hero.Name}!");

            while (!exit)
            {
                Console.Clear();

                switch (selection)
                {
                    case '1':
                        Console.WriteLine(hero);

                        Continue();
                        selection = MenuSelection();
                        break;

                    case '2':
                        hero.ShowInventory();

                        if (hero.WeaponBag.Count > 0 || hero.ArmorBag.Count > 0)
                        {
                            Console.WriteLine("Do you want to equip item? [Y/N]");
                            selection = Console.ReadKey(true).KeyChar;

                        }

                        if (selection.ToString().ToLower() == "y")
                        {
                            Console.Clear();

                            if (hero.ArmorBag.Count == 0 && hero.WeaponBag.Count > 0)
                            {
                                hero.EquipWeapon();
                            }
                            else if (hero.WeaponBag.Count == 0 && hero.ArmorBag.Count > 0)
                            {
                                hero.EquipArmor();
                            }
                            else if (hero.WeaponBag.Count > 0 && hero.ArmorBag.Count > 0)
                            {
                                hero.EquipWeapon();
                                hero.EquipArmor();
                            }

                            hero.ShowInventory();
                        }

                        Continue();
                        selection = MenuSelection();
                        break;

                    case '3':
                        var fight = new Fight();
                        var mon = Monsters[factor.Next(Monsters.Count)];

                        fight.Turn(hero, mon, factor);

                        if (hero.CurrentHealth == 0)
                        {
                            hero.Lose++;
                            exit = true;

                            Console.WriteLine("You lose the fight. Here is your final statistics.");
                            Console.WriteLine(hero);
                            Continue();
                        }
                        else
                        {
                            hero.Win++;
                            Win(hero);

                            if (Monsters.Count == 1)
                            {
                                exit = true;

                                Console.WriteLine("You beat all the monsters.\nHere are your statistics.");
                                Console.WriteLine(hero);
                                Continue();
                            }
                            else
                            {
                                Continue();
                                selection = MenuSelection();
                            }

                            Monsters.Remove(mon);
                        }
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Your game is not finished yet, are you sure you want to exit? [Y/N]");

                        selection = Console.ReadKey(true).KeyChar;

                        if (selection.ToString().ToLower() == "n")
                        {
                            selection = MenuSelection();
                        }
                        else if (selection.ToString().ToLower() == "y")
                        {
                            exit = true;
                            Console.WriteLine("Good game well played.");
                        }
                        else
                        {
                            Console.WriteLine("What are you doing here? You are going back to menu.");
                            Console.ReadKey(true);
                            selection = MenuSelection();
                        }
                        break;
                }
            }
        }

        public void Continue()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void Win(Hero hero)
        {
            Console.WriteLine("\nYou won the fight. Here are your loots.\n");

            var lootWeapon = Weapons[factor.Next(Weapons.Count)];
            var lootArmor = Armors[factor.Next(Armors.Count)];

            Weapons.Remove(lootWeapon);
            Armors.Remove(lootArmor);
            hero.ArmorBag.Add(lootArmor);
            hero.WeaponBag.Add(lootWeapon);

            Console.WriteLine($"{lootWeapon}\n{lootArmor}\n");
        }

        public char MenuSelection()
        {
            Console.WriteLine($"Please choose one option in menu.\n1. Current statistics.\n2. Check inventory.\n3. Fight!\n4. Exit");

            var selection = Console.ReadKey().KeyChar;

            while (selection != '1' && selection != '2' && selection != '3' && selection != '4')
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Please enter again.\n1. Current statistics.\n2. Check inventory.\n3. Fight!\n4. Exit");

                selection = Console.ReadKey().KeyChar;
            }
            return selection;
        }

        
        
    }
}
