using System;
namespace RPG
{
     class Armor
    {
        public string Name { get; set; }

        public int Power { get; set; }

        public bool Equipped { get; set; }

        public Armor(string Name, int Power)
        {
            this.Name = Name;
            this.Power = Power;
            Equipped = false;
        }

        public override string ToString()
        {
            return $"Name: {Name}     Defense: +{Power}";
        }
        
    }
}
