
class L32Dictionary
{
    public static void Run()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        dictionary["battleship"] = "a large ship with big guns";
        dictionary["cruiser"] = "a fast but large warship";
        dictionary["submarine"] = "a ship capable of moving under the water's surface";

        Console.WriteLine(dictionary.GetValueOrDefault("geng", "unknown"));

        bool isRemoved = dictionary.Remove("battleship");
        Console.WriteLine(isRemoved);
    }
}