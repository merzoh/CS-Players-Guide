using ConsoleUtilities;
namespace GameExceptions;

public class CookieEatenException : Exception
{
    
}
public class OatmealCookieEatenException : Exception
{

}
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {

    }
}
public class InvalidInputTypeException : Exception
{ 
    public InvalidInputTypeException(string message) : base(message)
    {
    }
}


