using AdvancedConcepts;
class L36_Delegates
{
    public static void Run()
    {
        Console.WriteLine("Pick a Sieve");
        Console.WriteLine("\t e - Even Number");
        Console.WriteLine("\t p - Positive Number");
        Console.WriteLine("\t m - Multiple of 10");

        Console.WriteLine("Enter");
        Console.Write(">>>");
        string input = Method.Input.Take();
        while(input != "e" &&  input != "p" && input != "m")
        {
            Method.Print.RedText("Invalid Input!!!");
            Method.Print.RedText("Try Again");

            input = Method.Input.Take();
        }

        Func<int, bool> SieveNumber;
        if (input == "e")
            SieveNumber = IsEven;
        else if (input == "p")
            SieveNumber = IsPositive;
        else
            SieveNumber = IsMultipleOfTen;

        Sieve sieve = new(SieveNumber);
        bool quit = false;
        do
        {
            Console.WriteLine("Enter a number");
            Console.Write(">>>");
            string userInput = Method.Input.Take();

            int number;
            while (!(int.TryParse(userInput ,out number)))
            {
                Method.Print.RedText("Invalid Input");
                Console.WriteLine("Enter a number");
                Console.Write(">>>");

                userInput = Method.Input.Take();
            }

            Console.WriteLine($"Result: {sieve.IsGood(number)}");

            Console.WriteLine("Press Enter to proceed or 'q' to quit...");
            Console.WriteLine();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Q)
                quit = true;
        } while (!quit);

    }

    class Sieve
    {
        Func<int, bool> SieveNumber;
        public Sieve(Func<int, bool> sieveNumber) 
        {
            SieveNumber = sieveNumber;
        }

        public bool IsGood(int number)
        {
            return SieveNumber(number);
        }
    }

    static bool IsEven(int number)
    {
        if (number % 2 == 0)
            return true;
        else 
            return false;
    }

    static bool IsPositive(int number)
    {
        if(number >= 0)
            return true;
        else 
            return false;
    }
    
    static bool IsMultipleOfTen(int number)
    {
        if(number % 10  == 0)
            return true;
        else
            return false;
    }
}