namespace WarPreparations;

public class Program
{
    static void Main()
    {
        SwordBlueprint[] swords = new SwordBlueprint[3];
        swords[0] = new(SwordMaterial.Iron, Gemstone.None, 60, 12);
        swords[1] = swords[0] with { material = SwordMaterial.Wood, length = 48, crossguardWidth = 8 };
        swords[2] = swords[0] with { material = SwordMaterial.Binarium, stone = Gemstone.Bitstone, length = 66, crossguardWidth = 18 };

        foreach (SwordBlueprint sword in swords)
        {
            Console.WriteLine(sword);
        }

    }
}