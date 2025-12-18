

using System.Linq.Expressions;

class BossBattle
{
    public static void Run()
    {
        Board game = new Board();
        game.InitializeGame();
        do
        {
            game.DisplayGameState();
            try
            {
                game.Command();
            }
            catch (IndexOutOfRangeException ex)
            {
                Message.PrintErrorMessage(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Message.PrintErrorMessage(ex.Message);
            }
            game.CheckGameOver();
            
        } while (!game.GameOver);
        Console.WriteLine("You win!");

    }

    // Classest
    class Board
    {
        // Constructors
        public Board()
        {
            Grid = new GridState[4, 4];
        }


        // properties
        public GridState[,] Grid { get; set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool ActivateFountain { get; private set; }
        public bool GameOver { get; private set; }




        // Methods
        public void InitializeGame()
        {
            SetStartingLocation();
            SetFountainLocation(0, 2);
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
            Grid[row, col] = GridState.F;
        }
        void SetStartingLocation()
        {
            Row = 0;
            Col = 0;
            Grid[Row, Col] = GridState.X;
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
                    return;
                }

                Message.PrintEntranceMessage("You see light in this room coming from outside the cavern. This is the entrance.");
            }
            if (Grid[Row, Col] == GridState.F)
            {
                if (ActivateFountain)
                {
                    Message.PrintFountainMessage("You hear the rushing waters of the fountain of objects. It has been reactivated.");
                    return;
                }

                Message.PrintFountainMessage("You hear water dripping in this room. The fountain of objects is here.");
            }

            Console.WriteLine("Everything is dark");

        }
        void DisplayPlayerPosition()
        {
            Console.WriteLine($"You are in the room at (Row={Row} Col={Col})");
        }
        void DisplayGrid(GridState[,] Grid)
        {
            string line = "+---+---+---+---+";

            for (int col = 0; col < 4; col++)
            {
                Console.WriteLine(line);
                for (int row = 0; row < 4; row++)
                {
                    
                    string state = (row == Row && col == Col) ? "X" : " ";

                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{state} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(line);
        }

        public void CheckGameOver()
        {
            if (ActivateFountain)
            {
                if (Row == 0 && Col == 0)
                {
                    GameOver = true;
                    return;
                }
            }
        }

        // Commands Method Cluster
        bool EnableFountain()
        {
            if (Grid[Row, Col] == GridState.F)
            {
                ActivateFountain = true;
                return true;
            }
            return false;
        }
        public bool MoveNorth()
        {
            if (Col - 1 < 0)
            {
                return false;
            }

            Grid[Row, Col] = GridState.O;
            if (Grid[Row, Col - 1] == GridState.F)
            {
                Col--;
                return true;
            }

            Grid[Row, --Col] = GridState.X;
            return true;
        }
        public bool MoveSouth()
        {
            if (Col + 1 > 4)
            {
                return false;
            }

            Grid[Row, Col] = GridState.O;
            if (Grid[Row, Col + 1] == GridState.F)
            {
                Col++;
                return true;
            }

            Grid[Row, ++Col] = GridState.X;
            return true;
        }
        public bool MoveEast()
        {
            if (Row + 1 > 4)
            {
                return false;
            }

            Grid[Row, Col] = GridState.O;
            if (Grid[Row + 1, Col] == GridState.F)
            {
                Row++;
                return true;
            }

            Grid[++Row, Col] = GridState.X;
            return true;
        }
        public bool MoveWest()
        {
            if (Row - 1 < 0)
            {
                return false;
            }

            Grid[Row, Col] = GridState.O;
            if (Grid[Row - 1, Col] == GridState.F)
            {
                Row--;
                return true;
            }

            Grid[--Row, Col] = GridState.X;
            return true;
        }
        // Input
        public void Command()
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
                if (MoveNorth())
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move south")
            {
                if (MoveSouth())
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move east")
            {
                if (MoveEast())
                    return;
                else
                    throw new IndexOutOfRangeException(OutOfBoundsErrorMessage);
            }
            else if (input.ToLower() == "move west")
            {
                if (MoveWest())
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
    }


    // Methods
    static bool IsFountain(GridState[,] Grid, int row, int col)
    {
        if (Grid[row, col] == GridState.F)
        {
            return true;
        }

        return false;
    }

    // Helper Methods
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string? input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }
    

    // Enums
    enum GridState { O, X, F }
}