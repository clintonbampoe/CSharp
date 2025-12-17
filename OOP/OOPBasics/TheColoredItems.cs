class TheColoredItems
{
    public static void Run()
    {
        Sword newSword = new();
        ColoredItem<Sword> blueSword = new(newSword, ConsoleColor.Blue);
        blueSword.Display();

        Bow newBow = new();
        ColoredItem<Bow> redBow = new(newBow, ConsoleColor.Red);
        redBow.Display();

        Axe newAxe = new();
        ColoredItem<Axe> greenAxe = new(newAxe, ConsoleColor.Green);
        greenAxe.Display();
    }



    public class Sword 
    {
        public override string ToString() => "Sword";
    }
    public class Bow
    {
        public override string ToString() => "Bow";
    }
    public class Axe
    {
        public override string ToString() => "Arrow";
    }

    class ColoredItem<T>(T item, ConsoleColor color)
    {
        public ConsoleColor Color { get; } = color;
        public T Item { get; } = item;

        public void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Item?.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    }