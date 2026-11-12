namespace BetterRandom;

public static class RandomExtensions
{
    public static double BetterDouble(this Random rand)
    {
        return rand.NextDouble() * 10;
    }
    public static string NextString(this Random rand, params string[] strings)
    {
        if (strings == null || strings.Length == 0)
        {
            return string.Empty;
        }
        return strings[rand.Next(strings.Length)];
    }
    public static bool CoinToss(this Random rand, float odds = .5f)
    {
        double roll = rand.NextDouble();
        odds = 1 - odds;
        return roll >= odds;
    }
}