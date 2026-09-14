Console.Title = "Vin Fletcher's Arrows";

Arrows arrow = new Arrows();

int choice;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("What type of arrow head would you like?");
Console.ForegroundColor = ConsoleColor.White;
foreach (ArrowHeadMaterial ah in Enum.GetValues<ArrowHeadMaterial>())
{
    Console.WriteLine($"{(int)ah + 1}: {ah}");
}
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("Your choice: ");
choice = int.Parse(Console.ReadLine()) - 1;
arrow._tip = (ArrowHeadMaterial)choice;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("What type of fletching material would you like?");
Console.ForegroundColor = ConsoleColor.White;
foreach (FletchingMaterial fm in Enum.GetValues<FletchingMaterial>())
{
    Console.WriteLine($"{(int)fm + 1}: {fm}");
}
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("Your choice: ");
choice = int.Parse(Console.ReadLine()) - 1;
arrow._fletching = (FletchingMaterial)choice;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("I can make arrows between 60 and 100 centimeters long, how long of an arrow would you like? ");
Console.ForegroundColor = ConsoleColor.Magenta;
do
{
    arrow._length = int.Parse(Console.ReadLine());
    if (arrow._length > 100 || arrow._length < 60)
        Console.Write("Please enter a valid length. ");
} while (arrow._length > 100 || arrow._length < 60);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"That is going to cost you {arrow.GetCost()}");





//ENUMS
enum ArrowHeadMaterial
{
    Steel,
    Wood,
    Obsidian

}
enum FletchingMaterial
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}
//CLASSES
class Arrows
{
    public ArrowHeadMaterial _tip;
    public FletchingMaterial _fletching;
    public int _length;
    public (int minLength, int maxLength) _lengthRange = (60, 100);
    public Arrows ()
    {
    
    }
    public Arrows (ArrowHeadMaterial tip, FletchingMaterial fletching, int length)
    {
        _tip = tip;
        _fletching = fletching;
        _length = length;
    }
    public float GetCost()
    {
        float cost = 0;
        switch (_tip)
        {
            case ArrowHeadMaterial.Steel:
                cost += 10;
                break;
            case ArrowHeadMaterial.Wood:
                cost += 3;
                break;
            case ArrowHeadMaterial.Obsidian:
                cost += 5;
                break;
        }
        switch (_fletching)
        {
            case FletchingMaterial.Plastic:
                cost += 10;
                break;
            case FletchingMaterial.TurkeyFeathers:
                cost += 5;
                break;
            case FletchingMaterial.GooseFeathers:
                cost += 3;
                break;
        }
        cost += _length * .05f;
        return cost;
    }
 
}