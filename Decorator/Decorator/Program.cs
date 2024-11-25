using System;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            Component tree = new ChristmasTree();

            DecorationsDecorator decorations = new DecorationsDecorator();
            GarlandDecorator garland = new GarlandDecorator();

            decorations.SetComponent(tree);

            decorations.AddDecoration("Кулі та дощик");
            decorations.AddDecoration("Сніжинки");

            garland.SetComponent(decorations);

            garland.Operation();

            Console.ReadLine();
        }
    }

    // "Component" — базовий клас для дерева
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent" —  ялинка
    class ChristmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка");
        }
    }

    // "Decorator" — базовий клас для декораторів
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA" — декоратор для прикрас
    class DecorationsDecorator : Decorator
    {
        private readonly System.Collections.Generic.List<string> _decorations = new();

        public void AddDecoration(string decoration)
        {
            _decorations.Add(decoration);
        }

        public override void Operation()
        {
            base.Operation();
            ShowDecorations();
        }

        private void ShowDecorations()
        {
            foreach (var decoration in _decorations)
            {
                Console.WriteLine($"Додано прикрасу: {decoration}");
            }
        }
    }

    // "ConcreteDecoratorB" — декоратор для гірлянд
    class GarlandDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddGarland();
        }

        private void AddGarland()
        {
            Console.WriteLine("Ялинка світиться завдяки гірляндам!");
        }
    }
}
