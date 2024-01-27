using System;
using System.Collections.Generic;
    public abstract class Car{
        public abstract void Drive();
    }
    public class Audi : Car{
        public Audi(){
            Drive();
        }
        public override void Drive(){
            Console.WriteLine("Audi Drives!");
        }
    }
    public class VW : Car{
        public VW(){
            Drive();
        }
        public override void Drive(){
            Console.WriteLine("VW Drives!");
        }
    }
    public abstract class CarFactory{
        public abstract Car CreateCar();

    }
    public class AudiFactory : CarFactory{
        public override Car CreateCar(){
            return new Audi();
        }
    }

    public class VWFactory : CarFactory{
        public override Car CreateCar(){
            return new VW();
        }
    }
    public class Wroom{
        Car car;
        public void DriveCar(CarFactory factory){
            car= factory.CreateCar();
        }
    }
    public class App
    {
        Wroom wroom= new Wroom();

        public void Run()
        {
         wroom.DriveCar(new AudiFactory());
         wroom.DriveCar(new VWFactory());
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

//Radi se o metodi tvornici