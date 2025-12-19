class L24CatacombsOfTheClass 
{
    public static void Run () 
    {
        Console.Title = "PASSWORD VALIDATOR";
        for(int i = 90;  i < 90; i++)
        {
            Console.Write("-");
        }
        do
        {
            Console.WriteLine();
            Console.Write("Enter your password: ");
            string input = TakeInput();
            PasswordValidator validator = new(input);

            if (validator.IsValid)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        } while (true);
        
    }

    // Utility Methods
    // This method helps differentiate user input from console output
    // Method2: TakeInput
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine() ?? "";
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }



    // CLASSES
    // class1: POINT
    class Point
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }


        // Constructors
        public Point(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public Point()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }



    // class2: COLOR
    class Color
    {

        // PROPERTIES
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }


        // CONSTRUCTOR
        public Color(int red, int green, int blue)
        {
            R = red;
            G = green;
            B = blue;
        }

        // FACTORY COLORS
        public static Color White()
        {
            return new Color(255, 255, 255);
        }

        public static Color Black()
        {
            return new Color(0, 0, 0);
        }

        public static Color Red()
        {
            return new Color(255, 0, 0);
        }

        public static Color Orange()
        {
            return new Color(255, 165, 0);
        }

        public static Color Yellow()
        {
            return new Color(255, 255, 0);
        }

        public static Color Green()
        {
            return new Color(0, 128, 0);
        }

        public static Color Blue()
        {
            return new Color(0, 0, 255);
        }

        public static Color Purple()
        {
            return new Color(128, 0, 128);
        }
    }


    // class3: THE CARD
    class Card
    {

        public CardColor Color { get; }
        public CardRank Rank { get; }

        // checks if card is a number or symbol card
        public bool IsNumberCard => Rank >= CardRank.One && Rank <= CardRank.Ten;
        public bool IsSymbolCard => !IsNumberCard;


        // Constructor
        public Card(CardColor cardColor, CardRank cardRank)
        {
            Color = cardColor;
            Rank = cardRank;
        }



        public enum CardColor { Red, Green, Blue, Yellow }
        public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }
    }


    // class4: THE LOCKED DOOR
    class Door
    {
        // PROPERTIES
        public int PassCode { get; private set; }
        public DoorState State { get; private set; }


        // CONSTRUCTOR
        public Door(int passCode)
        {
            PassCode = passCode;
            State = DoorState.Locked;
        }


        // METHODS
        // DoorStateMechanisms
        static DoorState LockDoor() => DoorState.Locked;
        static DoorState UnlockDoor() => DoorState.Closed;
        static DoorState OpenDoor() => DoorState.Open;
        static DoorState CloseDoor() => DoorState.Closed;


        // Change Door State
        public void ChangeDoorState()
        {
            Console.WriteLine();
            Console.WriteLine($"The Door is {State}");

            if (State == DoorState.Locked)
            {
                Console.Write("Enter passcode to unlock door: ");
                do
                {
                    int input = Convert.ToInt32(TakeInput());

                    if (input == PassCode)
                    {
                        State = DoorState.Closed;
                        Console.WriteLine("Door has been unlocked.");
                        return;
                    }
                    else
                        Console.WriteLine("Wrong passcode! Try again.");
                    
                } while (true);
                
            }

            else if (State == DoorState.Closed)
            {
                Console.WriteLine("Enter: ");
                Console.WriteLine("1: to open door");
                Console.WriteLine("2: to lock door");

                do
                {
                    string input = TakeInput();
                    if (input == "1")
                    {
                        State = DoorState.Open;
                        Console.WriteLine("Door has been opened");
                        return;
                    }
                    else if (input == "2")
                    {
                        State = DoorState.Locked;
                        Console.WriteLine("Door has been locked");
                        return;
                    }
                    else
                        Console.WriteLine("Wrong Input! Try again.");

                } while (true);
                
            }

            else if (State == DoorState.Open)
            {
                Console.Write("Enter 1 to close door: ");
                do
                {
                    string input = TakeInput();

                    if (input == "1")
                    {
                        State = DoorState.Closed;
                        Console.WriteLine("Door has been closed");
                        return;
                    }
                    else
                        Console.WriteLine("Wrong Input! Try again");

                } while (true);
            }
        }


        // Change Pass Code
        public void ChangePassCode()
        {
            Console.WriteLine();
            Console.WriteLine("CHANGE PASSCODE");
            Console.Write("Enter current passcode: ");

            do
            {
                int input = Convert.ToInt32(TakeInput());

                if (input == PassCode)
                {
                    Console.Write("Enter new passcode: ");
                    int newPasscode = Convert.ToInt32(TakeInput());
                    PassCode = newPasscode;

                    Console.WriteLine("The passcode has been changed succesfully");
                    return;
                }
                else
                    Console.WriteLine("Wrong Passcode! Try Again");

            } while (true);
        }

        // ENUM
        public enum DoorState { Locked, Closed, Open}
    }


    // class5: THE PASSWORD VALIDATOR
    class PasswordValidator
    {

        // properties
        public bool IsValid { get; private set; } = false;

        // Constructor
        public PasswordValidator(string password)
        {
            bool upperCasePresent = false;
            bool lowerCasePresent = false;
            bool digitPresent = false;

            if (password.Length >= 6 && password.Length <= 13)
            {
                // iterate through string and checks which of the requirements are met
                foreach (char ch in password)
                {
                    if (ch == '&' || ch == 'T')
                    {
                        IsValid = false;
                        return;
                    }
                    else
                    {
                        if (char.IsUpper(ch))
                        {
                            upperCasePresent = true;
                        }
                        else if (char.IsLower(ch))
                        {
                            lowerCasePresent = true;
                        }
                        else if (char.IsDigit(ch))
                        {
                            digitPresent = true;
                        }
                    }
                } 
            }

            //
            if (upperCasePresent && lowerCasePresent && digitPresent)
            {
                IsValid = true;
                return;
            }

        }
    }
}
