using System;
using System.Collections.Generic;

namespace GuessingGameApp
{
    class Program
    {
        static void Main(string[] args)
        {

            GameObject game = new GameObject();
            Bank StartBank = new Bank("StartBank", new List<Element>(), Location.StartBank);
            Bank EndBank = new Bank("EndBank", new List<Element>(), Location.EndBank);
            Wolf Wolf = new Wolf("Wolf", Location.StartBank);
            Goat Goat = new Goat("Goat", Location.StartBank);
            Cabbage Cabbage = new Cabbage("Cabbage", Location.StartBank);
            Boat Boat = new Boat(Location.Boat);
            InteractiveSheaperd Sheaperd = new InteractiveSheaperd();

            game.EndBank = EndBank;
            game.StartBank = StartBank;
            game.Sheaperd = Sheaperd;

            Sheaperd.Boat = Boat;
            Sheaperd.Goat = Goat;
            Sheaperd.Wolf = Wolf;
            Sheaperd.Cabbage = Cabbage;

            StartBank.AddElementInTheBank(Wolf);
            StartBank.AddElementInTheBank(Goat);
            StartBank.AddElementInTheBank(Cabbage);
            game.Play();
        }


    }
}
