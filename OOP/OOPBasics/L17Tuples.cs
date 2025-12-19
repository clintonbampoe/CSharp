class L17Tuples {
    public static void Run() {
        // CODE START

        (Type food, MainIngredient ingredient, Seasoning season) dish;

        // foodType
        L17Tuples.DisplayFoodType();
        dish.food = ChooseFoodType();

        // mainIngredient
        L17Tuples.DisplayMainIngredient();
        dish.ingredient = ChooseMainIngredient();

        // seasoning
        L17Tuples.DisplaySeasoning();
        dish.season = ChooseSeasoning();

        // displayFinalResult
        Console.WriteLine($"{dish.season} {dish.ingredient} {dish.food}");
    }



    // METHODS
    // Method0: TakeInput
    static string TakeInput() {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine() ?? "";
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }


    // Method1: DisplayFoodType
    static void DisplayFoodType() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("FOOD TYPES");
        Console.WriteLine("- Soup");
        Console.WriteLine("- Stew");
        Console.WriteLine("- Gumbo");
    }


    // Method2: DisplayMainIngredient
    static void DisplayMainIngredient() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("- Mushroom");
        Console.WriteLine("- Chicken");
        Console.WriteLine("- Carrot");
        Console.WriteLine("- Potato");
    }


    // Method3: DisplaySeasoning
    static void DisplaySeasoning() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("- Spicy");
        Console.WriteLine("- Sweet");
        Console.WriteLine("- Salty");
    }


    // Method4: ChooseFoodType
    static Type ChooseFoodType() {
        do {
            Console.Write("Choose the food type: ");
            string input = TakeInput();

            switch (input) {
                case "Soup":
                case "soup":
                    return Type.Soup;

                case "Stew":
                case "stew":
                    return Type.Stew;

                case "Gumbo":
                case "gumbo":
                    return Type.Gumbo;
            }
        } while (true);
    }


    // Method5: ChooseMainIngredient
    static MainIngredient ChooseMainIngredient() {
        do {
            Console.Write("Choose main ingredient: ");
            string input = TakeInput();

            switch (input) {
                case "Mushroom":
                case "mushroom":
                    return MainIngredient.Mushroom;

                case "Chicken":
                case "chicken":
                    return MainIngredient.Chicken;

                case "Carrot":
                case "carrot":
                    return MainIngredient.Carrot;

                case "Potato":
                case "potato":
                    return MainIngredient.Potato;
            }
        } while (true);
    }


    // Method6: ChooseSeasoning
    static Seasoning ChooseSeasoning() {
        do {
            Console.Write("Choose the seasoning: ");
            string input = TakeInput();

            switch (input) {
                case "Spicy":
                case "spicy":
                    return Seasoning.Spicy;

                case "Sweet":
                case "sweet":
                    return Seasoning.Sweet;

                case "Salty":
                case "salty":
                    return Seasoning.Salty;
            }
        } while (true);
    }


    // ENUM DECLARATION
    enum Type { Soup, Stew, Gumbo }
    enum MainIngredient { Mushroom, Chicken, Carrot, Potato }
    enum Seasoning { Spicy, Sweet, Salty }
}