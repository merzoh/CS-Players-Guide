Console.Title = "Vin's Trouble'";

int menuChoice;
do
{
    menuChoice = GetChoice("Would you like a premade arrow or a custom one?\n1.) Premade\n2.) Custom\nYour Choice: ");
} while (menuChoice > 2 || menuChoice < 1);
Arrows arrow;
switch (menuChoice)
{
    case 1:
        int subMenuChoice;
        Console.WriteLine("Which kind of arrow would you like?\n1.) Elite\n2.) Beginner\n3.) Marksman\nYour Choice: ");
        do
        {
            subMenuChoice = int.Parse(Console.ReadLine());
        } while (subMenuChoice > 3 ||  subMenuChoice < 1);
        switch (subMenuChoice)
        {
            case 1:
                arrow = Arrows.CreateEliteArrow();
                break;
            case 2:
                arrow = Arrows.CreateBeginnerArrow();
                break;
            case 3:
                arrow = Arrows.CreateMarksmanArrow();
                break;
            default:
                arrow = new Arrows();
                break;
        }
        break;
    case 2:
        arrow = new Arrows();
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
        arrow.Tip = (ArrowHeadMaterial)choice;

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
        arrow.Fletching = (FletchingMaterial)choice;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("I can make arrows between 60 and 100 centimeters long, how long of an arrow would you like? ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        do
        {
            arrow.Length = int.Parse(Console.ReadLine());
            if (arrow.Length > 100 || arrow.Length < 60)
                Console.Write("Please enter a valid length. ");
        } while (arrow.Length > 100 || arrow.Length < 60);
        Console.ForegroundColor = ConsoleColor.Green;
        break;
    default:
        arrow = new Arrows();
        break;
}
Console.WriteLine($"That is going to cost you {arrow.GetCost()}");





//Functions
int GetChoice(string text)
{
    Console.Clear();
    Console.Write(text);
    return int.Parse(Console.ReadLine());
}
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
    //FIELDS
    private ArrowHeadMaterial _tip;
    private FletchingMaterial _fletching;
    private int _length;

    //PROPERTIES
    public (int minLength, int maxLength) LengthRange { get; } = (60, 100);
    public ArrowHeadMaterial Tip
    {
        get => _tip;
        set => _tip = value;
    }
    public FletchingMaterial Fletching
    {
        get => _fletching;
        set => _fletching = value;
    }
    public int Length
    {
        get => _length;
        set => _length = value;
    }

    //CONSTRUCTORS
    public Arrows()
    {

    }
    public Arrows(ArrowHeadMaterial tip, FletchingMaterial fletching, int length)
    {
        Tip = tip;
        Fletching = fletching;
        Length = length;
    }

    //METHODS
    public float GetCost()
    {
        float cost = 0;
        switch (Tip)
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
        switch (Fletching)
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
        cost += Length * .05f;
        return cost;
    }
    public static Arrows CreateEliteArrow() => new Arrows(ArrowHeadMaterial.Steel, FletchingMaterial.Plastic, 95);
    public static Arrows CreateBeginnerArrow() => new Arrows(ArrowHeadMaterial.Wood, FletchingMaterial.GooseFeathers, 75);

    public static Arrows CreateMarksmanArrow() => new Arrows(ArrowHeadMaterial.Steel, FletchingMaterial.GooseFeathers, 65);


}