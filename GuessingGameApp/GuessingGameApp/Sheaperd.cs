using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessingGameApp
{
    class Sheaperd
    {
        public Boat Boat { get; set; }
        public Element El { get; set; }

        //Lista degli elementi per banchina
        public List<Element> GetListElementBank(Bank bank)
        {
            Console.WriteLine(bank.GetListElement());
            return bank.GetListElement();
        }

        //Caricare un elemento sulla barca
        public void GetElementToLoad(Element el, Bank bank)
        {
            Boat.TakeElement(el, bank);

        }

        //Stampa elemento sulla barca 
        public Element GetElementOnBoat()
        {
            return Boat.GetWhatElementOnBoat();
        }

        //Ritorna il count di elementi su una banchina
        public int CountElementOnBank(Bank bank)
        {
            return bank.CountElement();
        }

        //Logica gioco, scelta tra start e end 
        public void ChooseElement(Bank bank)
        {
            if (bank.Location == Location.StartBank)
            {
                ChooseElementFromStartBank(bank);
            }
            else
            {
                ChooseElementFromEndBank(bank);
            }
        }

        //Logica start bank
        public void ChooseElementFromStartBank(Bank bank)
        {
            if (bank.Location == Location.StartBank)
            {
                //Controllo che la barca sia vuota
                if (Boat.El != null)
                {
                    bank.AddElementInTheBank(Boat.El);
                    Boat.RemoveElement(Boat.El, bank);

                }
                foreach (Element item in bank.Element)
                {
                    Console.WriteLine("Elemento scelto: " + item.Name);
                    var elementiRestanti = bank.Element.Where(e => e != item);
                    //Quanti elementi restanti ci sono sulla bank?
                    if (elementiRestanti.Count() == 2)
                    {
                        bool possible = elementiRestanti.First().Permetted(elementiRestanti.Last());
                        if (possible)
                        {
                            Boat.TakeElement(item, bank);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" XXX : Impossibile caricare elemento per la sicurezza degli altri");
                        }
                    }
                    else
                    {
                        Boat.TakeElement(item, bank);
                        break;
                    }
                }

            }

        }

        //Logica EndBank
        public void ChooseElementFromEndBank(Bank bank)
        {
            if (bank.Location == Location.EndBank)
            {
                bank.AddElementInTheBank(Boat.El);
                foreach (Element item in bank.Element)
                {
                    var elementiRestanti = bank.Element.Where(e => e != Boat.El);
                    if (elementiRestanti.Count() == 1)
                    {
                        bool possibile = elementiRestanti.First().Permetted(Boat.El);
                        if (possibile == true)
                        {
                            Boat.RemoveElement(Boat.El, bank);
                            Console.WriteLine("Torno con la barca vuota");
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" XXX : Questi due elementi non vanno bene insieme");
                            Boat.RemoveElement(Boat.El, bank);
                            Boat.TakeElement(item, bank);
                            break;
                        }
                    }

                    else if (elementiRestanti.Count() == 2)
                    {
                        Boat.RemoveElement(Boat.El, bank);
                        break;
                    }

                    else
                    {
                        Boat.RemoveElement(Boat.El, bank);
                        Console.WriteLine("Torno con la barca vuota");
                        break;
                    }
                }

            }
        }
        public virtual void LetChooseElement(Bank bank)
        {
        }
        public virtual bool ChooseRightElement(Bank bank)
        {
            return true;

        }
    }
}