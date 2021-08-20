using System;
using System.Collections.Generic;
namespace RPG
{
    class Hero
    {
        public string Name { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }

        public int OriginalHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int Win { get; set; }

        public int Lose { get; set; }

        public Weapon EquippedWeapon { get; set; }

        public Armor EquippedArmor { get; set; }

        public List<Armor> ArmorBag { get; set; }

        public List<Weapon> WeaponBag { get; set; }

        public Hero(string Name, int OriginalHealth, int MaxStrength, int MaxDefense, Random Factor)
        {
            this.Name = Name;
            this.OriginalHealth = OriginalHealth;
            Strength = Factor.Next(MaxStrength / 2, MaxStrength);
            Defense = 0;
            ArmorBag = new List<Armor>();
            WeaponBag = new List<Weapon>();
            CurrentHealth = OriginalHealth;

        }

        public void ShowStats()
        {
            Console.WriteLine(this);
        }

        public void ShowInventory()
        {
            if (WeaponBag.Count > 0)
            {
                foreach (var weapon in WeaponBag)
                {
                    if (weapon.Equipped == true)
                    {
                        Console.Write("(Equipped) ");
                    }
                    Console.WriteLine($"{weapon}\n");
                }
            }
            else
            {
                Console.WriteLine("You do not have any weapon in your bag.\n");
            }

            if (ArmorBag.Count > 0)
            {
                foreach (var armor in ArmorBag)
                {
                    if (armor.Equipped == true)
                    {
                        Console.Write("(Equipped) ");
                    }
                    Console.WriteLine($"{armor}\n");
                }
            }
            else
            {
                Console.WriteLine("You do not have any armor in your bag.");
            }
        }

        public void EquipWeapon()
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter number to choose your weapon: \n");

                for (int i = 0; i < WeaponBag.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {WeaponBag[i]}");
                }

                var selection = Console.ReadKey(true).KeyChar;

                if (Char.IsDigit(selection) && ((int)Char.GetNumericValue(selection) > 0 && (int)Char.GetNumericValue(selection) <= WeaponBag.Count))
                {
                    var index = (int)Char.GetNumericValue(selection) - 1;

                    if (EquippedWeapon != null)
                    {
                        EquippedWeapon.Equipped = false;
                    }

                    WeaponBag[index].Equipped = true;
                    EquippedWeapon = WeaponBag[index];
                    exit = true;

                    Console.WriteLine($"\nYou equipped the {WeaponBag[index].Name}.\n");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Wrong selection. Please choose again!");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
        }

        public void EquipArmor()
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter number to choose your armor: \n");

                for (int i = 0; i < ArmorBag.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ArmorBag[i]}");
                }

                var selection = Console.ReadKey(true).KeyChar;

                if (Char.IsDigit(selection) && ((int)Char.GetNumericValue(selection) > 0 && (int)Char.GetNumericValue(selection) <= ArmorBag.Count))
                {
                    var index = (int)Char.GetNumericValue(selection) - 1;

                    if (EquippedArmor != null)
                    {
                        EquippedArmor.Equipped = false;
                    }

                    ArmorBag[index].Equipped = true;
                    EquippedArmor = ArmorBag[index];
                    exit = true;

                    Console.WriteLine($"\nYou equipped the {ArmorBag[index].Name}.\n");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Wrong selection. Please choose again!");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\nStrength: {Strength + (EquippedWeapon == null ? 0 : EquippedWeapon.Power)}\nDefense: {Defense + (EquippedArmor == null ? 0 : EquippedArmor.Power)}\nHP: {CurrentHealth}/{OriginalHealth}\nWin: {Win}\nLose: {Lose}";
        }

    }
}
