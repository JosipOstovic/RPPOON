using System;
using System.Collections.Generic;
namespace SRP {
    public class Narudzba
    {   
        public string StanjeNarudzbe { get; set; }
        public string Proizvodi { get; set; }

        public void ObradiNarudzbu()
        {
            // Logika za obradu narudžbe
            StanjeNarudzbe = "obradena";
        }

        public void GenerirajIzvjestaj()
        {
            // Logika za generiranje izvještaja
            // Ovdje se miješaju poslovi obrade narudžbe i generiranja izvještaja
        }
    }
}

//Ovaj kod krsi SRP jer klasa Narudzba ima vise od jedne odgovornosti
//Problem je sto klasa obavlja dva razlicita posla: obrađivanje narudzbe i generiranje izvjestaja
//Metodu za generiranje izvjestaja bi trebalo premjestiti u drugu klasu, npr. IzvjestajGenerator koji ce obavljati samo tu odgovornost
