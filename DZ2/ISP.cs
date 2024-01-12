using System;
class Program {
    interface IVozilo {
        void Vozi();
        void NapuniGorivo();
    }

    public class ElektricnoVozilo : IVozilo {
        public void Vozi() {
            //Logika za voznju elektricnog vozila
        }

        public void NapuniGorivo() {
            //Ova metoda nema smisla za elektricna vozila
        }
    }

    public class VoziloNaGorivo : IVozilo {
        public void Vozi() {
            //Logika za voznju vozila na gorivo
        }

        public void NapuniGorivo() {
            //Logika za punjenje goriva za vozila na gorivo
        }
    }
}

//Ovdje je vidljivo da IVozilo sucelje ima metodu NapuniGorivo koja nije primjerena za sva vozila
//posebno za elektricna koja se ne pune gorivom ali je klasa ElektricnoVozilo prisiljeno
//implementirati metodu NapuniGorivo sto nema smisla i to krsi ISP.
//Rijesenje bi bilo razbijanje vec postojeceg sucelja na manja kao npr IElektricnoVozilo i IVoziloNaGorivo
//i na taj nacin klijenti mogu implementirati samo ona sucelja koja su relevantna za vrstu vozila koju koriste