class L18Classes {
    public static void Run() {
        // Console Title
        Console.Title = "Vin Fletching's Arrows";

        // create new instance for arrow
        Arrow newArrow = new();

        // Program greeting
        WelcomeMessage();

        // ARROW HEAD
        DisplayArrowHead();
        newArrow._head = PickArrowHead();

        // ARROW FLETCHING
        DisplayArrowFletching();
        newArrow._fletching = PickArrowFletching();

        // SHAFT LENGTH
        DisplayArrowShaft();
        newArrow._shaft = PickArrowShaft();

        // GET COST
        float arrowCost = GetCost(newArrow._head, newArrow._fletching, newArrow._shaft);

        Console.WriteLine($"The arrow costs {arrowCost} gold");
    }
    
    class Arrow {
        public ArrowHead _head;
        public ArrowFletching _fletching;
        public int _shaft;
        
        // class constructor1
        public Arrow() {
            _head = ArrowHead.Steel;
            _fletching = ArrowFletching.Plastic;
            _shaft = 60;
        }

        // class constructor2
        public Arrow(ArrowHead head, ArrowFletching fletching, int shaft) {
            _head = head;
            _fletching = fletching;
            _shaft = shaft;
        }
    }


    // METHODS 
    // Method00: TakeInput
    static string TakeInput() {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }


    // Method: Welcome Message
    static void WelcomeMessage() {
        Console.WriteLine("WELCOME, TO VIN FLETCHER'S ARROWS");
    }


    // ARROW HEAD
    // Method1: DisplayArrowHead
    static void DisplayArrowHead() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("ARROW HEAD TYPES");
        Console.WriteLine("- Steel");
        Console.WriteLine("- Wood");
        Console.WriteLine("- Obsidian");
    }

    // Method2: PickArrowHead
    static ArrowHead PickArrowHead() {
        do {
            Console.Write("Choose the arrow head: ");
            string input = TakeInput().ToLower();

            switch (input) {
                case "steel":
                    return ArrowHead.Steel;

                case "wood":
                    return ArrowHead.Wood;

                case "obsidian":
                    return ArrowHead.Obsidian;
            }
        } while (true);
    }


    // ARROW FLETCHING
    // Method3: DisplayArrowFletching
    static void DisplayArrowFletching() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("ARROW FLETCHING TYPES");
        Console.WriteLine("- Plastic");
        Console.WriteLine("- Turkey Feathers");
        Console.WriteLine("- Goose Feathers");
    }

    // Method4 PickArrowFletching
    static ArrowFletching PickArrowFletching() {
        Console.Write("Choose the arrow fletching: ");
        string input = TakeInput().ToLower();
        do {
            switch (input) {
                case "plastic":
                    return ArrowFletching.Plastic;

                case "turkey feathers":
                    return ArrowFletching.TurkeyFeathers;

                case "goose feathers":
                    return ArrowFletching.GooseFeathers;
            }
        } while (true); 
    }


    // ARROWSHAFT
    // Method5: DisplayArrowShaft
    static void DisplayArrowShaft() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n");
        Console.WriteLine("Choose the length of your shaft. ");
        Console.WriteLine("Should be between 60 and 100 cm");
    }

    // Method6: ChooseArrowShaft
    static int PickArrowShaft() {
        do {
            Console.Write("Enter the length of your shaft: ");
            int input = Convert.ToInt32(TakeInput());

            if (input >= 60 && input <= 100) {
                return input;
            }
        } while (true);
    }


    // Method7: GetCost
    static float GetCost(ArrowHead head, ArrowFletching fletching, int shaft) {
        float cost = 0.0f;

        // get arrow head cost
        cost += ArrowHeadCost(head);

        // get arrow fletching cost
        cost += ArrowFletchingCost(fletching);

        // get arrow shaft cost
        cost += ArrowShaftCost(shaft);

        return cost;
        
    }

    // Method8: ArrowHeadCost
    static float ArrowHeadCost(ArrowHead head) {
        // ARROW HEAD COST
        if (head == ArrowHead.Steel) {
            return 10;
        }
        else if (head == ArrowHead.Wood) {
            return 3;
        }
        else if (head == ArrowHead.Obsidian) {
            return 5;
        }
        else
            return 0;
    }

    // Method9: ArrowFletching Cost
    static float ArrowFletchingCost(ArrowFletching fletching) {
        if (fletching == ArrowFletching.Plastic) {
            return 10;
        }
        else if (fletching == ArrowFletching.TurkeyFeathers) {
            return 5;
        }
        else if (fletching == ArrowFletching.GooseFeathers) {
            return 3;
        }
        else
            return 0;
    }

    // Method10: ArrowShaftCost
    static float ArrowShaftCost(float shaft) {
        return (shaft * 0.05f);
    }

}
// ENUMS
enum ArrowHead { Steel, Wood, Obsidian}
enum ArrowFletching { Plastic, TurkeyFeathers, GooseFeathers}

