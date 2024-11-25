/*програма що демонструє приготування кави за допомогою шаблону Facade. 
Відбувається взаємодія кількох підсистем
 (нагрівання води, перемелювання кавових зерен, заварювання кави) через єдиний інтерфейс фасаду.*/
using System;

namespace FacadeDemo
{
    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();

            // Use the Facade to make coffee
            coffeeMachine.MakeCoffee();

            Console.ReadLine();
        }
    }
    // Subsystem 1: Water Heater
    class WaterHeater
    {
        public void HeatWater()
        {
            Console.WriteLine("Heating water");
        }

        public void StopHeating()
        {
            Console.WriteLine("Water heating stopped.");
        }
    }

    // Subsystem 2: Coffee Grinder
    class CoffeeGrinder
    {
        public void GrindBeans()
        {
            Console.WriteLine("Grinding coffee beans");
        }
    }

    // Subsystem 3: Brewer
    class Brewer
    {
        public void BrewCoffee()
        {
            Console.WriteLine("Brewing coffee");
        }
    }

    // Facade: CoffeeMachine
    class CoffeeMachine
    {
        private readonly WaterHeater _waterHeater;
        private readonly CoffeeGrinder _coffeeGrinder;
        private readonly Brewer _brewer;

        public CoffeeMachine()
        {
            _waterHeater = new WaterHeater();
            _coffeeGrinder = new CoffeeGrinder();
            _brewer = new Brewer();
        }

        public void MakeCoffee()
        {
            Console.WriteLine("Starting coffee-making process\n");
            _coffeeGrinder.GrindBeans();
            _waterHeater.HeatWater();
            _brewer.BrewCoffee();
            _waterHeater.StopHeating();
            Console.WriteLine("\nCoffee is ready! Enjoy your drink.");
        }
    }
}

