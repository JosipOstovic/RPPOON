/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
using System.Collections.Generic;

namespace ApstraktnaTvornica {
    public abstract class Factory
    {
        public abstract ITelevision createTelevision();
        public abstract IDisplay createDisplay();
    }

    public class DellFactory : Factory
    {
        public override ITelevision createTelevision()
        {
            return new DellTV();
        }
        public override IDisplay createDisplay()
        {
            return new DellDisplay();
        }

    }
    public class SamsungFactory : Factory
    {
        public override ITelevision createTelevision()
        {
            return new SamsungTV();
        }
        public override IDisplay createDisplay()
        {
            return new SamsungDisplay();
        }

    }
    public interface ITelevision {  void SellTV(); }
    public interface IDisplay {  void SellDisplay(); }

    public class DellTV : ITelevision
    {
        public void SellTV()
        {
            Console.WriteLine("Dell television sold!");
        }
    }

    public class SamsungTV : ITelevision
    {
        public void SellTV()
        {
            Console.WriteLine("Samsung television sold!");
        }
    }

    public class DellDisplay : IDisplay
    {
        public void SellDisplay()
        {
            Console.WriteLine("Dell display sold!");
        }
    }

    public class SamsungDisplay : IDisplay
    {
        public void SellDisplay()
        {
            Console.WriteLine("Samsung display sold!");
        }
    }

    public class App
    {
        List<Factory> factories = new List<Factory>
            {new DellFactory(), new SamsungFactory()};

        public void Run()
        {
            factories.ForEach(factory =>
            {
                ITelevision television = factory.createTelevision();
                IDisplay display = factory.createDisplay();

                television.SellTV();
                display.SellDisplay();
            });
        }
    }

    class Program
    {
        static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}

/*
SRP- klasa App sad samo koristi listu tvornica umjesto da instancira vise klasa proizvoda
OCP- suceljem proizvoda i apstraktnom tvornicom omogucujemo prosirenje tj. mozemo dodati jos tipova proizvoda bez da mjenjamo kod u App klasi
DIP- konkretne klase ovise o apstrakcijama tj. DellTV, DellMonitor, SamsungTV, SamsungMonitor, DellFactory, SamsungFactory sad ovise o ITV i IMoniotr suceljima
ISP - ITelevision i IDisplay su odvojeni umjesto da su spojeni u npr. IManufacturer
LSP - Konkretne Klase Factory su međusobno zamjenjive
*/
