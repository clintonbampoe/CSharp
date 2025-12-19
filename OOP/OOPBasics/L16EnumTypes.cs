
class L16EnumTypes {
    public static void Run() {
        // PROGRAM START
        Chest currentState = Chest.locked;
        string inputAction = "0";

        while (true) {
            // display state of variable
            L16EnumTypes.DisplayState(currentState);

            // take input
            Console.Write("What do you want to do? ");
            inputAction = TakeInput();

            // make an action
            MakeAction();
        }
        


        // Put this here because variable references would have been out of scope. And I don't know how to use pointers yet
        // Method3: Make Action
        void MakeAction() {

            // locked
            if (currentState == Chest.locked) {
                if (inputAction == "unlock") {
                    currentState = Chest.closed;
                }
                else {
                    Console.WriteLine("Cannot perform action. Try Again!");
                }
            }

            // closed
            else if (currentState == Chest.closed) {
                if (inputAction == "open") {
                    currentState = Chest.open;
                }
                else if (inputAction == "lock") {
                    currentState = Chest.locked;
                }
                else {
                    Console.WriteLine("Cannot perform action. Try Again!");
                }
            }

            // open
            else if (currentState == Chest.open) {
                if (inputAction == "close") {
                    currentState = Chest.closed;
                }
                else {
                    Console.WriteLine("Cannot perform action. Try Again!");
                }
            }
        }
    }

    // METHODS
    // Method1: DisplayState
    static void DisplayState(Chest currentState) {
        if (currentState == Chest.locked) {
            Console.Write($"The chest is locked. ");
        }
        else if (currentState == Chest.closed) {
            Console.Write($"The chest is unlocked. ");
        }
        else if (currentState == Chest.open) {
            Console.Write($"The chest is open. ");
        }
    }

    // Method2: TakeInput
    static string TakeInput() {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine() ?? "";
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }

}

enum Chest { locked, closed, open}
