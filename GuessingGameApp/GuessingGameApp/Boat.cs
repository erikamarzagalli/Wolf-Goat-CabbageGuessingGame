using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGameApp
{
    class Boat
    {
        public Element El { get; set; }
        public Bank Bank { get; set; }
        public Location Location { get; set; }
        public Boat(Location Location)
        {
            this.Location = Location;
        }

        //Rimuove elemento da banchina e lo prende la barca OK
        public void TakeElement(Element el, Bank bank)
        {
            if (El == null)
            {
                bank.RemoveElement(el);
                El = el;
                el.Location = Location.Boat;
                Console.WriteLine("L'elemento " + el.Name + " è stato caricato in barca");
            }
        }

        //Stampa elemento che c'è in barca OK
        public Element GetWhatElementOnBoat()
        {
            Console.WriteLine("Elemento nella barca: " + El.Name);
            return El;
        }

        //Rimuove elemento in barca OK
        public void RemoveElement(Element el, Bank bank)
        {
            El = null;
            if (bank.Location == Location.StartBank)
            {
                el.Location = Location.StartBank;
            }
            else
            {
                el.Location = Location.EndBank;
            }
            Console.WriteLine("L'elemento " + el.Name + " è stato scaricato dalla barca");
        }

    }
}
