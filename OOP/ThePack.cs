class ThePack
{
    public static void Run()
    {
        // Program Greeting
        Console.Title = "Pack";
        for(int i = 0; i < 80; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        Console.WriteLine("PACK");


        // List Options
        Console.WriteLine("- Create new pack");
        Console.WriteLine();
        Pack pack = CreateNewPack();

        // main action menu
        RunMainActionMenu(pack);
    }


    //
    // Helper Methods
    static string TakeInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        return input;
    }

    // BASE CLASS
    class InventoryItem
    {
        // properties
        public float Weight { get; }
        public float Volume { get; }


        // constructors
        public InventoryItem(float weight, float volume)
        {
            Weight = weight;
            Volume = volume;
        }
    }


    // DERIVED CLASSES
    class Arrow : InventoryItem
    {
        // constructor
        public Arrow() : base(0.1f, 0.05f) { }

        // overide to string
        public override string ToString()
        {
            return "Arrow";
        }
    }

    class Bow : InventoryItem
    {
        // constructor
        public Bow() : base(1.0f, 4.0f) { }

        // override ToString
        public override string ToString()
        {
            return "Bow";
        }
    }

    class Rope : InventoryItem
    {
        // constructor
        public Rope() : base(1.0f, 1.5f) { }

        //
        public override string ToString()
        {
            return "Rope";
        }
    }

    class Water : InventoryItem
    {
        //
        public Water() : base(2.0f, 3.0f) { }

        // 
        public override string ToString()
        {
            return "Water";
        }
    }

    class FoodRations : InventoryItem
    {
        public FoodRations() : base(1.0f, 0.5f) { }

        //
        public override string ToString()
        {
            return "Food Rations";
        }
    }

    class Sword : InventoryItem
    {
        public Sword() : base(5.0f, 3.0f) { }

        //
        public override string ToString()
        {
            return "Sword";
        }
    }


    // 
    class Pack
    {
        // constants
        public float WeightLimit { get; }
        public float VolumeLimit { get; }
        public static int ItemLimit { get; } = 3;

        // variables
        public float CurrentWeight { get; private set; }
        public float CurrentVolume { get; private set; }
        public int ItemCount { get; private set; }


        // constructors
        public Pack(float weightLimit, float volumeLimit)
        {
            WeightLimit = weightLimit;
            VolumeLimit = volumeLimit;
        }


        // 
        InventoryItem?[] Inventory = new InventoryItem[ItemLimit];

        // unique identifier for each item's incex in the array
        // ranges between 0 and n - 1, where n is the size of Inventory Array
        public int ItemIndex { get; private set; }


        // Methods
        // Add items to pack
        public bool Add(InventoryItem item)
        {
            if ((ItemCount + 1) <= ItemLimit)
            {
                // condition above passed
                ItemCount++;

                if ((CurrentWeight + item.Weight) <= WeightLimit && (CurrentVolume + item.Volume) <= VolumeLimit)
                {
                    // condition above passed
                    CurrentWeight += item.Weight;
                    CurrentVolume += item.Volume;


                    for (ItemIndex = 0; ItemIndex < ItemLimit; ItemIndex++)
                    {
                        if(Inventory[ItemIndex] is null)
                        {
                            Inventory[ItemIndex] = item;
                            return true;
                        }
                    }
                }
            }

            Console.WriteLine("Cannot add more items to pack!");
            return false;
        }

        // View items in pack
        public void GetPackContents()
        {
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            Console.WriteLine("YOUR PACK CONTAINS: ");
            for (int i = 0; i < ItemCount; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory[i]?.ToString()}");
            }
            Console.WriteLine();
        }
        


        // Report Item Count
        public void GetItemCount()
        {
            for(int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            Console.WriteLine("ITEM COUNT: ");
            Console.WriteLine($"{ItemCount}/{ItemLimit}");
            Console.WriteLine();
        }

        // Report Weight
        public void GetCurrentWeight()
        {
            Console.WriteLine("CURRENT WEIGHT: ");
            Console.WriteLine($"{CurrentWeight}/{WeightLimit}");
            Console.WriteLine();
        }

        // Report Volume
        public void GetCurrentVolume()
        {
            Console.WriteLine("CURRENT VOLUME: ");
            Console.WriteLine($"{CurrentVolume}/{VolumeLimit}");
            Console.WriteLine();
        }
    }


    // METHODS
    static Pack CreateNewPack()
    {
        // 
        Console.WriteLine("Enter item limit for this pack");
        Console.Write($"{"> ", 2}");
        int itemlimit = Convert.ToInt32(TakeInput());
        Console.WriteLine();

        Console.WriteLine("Enter the volume limit");
        Console.Write($"{"> ", 2}");
        float volumelimit = Convert.ToSingle(TakeInput());
        Console.WriteLine();

        Console.WriteLine("Enter the weight limit");
        Console.Write($"{"> ",2}");
        float weightlimit = Convert.ToSingle(TakeInput());
        Console.WriteLine();


        // create pack
        Pack newPack = new(weightlimit, volumelimit);
        return newPack;

    }

    public static void DisplayInventoryItems()
    {
        for(int i = 0; i < 80; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        Console.WriteLine("LIST OF ALL INVENTORY ITEMS");
        Console.WriteLine();

        Console.WriteLine("1. ARROW");
        Console.WriteLine($"{"Weight: 0.1", -20}{"Volume: 0.05", -20}");
        Console.WriteLine();

        Console.WriteLine("2. BOW");
        Console.WriteLine($"{"Weight: 1.0", -20}{"Volume: 4.0", -20}");
        Console.WriteLine();

        Console.WriteLine("3. ROPE");
        Console.WriteLine($"{"Weight: 1.0",-20}{"Volume: 1.5",-20}");
        Console.WriteLine();

        Console.WriteLine("4. WATER");
        Console.WriteLine($"{"Weight: 2.0",-20}{"Volume: 3.0",-20}");
        Console.WriteLine();

        Console.WriteLine("5. FOOD RATIONS");
        Console.WriteLine($"{"Weight: 1.0",-20}{"Volume: 0.5",-20}");
        Console.WriteLine();

        Console.WriteLine("6. SWORD");
        Console.WriteLine($"{"Weight: 5.0",-20}{"Volume: 3.0",-20}");
        Console.WriteLine();
    }

    static void AddItemToPack(Pack pack)
    {

            //
            Console.WriteLine("Choose the items you want to add");
            Console.WriteLine("Enter the name or number of the item you want to add ");
            Console.Write($"{"> ",2}");
            string input = TakeInput();

            switch (input.ToLower())
            {
                case "1":
                case "arrow":
                    Arrow newArrow = new();
                    pack.Add(newArrow);
                    Console.WriteLine("Arrow added to pack");
                    break;

                case "2":
                case "bow":
                    Bow newBow = new();
                    pack.Add(newBow);
                    Console.WriteLine("Bow added to pack");
                    break;

                case "3":
                case "rope":
                    Rope newRope = new();
                    pack.Add(newRope);
                    Console.WriteLine("Bow added to pack");
                break;

                case "4":
                case "water":
                    Water newWater = new();
                    pack.Add(newWater);
                    Console.WriteLine("Water added to pack");
                    break;

                case "5":
                case "food rations":
                    FoodRations newRation = new();
                    pack.Add(newRation);
                    Console.WriteLine("Food Ration added to pack");
                    break;

                case "6":
                case "sword":
                    Sword newSword = new();
                    pack.Add(newSword);
                    Console.WriteLine("Added Sword to pack");
                    break;
            }
    }

    static void RunMainActionMenu(Pack pack)
    {
        do
        {
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Pick Action");
            Console.WriteLine();
            Console.WriteLine("1. Add items to your pack");
            Console.WriteLine("2. Get current weight and volume report");
            Console.WriteLine("3. Get current item count");

            Console.WriteLine("Enter Choice");
            Console.Write($"{"> ", 5}");
            int input = Convert.ToInt32(TakeInput());
            switch (input)
            {
                case 1:
                    DisplayInventoryItems();
                    pack.GetPackContents();
                    AddItemToPack(pack);
                    break;

                case 2:
                    pack.GetCurrentWeight();
                    pack.GetCurrentVolume();
                    break;

                case 3:
                    pack.GetItemCount();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        } while (true);
    }

}
