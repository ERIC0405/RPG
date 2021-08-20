using System;
using System.Collections.Generic;
namespace RPG
{
     class Monster
    {
        public string Name { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }

        public int OriginalHealth { get; set; }

        public int CurrentHealth { get; set; }

        public Monster(string Name, int OriginalHealth, int Strength, int Defense)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Defense = Defense;
            this.OriginalHealth = OriginalHealth;
            CurrentHealth = OriginalHealth;
        }

        public override string ToString()
        {
            return $"Name: {Name} Strength: {Strength} Defense: {Defense} HP: {OriginalHealth}/{CurrentHealth}";
        }
    }
}
