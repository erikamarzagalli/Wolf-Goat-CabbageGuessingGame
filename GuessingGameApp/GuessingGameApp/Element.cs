using System;

namespace GuessingGameApp
{
    //abstract class Element
    class Element
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public virtual bool Permetted(Element El)
        {
            return false;
        }
    }
}
