class WarPrepartions
{
    public static void Run()
    {
        float swordLength = 50;
        float crossguardLength = 10;

        Sword basicSword = new(SwordMaterial.Steel, GemStone.none, swordLength, crossguardLength);

        Sword basicSword2 = basicSword with { Material = SwordMaterial.Steel, Gem = GemStone.emerald };

        Sword basicSword3 = basicSword with { Material = SwordMaterial.Binarium, Gem = GemStone.bitstone };

        Console.WriteLine($"{basicSword.ToString()}");
        Console.WriteLine($"{basicSword2.ToString()}");
        Console.WriteLine($"{basicSword3.ToString()}");
    }

    public record Sword(SwordMaterial Material, GemStone Gem, float Length, float CrossGuard);

   
}
// enums
enum SwordMaterial { Wood, Bronze, Iron, Steel, Binarium }
enum GemStone { none, emerald, amber, sapphire, diamond, bitstone }