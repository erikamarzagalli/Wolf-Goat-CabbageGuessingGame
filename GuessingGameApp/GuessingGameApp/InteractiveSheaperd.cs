using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessingGameApp
{
    class InteractiveSheaperd : Sheaperd
    {
        public Wolf Wolf { get; set; }
        public Goat Goat { get; set; }
        public Cabbage Cabbage { get; set; }

        public override void LetChooseElement(Bank bank)
        {
            if (bank.Location == Location.StartBank)
            {
                LetChooseElementFromStartBank(bank);
            }
            else
            {
                LetChooseElementFromEndBank(bank);
            }
        }

        public Element UnderstandElement(string input)
        {
            if (Wolf.Name.StartsWith(input))
            {
                El = Wolf;
            }
            else if (Goat.Name.StartsWith(input))
            {
                El = Goat;
            }
            else if (Cabbage.Name.StartsWith(input))
            {
                El = Cabbage;
            }
            return El;
        }

        public void LetChooseElementFromStartBank(Bank bank)
        {
            if (Boat.El != null)
            {
                bank.AddElementInTheBank(Boat.El);
                Boat.RemoveElement(Boat.El, bank);
            }
            Console.WriteLine("Scegli elemento dalla startBank oppure premi N:");
            foreach (Element el in bank.Element)
            {
                Console.WriteLine("- " + el.Name);
            }
            foreach (Element elem in bank.Element)
            {
                string input = Console.ReadLine();
                Element scelto = UnderstandElement(input);
                if (input == "n")
                {
                    Console.WriteLine("Nessun elemento caricato in barca");
                    break;
                }
                var elementiRestanti = bank.Element.Where(e => e != scelto);
                if (elementiRestanti.Count() == 2)
                {
                    bool isPossible = elementiRestanti.First().Permetted(elementiRestanti.Last());
                    if (isPossible == true)
                    {
                        Boat.TakeElement(scelto, bank);
                        bank.RemoveElement(scelto);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" XXX : Impossibile caricare elemento per la sicurezza degli altri");
                        Console.WriteLine("Scegli un altro elemento: ");
                    }
                }
                else
                {
                    Boat.TakeElement(scelto, bank);
                    break;
                }

            }

        }

        public void LetChooseElementFromEndBank(Bank bank)
        {
            bank.AddElementInTheBank(Boat.El);
            Console.WriteLine("Scegli elemento dalla endbank oppure premi N:");
            foreach (Element el in bank.Element)
            {
                Console.WriteLine("- " + el.Name);
            }
            foreach (Element element in bank.Element)
            {
                string input = Console.ReadLine();
                if (input == "N")
                {
                    if (bank.Element.Count() == 2)
                    {
                        bool isPossible = bank.Element.First().Permetted(Boat.El);
                        if (isPossible == true)
                        {
                            Boat.RemoveElement(Boat.El, bank);
                            Console.WriteLine("Nessun elemento caricato in barca");
                            break;
                        }
                        else
                        {
                            Boat.RemoveElement(Boat.El, bank);
                            Console.WriteLine(" XXX : Impossibile lasciare elementi così");
                            Console.WriteLine("Scegli un elemento: ");
                        }
                    }
                    else
                    {
                        Boat.RemoveElement(Boat.El, bank);
                        Console.WriteLine("Nessun elemento caricato in barca");
                        break;
                    }
                }
                else
                {
                    Element scelto = UnderstandElement(input);
                    if (Boat.El != null)
                    {
                        Boat.RemoveElement(Boat.El, bank);
                    }
                    Boat.TakeElement(scelto, bank);
                    bank.RemoveElement(scelto);
                    break;
                }
            }
        }



    }
}

