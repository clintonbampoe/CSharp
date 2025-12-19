
class BossBattle
{
    public static void Run()
    {
        BoardSize size = SetBoardSize();

        Board game = new(size);
        Move move = new(size);

        game.InitializeGame();
        game.Grid = Pit.SetNew(game.Grid, size);
        do
        {
            game.DisplayGameState();
            if (game.GameOver)
                break;

            else
            {
                try
                {
                    game.Command(move);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Message.PrintErrorMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Message.PrintErrorMessage(ex.Message);
                }
            } 
            
        } while (!game.GameOver);

        if (game.GameWon)
            Console.WriteLine("You win");
        else
            Message.PrintErrorMessage("You lost!"); // not an error, just wanted the red text color

    }

    // Classest
    class Board
    {
        // Constructors
        public Board(BoardSize size)
        {
            if (size == BoardSize.Small)
            {
                GridSize = 4;
                BoardSizeType = BoardSize.Small;
            }
            else if (size == BoardSize.Medium)
            {
                GridSize = 6;
                BoardSizeType = BoardSize.Medium;
            }
            else
            {
                GridSize = 8;
                BoardSizeType = BoardSize.Large;
            }

            Grid = new GridState[GridSize, GridSize];
        }



        // properties
        public GridState[,] Grid { get; set; }
        public int GridSize { get; init; }
        public BoardSize BoardSizeType { get; init; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool ActivateFountain { get; private set; }
        public bool GameWon { get; private set; } = false;
        public bool GameOver { get; set; }




        // Methods
        public void InitializeGame()
        {
            SetStartingLocation();
            SetFountainLocation(3, 3);
        }
        public void DisplayGameState()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            DisplayGrid(Grid);
            DisplayPlayerPosition();
            DisplayPlayerHints();
        }

        // Init Game Method Cluster

        void SetFountainLocation(int row, int col)
        {
            Grid[row, col] = GridState.Fountain;
        }
        void SetStartingLocation()
        {
            Row = 0;
            Col = 0;
            Grid[Row, Col] = GridState.Current;
        }

        // Game State Method Cluster
        void DisplayPlayerHints()
        {
            // Entrance message
            if (Row == 0 && Col == 0)
            {
                if (ActivateFountain)
                {
                    Message.PrintFountainMessage("Fountain of objects has been reactivated, and you escaped with your life");
                    GameWon = true;
                    GameOver = true;
                    return;
                }

                else Message.PrintEntranceMessage("You see light in this room coming from outside the cavern. This is the entrance.");
            }

            if (Grid[Row, Col] == GridState.ActiveFountain)
            {
                if (ActivateFountain)
                {
                    Message.PrintFountainMessage("You hear the rushing waters of the fountain of objects. It has been reactivated.");
                }

                else Message.PrintFountainMessage("You hear water dripping in this room. The fountain of objects is here.");
            }
            else if (Grid[Row, Col] == GridState.ActivePit)
            {
                Message.PrintPitMessage("You fell into a Pit");
                GameOver = true;
                return;
            }

            if (Pit.IsCloseBy(Grid, Row, Col))
            {
                Message.PrintPitMessage("You feel a draft. There is a pit in a nearby room. ");
                return;
            }
            
            

            Console.WriteLine("Everything is dark");

        }
        void DisplayPlayerPosition()
        {
            Console.WriteLine($"You are in the room at (Row={Row} Col={Col})");
        }
       
