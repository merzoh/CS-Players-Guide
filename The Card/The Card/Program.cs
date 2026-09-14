foreach (Color color in Enum.GetValues<Color>())
{
    foreach(Rank rank in Enum.GetValues<Rank>())
    {
        Cards card = new Cards(color, rank);
        card.displayCard();
    }
}

//ENUMS
public enum Color
{
    Red,
    Green,
    Blue,
    Yellow
}
public enum Rank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Carat,
    Ampersand

}
//CLASSES
public class Cards
{
    //Properties
    public Color CardColor { get; set; }
    public Rank CardRank { get; set; }
    //Methods
    public void displayCard()
    {
        string rank;
        switch (CardRank)
        {
            case Rank.Dollar:
                rank = "$";
                break;
            case Rank.Percent:
                rank = "%";
                break;
            case Rank.Carat:
                rank = "^";
                break;
            case Rank.Ampersand:
                rank = "&";
                break;
            default:
                rank = ((int)CardRank + 1).ToString();
                break;
        }
        Console.WriteLine($"{CardColor.ToString()} {rank}");
    }
    //Constructor
    public Cards (Color cardColor, Rank cardRank)
    {
        CardColor = cardColor;
        CardRank = cardRank;
    }

}
