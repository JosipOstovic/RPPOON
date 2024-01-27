using System;
using System.Collections.Generic;

    public interface IIngrediant
    {
        void AddIngrediant();
    }

    public class Bowl : IIngrediant
    {
        public void AddIngrediant()
        {
            Console.WriteLine("Pick up a bowl!");
        }
    }

     public class NoIngrediant : IIngrediant
    {
        public void AddIngrediant()
        {
            Console.WriteLine("No Ingrediant");
        }
    }

    public class BaseIngredientDecorator : IIngrediant
    {
        IIngrediant ingrediant;
        public BaseIngredientDecorator(IIngrediant ingrediant)
        {
            this.ingrediant = ingrediant;
        }
        public virtual void AddIngrediant()
        {
            ingrediant.AddIngrediant();
        }
    }

    public class Noodles : BaseIngredientDecorator
    {
        public Noodles(IIngrediant ingrediant) : base(ingrediant) { }
        public override void AddIngrediant()
        {
            base.AddIngrediant();
            Console.WriteLine("Add Noodles");
        }
    }

    public class Beef : BaseIngredientDecorator
    {
        public Beef(IIngrediant ingrediant) : base(ingrediant) { }
        public override void AddIngrediant()
        {
            base.AddIngrediant();
            Console.WriteLine("Add Beef");
        }
    }

    public class Mushrooms : BaseIngredientDecorator
    {
        public Mushrooms(IIngrediant ingrediant) : base(ingrediant) { }
        public override void AddIngrediant()
        {
            base.AddIngrediant();
            Console.WriteLine("Add Mushrooms");
        }
    }

    public class Water : BaseIngredientDecorator
    {
        public Water(IIngrediant ingrediant) : base(ingrediant) { }
        public override void AddIngrediant()
        {
            base.AddIngrediant();
            Console.WriteLine("Add Water");
        }
    }

    public class Meal
    {
        IIngrediant ingrediant;

        public Meal()
        {
            ingrediant = new BaseIngredientDecorator(
                new Noodles(
                    new Beef(
                        new Water(
                            new NoIngrediant()))));
            ingrediant.AddIngrediant();
        }

        public static class ClientCode
        {
            static void Main()
            {
                new Meal();
            }
        }
    }
