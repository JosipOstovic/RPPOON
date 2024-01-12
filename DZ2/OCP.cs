using System;
using namespace OCP {
    public class Racun
    {
        public decimal Iznos { get; set; }

        public decimal IzracunajPopust(decimal popust)
        {
            return Iznos - (Iznos * popust / 100);
        }
    }

    class Program
    {
        static void Main()
        {
            Racun racun = new Racun { Iznos = 100 };

            // Popust za stalne kupce
            decimal popustZaStalneKupce = racun.IzracunajPopust(10);
            Console.WriteLine($"Iznos s popustom za stalne kupce: {popustZaStalneKupce}");

            // Popust za nove kupce
            decimal popustZaNoveKupce = racun.IzracunajPopust(5);
            Console.WriteLine($"Iznos s popustom za nove kupce: {popustZaNoveKupce}");
        }   
    }
}

//Ovaj primjer krsi OCP jer je klasa Racun otvorena za modificiranje kada god zelimo dodati novi tip popusta
//Problem je taj sto svaki put kada zelimo dodati novu vrstu popusta, moramo mijenjati postojeci kod klase Racun
//Ovo se moze rijesiti tako sto uvedemo sucelje npr IPopust i tu napisemo metodu IzracunajPopust
//dok u klasi Racun uvedemo referencu na sucelje IPopust sa getterima i setterima i nakon toga definiramo metodu IzracunajCijenu
//unutar koje mozemo preko reference pristupiti metodi IzracunajPopust i tako cemo za svakog novog kupca imati zasebnu klasu
//unutar koje mozemo izracunati određeni popust

