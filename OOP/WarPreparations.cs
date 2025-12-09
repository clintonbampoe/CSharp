using System.ComponentModel;

class WarPrepartions
{
    public static void Run()
    {
        float swordLength = 50;
        float crossguardLength = 10;

        Sword basicSword = new(SwordMaterial.Steel, GemStone.none, swordLength, crossguardLength);

        Sword basicSword2 = basicSword with { material = SwordMaterial.Steel, gem = GemStone.emerald };

        Sword basicSword3 = basicSword with { material = SwordMaterial.Binarium, gem = GemStone.bitstone };

        Console.WriteLine($"{basicSword.ToString()}");
        Console.WriteLine($"{basicSword2.ToString()}");
        Console.WriteLine($"{basicSword3.ToString()}");
    }

    public record Sword(SwordMaterial material, GemStone gem, float length, float crossguard);

   
}
// enums
enum SwordMaterial { Wood, Bronze, Iron, Steel, Binarium }
enum GemStone { none, emerald, amber, sapphire, diamond, bitstone }