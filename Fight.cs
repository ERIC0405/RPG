using System;
using System.Collections.Generic;
namespace RPG
{
    enum Side
    {
        Hero,
        Monster
    }

    class Fight
    {
        public Side Side = Side.Hero;

        public void Turn(Hero Hero, Monster Monster, Random Factor)
        {
            Console.WriteLine($"Here comes the {Monster.Name}.\nHP: {Monster.OriginalHealth}\nStrength: {Monster.Strength}\nDefense: {Monster.Defense}");

            while (Hero.CurrentHealth > 0 && Monster.CurrentHealth > 0)
            {
                double CriticalHit = 1;

                if (Factor.Next(100) < 25)
                {
                    CriticalHit = 1.5;
                }

                if (Side == Side.Hero)
                {
                    var damage = (Hero.Strength + (Hero.EquippedWeapon == null ? 0 : Hero.EquippedWeapon.Power)) * CriticalHit - Monster.Defense;

                    damage = damage < 0 ? 0 : damage;
                    Monster.CurrentHealth -= (int)damage;

                    Console.Write($"\nIt's your turn.");

                    if (CriticalHit == 1.5)
                    {
                        Console.Write("Great! You just made a critical hit. ");
                    }

                    Console.Write($"The {Monster.Name} received a damage of {damage}. ");

                    if (Monster.CurrentHealth <= 0)
                    {
                        Monster.CurrentHealth = 0;

                        Console.WriteLine($"Its current health is 0/{Monster.OriginalHealth}.\n");
                    }
                    else
                    {
                        Side = Side.Monster;

                        Console.WriteLine($"Its current health is {Monster.CurrentHealth}/{Monster.OriginalHealth}.\n");
                        Console.WriteLine("Press any key to go to next turn.");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    var damage = Monster.Strength * CriticalHit - (Hero.Defense + (Hero.EquippedArmor == null ? 0 : Hero.EquippedArmor.Power));

                    damage = damage < 0 ? 0 : damage;
                    Hero.CurrentHealth -= (int)damage;

                    Console.Write($"\nIt's {Monster.Name}'s turn.");

                    if (CriticalHit == 1.5)
                    {
                        Console.Write(" It just made a critical hit. ");
                    }

                    Console.Write($"You received a damage of {damage}. ");

                    if (Hero.CurrentHealth <= 0)
                    {
                        Hero.CurrentHealth = 0;

                        Console.WriteLine("Your current health is 0.\n");
                    }
                    else
                    {
                        Side = Side.Hero;

                        Console.WriteLine($"Your current health is {Hero.CurrentHealth}/{Hero.OriginalHealth}.\n");
                        Console.WriteLine("Press any key to go to next turn.");
                        Console.ReadKey(true);
                    }
                }
            }
        }

    }
}
