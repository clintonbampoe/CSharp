class RoomCoordinates
{
    public static void Run()
    {
        Console.Title = "Room Coordinates";
        for (int i = 0; i < 10; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();


        // First Coordinates
        Console.WriteLine("Enter first Coordinates (X, Y) ");
        Console.Write($"{"> ",4}");
        int x = Convert.ToInt32(TakeInput());

        Console.Write($"{"> ",4}");
        int y = Convert.ToInt32(TakeInput());
        Console.WriteLine($"Coordinates: ({x}, {y})");

        Coordinate c1 = new(x, y);


        // Second Coordinates
        Console.WriteLine();
        Console.WriteLine("Enter second Coordinates (X, Y)");
        Console.Write($"{"> ",4}");
        x = Convert.ToInt32(TakeInput());

        Console.Write($"{"> ",4}");
        y = Convert.ToInt32(TakeInput());
        Console.WriteLine($"Coordinates: ({x} {y})");

        Coordinate c2 = new(x, y);


        // LOGIC
        bool Adjacent = AreAdjacent(c1, c2);
        if (Adjacent)
        {
            Console.WriteLine($"Coordinates are Adjacent!");
        }
        else
        {
            Console.WriteLine("Coordinates are not Adjacent!");
        }

    }

    public struct Coordinate
    {

        public Coordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; }
        public int Col { get; }
    }

    public static bool AreAdjacent(Coordinate c1, Coordinate c2)
    {
        int dx = Math.Abs(c1.Row - c2.Row);
        int dy = Math.Abs(c1.Col - c2.Col);

        if (dx + dy == 1)
        {
            return true;
        }

        return false;
    }

    // helper methods
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string? input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }
}