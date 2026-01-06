using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConcepts
{
    class L35_ErrorHandling
    {
        public static void Run()
        {
            Game newGame = new();
            newGame.Run();
        }

        class Game
        {
            public int Cookie { get; private set; }
            public List<int> History { get; private set; } = [];


            class Player
            {
                // Constructors
                public Player(string name)
                {
                    Name = name;
                }

                // Properties
                public Outcome Result { get; set; }
                public string Name { get; init; }

                // Methods
                public int PickCookie()
                {
                    while (true)
                    {
                        Console.WriteLine("Enter: ");
                        Console.Write(">>>");
                        string input = Method.Input.Take();

                        if (int.TryParse(input, out int number))
                        {
                            return number;
                        }
                        else
                        {
                            Method.Print.RedText("Invalid Input!");
                        }
                    }
                }

                // Enums
                public enum Outcome { Win, Lose}
            }

            public void InitGame()
            {
                Random rnd = new();
                Cookie = rnd.Next(0, 10);
            }
            public void Run()
            {
                InitGame();

                Player player1 = new("Player 1");
                Player player2 = new("Player 2");
                
                Greeting();
                Method.Input.WaitForKeyPress();

                bool gameOver = false;
                do
                {
                    if(History.Count >= 10)
                    {
                        gameOver = true;
                    }
                    else
                    {
                        PlayerPick(player1, ref gameOver);                        

                        // check game state 
                        if (gameOver)
                            break;

                        PlayerPick(player2, ref gameOver);
                    }
                } while (!gameOver);

                if (player1.Result == Player.Outcome.Lose)
                {
                    Console.Clear();
                    Method.Formatting.HorizontalLine(20);
                    Console.WriteLine("GAME OVER!!!");
                    Method.Print.GreenText("Congratulations Player 2, You Win");
                }
                else
                {
                    Method.Formatting.HorizontalLine(20);
                    Console.WriteLine("GAME OVER!!!");
                    Method.Print.GreenText("Congratulations Player 1, You Win");
                }


            }

            public static void Greeting()
            {
                Method.Formatting.HorizontalLine(20);
                Console.WriteLine("WELCOME!!!");

                Console.WriteLine("The Raisin Has been planted!");
                Console.WriteLine("Whoever picks 'The Raisin' out of 10 cookies, loses");
                Console.WriteLine("HAVE FUN");
            }

            void PlayerPick(Player player,ref bool gameOver)
            {
                bool runAgain = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Your Turn, {player.Name}");
                    Console.WriteLine("Pick your cookie");
                    int playerChoice = player.PickCookie();
                    try
                    {
                        if (History.Contains(playerChoice))
                        {
                            throw new InvalidOperationException("This number has already been picked");
                        }
                        else if (playerChoice == Cookie)
                        {

                            Method.Print.RedText($"Cookie Number : {playerChoice} was 'THE RAISIN'");
                            Method.Print.RedText("GAMEOVER!!!");
                            gameOver = true;
                            player.Result = Player.Outcome.Lose;
                            runAgain = false;
                        }
                        else
                        {
                            Method.Print.GreenText("Lucky you");
                            Method.Print.GreenText($"Cookie Number: {playerChoice} was not 'THE RAISIN'");
                            History.Add(playerChoice);
                            Console.WriteLine("Game Continues...");
                            runAgain = false;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Method.Print.RedText(ex.Message);
                        runAgain = true;
                        Method.Input.WaitForKeyPress();
                    }
                } while (runAgain);
                
                Method.Input.WaitForKeyPress();
            }
        }

        
    }
}

