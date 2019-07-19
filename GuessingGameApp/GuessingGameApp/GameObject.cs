using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGameApp
{
    class GameObject
    {
        public Bank StartBank { get; set; }
        public Bank EndBank { get; set; }
        public Sheaperd Sheaperd { get; set; }
        public Boat Boat { get; set; }
        public Wolf Wolf { get; set; }
        public Goat Goat { get; set; }
        public Cabbage Cabbage { get; set; }

        public void Init()
        {
            this.StartBank = new Bank("StartBank", new List<Element>(), Location.StartBank);
            this.EndBank = new Bank("EndBank", new List<Element>(), Location.EndBank);
            this.Boat = new Boat(Location.Boat);
            this.Boat.Bank = StartBank;
        }

        public bool IsSolution()
        {
            if (EndBank.Element.Count == 3)
            {
                Console.WriteLine("Gioco Finito!");
                return true;
            }
            return false;
        }

        public void Play()
        {
            Console.WriteLine("Come preferisci giocare?");
            Console.WriteLine("1 - Gioca il Computer");
            Console.WriteLine("2 - Gioco interattivo");
            int scelta;
            while (Int32.TryParse(Console.ReadLine(), out scelta) && (scelta != 1 && scelta != 2))
            {
                Console.WriteLine("Valore inserito non valido");
            }
            while (IsSolution() == false)
            {
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Iniziamo il gioco...");
                        GameLonely();
                        break;
                    case 2:
                        Console.WriteLine("Iniziamo il gioco...");
                        YourChooseGame();
                        break;
                }

            }
        }

        public void GameLonely()
        {
            while (IsSolution() == false)
            {
                Sheaperd.ChooseElement(StartBank);
                Console.WriteLine("------------------------->");
                Sheaperd.ChooseElement(EndBank);
                Console.WriteLine("<-------------------------");
            }

        }

        public void YourChooseGame()
        {
            while (IsSolution() == false)
            {
                Sheaperd.LetChooseElement(StartBank);
                Console.WriteLine("------------------------->");
                Sheaperd.LetChooseElement(EndBank);
                Console.WriteLine("<-------------------------");
            }
        }
    }
}
