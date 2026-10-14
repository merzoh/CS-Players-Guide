public class Program
{
    static void Main()
    {
        ColoredItem<Sword> blueSword = new ColoredItem<Sword>(ConsoleColor.Blue);
        ColoredItem<Bow> redBow = new ColoredItem<Bow>(ConsoleColor.Red);
        ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(ConsoleColor.Green);
        blueSword.Display();
        redBow.Display();
        greenAxe.Display();
    }
}

public class ColoredItem<T> where T : class, new()
{
    private ConsoleColor Color { get; init; }
    public T Item = new T();
    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
    }
    public ColoredItem(ConsoleColor color)
    {
        Color = color;
    }
}
public class Sword
{
    public Sword()
    {

    }
}
public class Bow
{
    public Bow()
    {

    }

}
public class Axe
{
    public Axe()
    {

    }
}