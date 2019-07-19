using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGameApp
{
    class Goat : Element
    {
        public Goat(string name, Location Location)
        {
            this.Name = name;
            this.Location = Location;
        }

        //metodo per capire se pecora e cavolo si mangiano. o lupo
        public override bool Permetted(Element Elemento)
        {
            if (Elemento is Wolf)
            {
                return false;
            }
            if (Elemento is Cabbage)
            {
                return false;
            }

            return true;
        }
    }
}
