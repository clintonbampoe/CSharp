class TheOldRobot
{
    public static void Run()
    {
        // Program Start
        ProgramGreeting();
        Robot newRobot = CreateNewRobot();
        TakeCommands(newRobot);

        newRobot.Run();

    }

    // Base Classes
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();

        public void Run()
        {
            foreach (IRobotCommand command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }

    public interface IRobotCommand
    {
        void Run(Robot robot);
    }

    // Helper Methods
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine() ?? "";
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }

    // Power Commands
    public class OnCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            robot.IsPowered = true;
        }
    }

    public class OffCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            robot.IsPowered = false;
        }
    }


    // Movement Commands
    public class NorthCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 0;
                robot.Y += 1;
            }
        }
    }

    public class SouthCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 0;
                robot.Y -= 1;
            }
        }
    }

    public class EastCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 1;
                robot.Y += 0;
            }
        }
    }

    public class WestCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X -= 1;
                robot.Y += 0;
            }
        }
    }

    // program greeting
    public static void ProgramGreeting()
    {
        Console.Title = "The Old Robot";
        for (int i = 0; i < 80; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        Console.WriteLine("THE OLD ROBOT");
        Console.WriteLine();

    }

    public static Robot CreateNewRobot()
    {
         return new Robot();
    }

    public static void TakeCommands(Robot robot)
    {
        Console.WriteLine("Enter Commands");
        Console.WriteLine("Enter 'stop' after all commands.");
        bool stop = false;
        do
        {

            bool tryAgain;
            do
            {
                Console.Write($"{"> ",4}");
                string input = TakeInput();

                tryAgain = false;

                switch (input.ToLower())
                {
                    // STATE COMMANDS
                    case "stop":
                        stop = true;
                        break;

                    // POWER COMMANDS
                    case "on":
                        OnCommand on = new();
                        robot.Commands.Add(on);
                        break;

                    case "off":
                        OffCommand off = new();
                        robot.Commands.Add(off);
                        break;


                    // MOVEMENT COMMANDS
                    case "north":
                        NorthCommand north = new();
                        robot.Commands.Add(north);
                        break;

                    case "south":
                        SouthCommand south = new();
                        robot.Commands.Add(south);
                        break;

                    case "east":
                        EastCommand east = new();
                        robot.Commands.Add(east);
                        break;

                    case "west":
                        WestCommand west = new();
                        robot.Commands.Add(west);
                        break;

                    default:
                        Console.WriteLine("Wrong Command!");
                        Console.WriteLine("Try Again!");
                        tryAgain = true;
                        break;
                }

            } while (tryAgain);
        } while (!stop);
    }

}