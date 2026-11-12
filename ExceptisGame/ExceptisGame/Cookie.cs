using GameExceptions;
namespace ExceptisGame;

public class Cookie
{
    public bool IsOatmealCookie { get; init; }
    public bool IsEaten { get; private set; } = false;
    public Cookie(bool isOatmealCookie)
    {
        IsOatmealCookie = isOatmealCookie;
    }
    public void Eat()
    {
        if (IsEaten)
            throw new CookieEatenException();
        IsEaten = true;
    }
}