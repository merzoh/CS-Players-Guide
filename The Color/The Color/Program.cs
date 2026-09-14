Color presetColor = Color.Red;
Color customColor = new Color(15, 23, 255);
Console.WriteLine($"Preset Color: R={presetColor.R}, G={presetColor.G}, B={presetColor.B}");
Console.WriteLine($"Custom Color: R={customColor.R}, G={customColor.G}, B={customColor.B}");



//Enums

//Classes
public class Color
{

    public static Color White { get; }  = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green  { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);

    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public Color (int red, int green, int blue)
    {
        R = red;
        G = green;
        B = blue;
    }

}