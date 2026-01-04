// GUESSING PROGRAM
namespace hello_world {
    public class guessingProgram {
        public static void main(String[] args) {
            // LOCATION PROGRAM

            Console.Write("User 1, Enter a number between 0 and 100: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string inputUser1 = Console.ReadLine();
            int number = Convert.ToInt32(inputUser1);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("User 2, guess the number. ");

            do {
                Console.Write("What is your next guess? ");
                Console.ForegroundColor = ConsoleColor.Green;
                string inputUser2 = Console.ReadLine();
                int guess = Convert.ToInt32(inputUser2);
                Console.ForegroundColor = ConsoleColor.White;

                if (guess < number) {
                    Console.WriteLine($"{guess} is too low.");
                    continue;
                }
                else if (guess > number) {
                    Console.WriteLine($"{guess} is too high.");
                    continue;
                }
                else if (guess == number) {
                    Console.WriteLine("You guessed right!!");
                    break;
                }

            } while (true);
        }
    }
}