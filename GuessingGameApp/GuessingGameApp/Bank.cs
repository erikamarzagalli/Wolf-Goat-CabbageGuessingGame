using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGameApp
{
    class Bank
    {
        public string Name { get; private set; }

        public List<Element> Element = new List<Element>();
        public Location Location { get; set; }
        public Boat Boat { get; set; }


        public Bank(string Name, List<Element> Element, Location Location)
        {
            this.Name = Name;
            this.Element = Element;
            this.Location = Location;
        }

        //Aggiungere elementi in banchina OK
        public void AddElementInTheBank(Element El)
        {
            Element.Add(El);
        }

        //Contare elementi in lista OK
        public int CountElement()
        {
            Console.WriteLine("Elementi: " + Element.Count);
            return Element.Count;
        }

        //Stampare lista di elementi NO
        public List<Element> GetListElement()
        {
            return Element;
        }

        //Togliere elemento da banchina OK
        public void RemoveElement(Element el)
        {
            Element.Remove(el);
            el.Location = Location.Boat;
        }

    }
}
