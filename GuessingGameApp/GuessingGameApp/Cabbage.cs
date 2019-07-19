using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGameApp
{
    class Cabbage : Element
    {
        public Cabbage(string name, Location Location)
        {
            this.Name = name;
            this.Location = Location;
        }

        //metodo per capire se pecora e cavolo si mangiano. o lupo
        public override bool Permetted(Element Elemento)
        {
            if (Elemento is Goat)
            {
                return false;
            }
            return true;
        }

    }
}
