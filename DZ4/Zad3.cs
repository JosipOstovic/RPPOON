using System;
using System.Collections.Generic;

    public interface Champion{
        void Attack();
    }
    public class Assassin : Champion{
        string ability;
        public Assassin(string ability){
            this.ability= ability;
            Attack();
        }
        public void Attack(){
            Console.WriteLine($"Attack - {ability}");
        }
    }
    
    public class Mech : Champion{

            string specialEffect;
            public Mech(string specialEffect){
                this.specialEffect= specialEffect;
                Attack();
            }
            public void Attack(){
                Console.WriteLine($"Attack - {specialEffect}");
            }
        }

    public abstract class ChampionFactory
    {
        public abstract Champion CreateChampion();

    }
    public class AssassinFactory : ChampionFactory{
        public override Champion CreateChampion(){
            return new Assassin("Slice");
        }
    }
    public class MechFactory : ChampionFactory{
        public override Champion CreateChampion(){
            return new Mech("Rocket");
        }
    }

    public class Arena{
        Champion champion;
        public void SpawnChampion(ChampionFactory factory){
            champion= factory.CreateChampion();
        }
    }


    public class App
    {
        Arena arena= new Arena();

        public void Run()
        {
         arena.SpawnChampion(new AssassinFactory());
         arena.SpawnChampion(new MechFactory());
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