        void DisplayGrid(GridState[,] Grid)
        {
            string line;
            if (BoardSizeType == BoardSize.Small)
                line = "+---+---+---+---+";
            else if (BoardSizeType == BoardSize.Medium)
                line = "+---+---+---+---+---+---+";
            else
                line = "+---+---+---+---+---+---+---+---+";

            for (int col = 0; col < GridSize; col++)
            {
                Console.WriteLine(line);
                for (int row = 0; row < GridSize; row++)
                {
                    string state = " ";
                    if (Grid[row, col] == GridState.Current || Grid[row, col] == GridState.ActiveFountain || Grid[row, col] == GridState.ActivePit)
                    {
                        state = "X";
                        Row = row;
                        Col = col;
                    }
                        

                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{state} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(line);
        }


        // Commands Method Cluster
        bool EnableFountain()
        {
            if (Grid[Row, Col] == GridState.ActiveFountain)
            {
                ActivateFountain = true;
                return true;
            }
            return false;
        }
        
        // Input
        public void Command(Move Move)
        {
            Console.Write("What do you want do? ");
            string input = TakeInput();

            string OutOfBoundsErrorMessage = "Out of Bounds. You cannot move in that direction.";
            string InvalidInputErrorMessage = "Invalid Input";

            if (input.ToLower().Contains("fountain") || input.ToLower().Contains("activate") || input.ToLower().Contains("enable"))
            {
                if (EnableFountain())
                    return;
                else
                    return;
            }
            else if (input.ToLower() == "move north")
            {
                if (Move.North(Grid, Row, Col))
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move south")
            {
                if (Move.South(Grid, Row, Col))
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move east")
            {
                if (Move.East(Grid, Row, Col))
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move west")
            {
                if (Move.West(Grid, Row, Col))
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else
            {
                throw new ArgumentException(InvalidInputErrorMessage);
            }
        }

    }

    class Move
    {
        // Constructors
        public Move(BoardSize size)
        {
            if (size == BoardSize.Small)
                GridSize = 4;
            else if (size == BoardSize.Medium)
                GridSize = 6;
            else
                GridSize = 8;
        }

        // Properties
        public int GridSize { get; init; }

        // Methods
        public bool North(GridState[,] grid, int x, int y)
        {
            int dx = 0;
            int dy = -1;

            return MoveLogic(grid, x, y, dx, dy);

        }

        public bool South(GridState[,] grid, int x, int y)
        {
            int dx = 0;
            int dy = +1;

            return MoveLogic(grid, x, y, dx, dy);

        }
        public bool East(GridState[,] grid, int x, int y)
        {
            int dx = +1;
            int dy = 0;

            return MoveLogic(grid, x, y, dx, dy);
            
        }
        public bool West(GridState[,] grid, int x, int y)
        {
            int dx = -1;
            int dy = 0;

            return MoveLogic(grid, x, y, dx, dy);
            
        }

        

        bool MoveLogic(GridState[,] grid, int x, int y, int dx, int dy)
        {

            // check if move is OutOfBounds
            if (x + dx < 0 || x + dx >= GridSize || y + dy < 0 || y + dy >= GridSize)
            {
                return false;
            }


            // if current cell is a pit
            if (grid[x, y] == GridState.ActivePit)
                grid[x, y] = GridState.Pit;
            else if (grid[x, y] == GridState.Fountain || grid[x, y] == GridState.ActiveFountain)
                grid[x, y] = GridState.Fountain;
            else grid[x, y] = GridState.Empty;


            // Check if move is FountainLocation
            if (grid[x + dx, y + dy] == GridState.Fountain)
            {
                grid[x + dx, y + dy] = GridState.ActiveFountain;
                return true;
            }


            // Check if move results in Pit
            if (grid[x + dx, y + dy] == GridState.Pit)
            {
                grid[x + dx, y + dy] = GridState.ActivePit;
                return true;
            }

            grid[x + dx, y + dy] = GridState.Current;
            return true;
        }

        bool IsActivePit(GridState grid)
        {
            if (grid == GridState.ActivePit)
                return true;

            return false;
        }
    }

    class Message
    {
        // METHODS
        public static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintFountainMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintNarrativeMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void PrintEntranceMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintPitMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Pit()
    {
        // Constructor
        public static GridState[,] SetNew(GridState[,] grid, BoardSize size)
        {
            Random rnd = new Random(DateTime.Now.Second);

            if(size == BoardSize.Small)
            {
                GridBoundary = 4;
                for(int i = 0; i < 3; i++)
                {
                    int XPit1 = rnd.Next(0, 4);
                    int YPit1 = rnd.Next(0, 4);

                    if (grid[XPit1, YPit1] == GridState.Fountain)
                        i--;
                    else if (XPit1 == 0 && YPit1 == 0)
                        i--;
                    else
                    {
                        grid[XPit1, YPit1] = GridState.Pit;
                    }

                }
                
            }

            else if(size == BoardSize.Medium)
            {
                GridBoundary = 6;
                for(int i = 0; i < 5; i++)
                {
                    int XPit1 = rnd.Next(0, 6);
                    int YPit1 = rnd.Next(0, 6);

                    if (grid[XPit1, YPit1] == GridState.Fountain)
                        i--;
                    else if (XPit1 == 0 && YPit1 == 0)
                        i--;
                    else
                    {
                        grid[XPit1, YPit1] = GridState.Pit;
                    }

                }
                
            }

            else if(size == BoardSize.Large)
            {
                GridBoundary = 8;
                for(int i = 0; i < 10; i++)
                {
                    int XPit1 = rnd.Next(0, 8);
                    int YPit1 = rnd.Next(0, 8);

                    if (grid[XPit1, YPit1] == GridState.Fountain)
                        i--;
                    else if (XPit1 == 0 && YPit1 == 0)
                        i--;
                    else
                    {
                        grid[XPit1, YPit1] = GridState.Pit;
                    }

                }
                
            }

            return grid;
        }

        // Properties
        public static int GridBoundary { get; private set; }
        public static bool IsCloseBy(GridState[,] grid, int x, int y)
        {
            bool isClose = false;

            // all four cardinal points
            if(!(y - 1 < 0))
            {
                if (North(grid, x, y))
                    isClose = true;
            }
                
            if (!(y + 1 >= GridBoundary))
            {
                if(South(grid, x, y))
                    isClose = true;
            }
            if (!(x - 1 < 0))
            {
                if (West(grid, x, y))
                    isClose = true;
            }
            if (!(x + 1 >= GridBoundary))
            {
                if (East(grid, x, y))
                    isClose = true;
            }

            return isClose;

            // MINI METHODS
            bool North(GridState[,] grid, int x, int y)
            {
                int dy = -1;
                return (grid[x, y + dy] == GridState.Pit);
            }

            bool South(GridState[,] grid, int x, int y)
            {
                int dy = +1;
                return (grid[x, y + dy] == GridState.Pit);
            }

            bool East(GridState[,] grid, int x, int y )
            {
                int dx = +1;
                return (grid[x + dx, y] == GridState.Pit);
            }
            
            bool West(GridState[,] grid, int x, int y)
            {
                int dx = -1;
                return (grid[x + dx, y] == GridState.Pit);
            }
        }
    }


    // Helper Methods
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine() ?? "";
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }
    static BoardSize SetBoardSize()
    {
        Console.WriteLine("Choose board size");
        Console.WriteLine("1. Small (4 * 4)");
        Console.WriteLine("2. Medium (6 * 6)");
        Console.WriteLine("3. Large (8 * 8)");

        do
        {
            Console.Write($"Input> ");
            string input = TakeInput();

            switch (input.ToLower())
            {
                case "1":
                case "small":
                    return BoardSize.Small;

                case "2":
                case "medium":
                    return BoardSize.Medium;

                case "3":
                case "large":
                    return BoardSize.Large;

                default:
                    Console.WriteLine("Invalid Input! Try Again!");
                    break;
            }

        } while (true);

    }

    // Enums
    enum GridState { Empty, Current, Fountain, Pit, ActiveFountain, ActivePit }
    enum BoardSize { Small, Medium, Large}
}