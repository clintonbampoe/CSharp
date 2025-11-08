class L24CatacombsOfTheClass {
    public static void Run() {

        Point point2 = new(2, 3);
        Point point3 = new(-4, 0);

        Console.WriteLine($"({point2.XCoordinate}, {point2.YCoordinate}");
        Console.WriteLine($"({point3.XCoordinate}, {point3.YCoordinate}");
        
    }

    class Point {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }


        // Constructors
        public Point(int xCoordinate, int yCoordinate) {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public Point() {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }
}