using System;
//Example with pattern Adapter and pattern Strategy

namespace Adapter
{
    public class Human
    {
        public void Eat(IMeal m)
        {
            m.Cook();
        }
    }
    public interface IMeal
    {
        public void Cook() { }
    }
    public interface ICookStrategy
    {
        public void Cook(string name);
    }

    public class BoilMeal : ICookStrategy
    {
        private string Name;

        public void Cook(string name)
        {
            Name = name;
            Console.WriteLine("Boiling " + name);
        }
    }

    public class StirMeal : ICookStrategy
    {
        private string Name;

        public void Cook(string name)
        {
            Name = name;
            Console.WriteLine("Frying " + name);
        }
    }

    public class Dumpling : IMeal
    {
        ICookStrategy Strategy;
        private static int i = 0;
        private string Name;
        public Dumpling(ICookStrategy strategy)
        {
            Strategy = strategy;
            Name = "dumpling " + (i.ToString()) + " - iu";
        }
        public void Cook()
        {
            i++;
            Strategy.Cook(Name);
        }
    }

    public class AdapterRabbitToMeal : IMeal
    {
        private static int number = 1;
        private Rabbit rabbit = new Rabbit("Rabbit " + number++.ToString() + "-th");

        public void Cook()
        {
            rabbit.Prepare();
        }
        public void Cook(string n) { }
    }

    public class Rabbit
    {
        string Name;
        public Rabbit(string n)
        {
            Name = n;
        }
        public void Kill()
        {
            Console.WriteLine("Kill " + Name);
        }
        public void Prepare()
        {
            this.Kill();
            Console.WriteLine("kill, clear and boil. Add to soup");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human Lev = new Human();
            Dumpling dumpling1 = new Dumpling(new BoilMeal());
            Lev.Eat(dumpling1);
            Dumpling dumpling2 = new Dumpling(new BoilMeal());
            Lev.Eat(dumpling2);
            Dumpling dumpling3 = new Dumpling(new StirMeal());
            Lev.Eat(dumpling3);
            AdapterRabbitToMeal rabbitToMeal1 = new AdapterRabbitToMeal();
            AdapterRabbitToMeal rabbitToMeal2 = new AdapterRabbitToMeal();
            AdapterRabbitToMeal rabbitToMeal3 = new AdapterRabbitToMeal();
            Lev.Eat(rabbitToMeal1);
            Lev.Eat(rabbitToMeal2);
            Lev.Eat(rabbitToMeal3);
        }
    }
}
