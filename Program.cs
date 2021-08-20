using System;
using System.Collections.Generic;


namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxPower = 300;
            var maxHealth = 2000;
            int HeroOriginalHealth = 1000;

            Game myGame = new Game(maxPower, maxHealth);
            myGame.Start(HeroOriginalHealth, maxPower);
            Console.ReadKey();
        }
    }
}
