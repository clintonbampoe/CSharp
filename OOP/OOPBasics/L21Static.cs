class L21Static {
    public static void Run() {
        // Console Title
        Console.Title = "Vin Fletching's Arrows";

        // create new instance for arrow
        Arrow newArrow = new();


        // Program greeting
        WelcomeMessage();
        DiplayArrowTypes();
        ArrowType type = PickArrowType();

        if (type == ArrowType.Prebuilt) {
            DisplayPrebuiltArrows();

            newArrow = PickPrebuitArrow();
        }
        else if (type == ArrowType.Custom) {
            DisplayCustomArrows();


            // BUILD CUSTOM ARROW
            // ARROW HEAD
            DisplayArrowHead();
            newArrow.Head = PickArrowHead();

            // ARROW FLETCHING
            DisplayArrowFletching();
            newArrow.Fletching = PickArrowFletching();

            // SHAFT LENGTH
            DisplayArrowShaft();
            newArrow.Shaft = PickArrowShaft();
        }


        // GET COST
        float arrowCost = GetCost(newArrow.Head, newArrow.Fletching, newArrow.Shaft);

        Console.WriteLine($"The arrow costs {arrowCost} gold");
    }

    class Arrow {
        
        public ArrowHead Head { get; set; } = ArrowHead.Steel;
        public ArrowFletching Fletching { get; set; } = ArrowFletching.Plastic;

        public int Shaft { get; set; } = 60;

        // class constructor1
        public Arrow() {
            Head = ArrowHead.Steel;
            Fletching = ArrowFletching.Plastic;
            Shaft = 60;
        }

        // class constructor2
        public Arrow(ArrowHead head, ArrowFletching fletching, int shaft) {
            Head = head;
            Fletching = fletching;
            Shaft = shaft;
        }


        // insert static methods
        // CreateEliteArrow
        public static Arrow CreateEliteArrow() {
            return new Arrow(ArrowHead.Steel, ArrowFletching.Plastic, 95);
        }

        // CreateMarksmanArrow
        public static Arrow CreateMarksmanArrow() {
            return new Arrow(ArrowHead.Steel, ArrowFletching.GooseFeathers, 65);
        }

        // CreateBeginnerArrow
        public static Arrow CreateBeginnerArrow() {
            return new Arrow(ArrowHead.Wood, ArrowFletching.GooseFeathers, 75);
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
        Console.WriteLine("ARROW HEAD TYPES");
        Console.WriteLine("\n");
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
        Console.WriteLine("ARROW FLETCHING TYPES");
        Console.WriteLine("\n");
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
        Console.WriteLine("ARROW SHAFT");
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


    // Method11: DisplayArrowType
    static void DiplayArrowTypes() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }

        Console.WriteLine("ARROW TYPES");
        Console.WriteLine("\n");
        Console.WriteLine($"1: PreBuilt Arrow");
        Console.WriteLine($"2: Custom Arrow");
    }


    // Method12: PickArrowType
    static ArrowType PickArrowType() {

        // instructions 
        Console.Write("Pick your arrow type: ");

        do {
            Console.Write("Enter your choice: ");
            string input = TakeInput().ToLower();

            switch (input) {
                case "1":
                case "prebuilt":
                case "prebuilt arrow":
                    return ArrowType.Prebuilt;

                case "2":
                case "custom":
                case "custom arrow":
                    return ArrowType.Custom;
            }
        } while (true);
    }


    // Method13: Display prebuilt arrow types
    static void DisplayPrebuiltArrows() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }

        Console.WriteLine("PREBUILT ARROW TYPES");
        Console.WriteLine("\n");
        Console.WriteLine("1: Beginner Arrow");
        Console.WriteLine("2: Marksman Arrow");
        Console.WriteLine("3: Elite Arrow");
    }


    // Method14: Pick Prebuilt Arrow Type
    static Arrow PickPrebuitArrow() {
        Console.Write("Choose your arrow type: ");
        string input = TakeInput().ToLower();
        do {
            switch (input) {
                case "1":
                case "beginner":
                case "beginner arrow":
                    return Arrow.CreateBeginnerArrow();

                case "2":
                case "marksman":
                case "marksman arrow":
                    return Arrow.CreateMarksmanArrow();

                case "3":
                case "elite":
                case "elite arrow":
                    return Arrow.CreateEliteArrow();
            }
        } while (true);
        
    }

    
    // Method15: Custom Arrow Display Message
    static void DisplayCustomArrows() {
        for (int i = 0; i < 80; i++) {
            Console.Write("-");
        }

        Console.WriteLine("BUILD YOUR CUSTOM ARROW");
        Console.WriteLine("\n");
    }

    
    // ENUMS
    enum ArrowHead { Steel, Wood, Obsidian }
    enum ArrowFletching { Plastic, TurkeyFeathers, GooseFeathers }
    enum ArrowType { Prebuilt, Custom}
}