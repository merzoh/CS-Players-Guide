class Program
{
    static void Main()
    {
        while (true)
        {
            string password = ConsoleHelper.RequestPassword();
            if (PasswordValidator.ValidatePassword(password))
                Console.WriteLine("Password is valid.");
            else if (password == "quit")
                Environment.Exit(0);
            else
                Console.WriteLine("Password is invalid.");
        }
    }
}
//ENUMS
//CLASSES
public static class PasswordValidator
{
    //FIELDS
    //PROPERTIES
    private static bool IsCorrectLength { get; set; }
    private static bool HasUppercase { get; set; }
    private static bool HasLowercase { get; set; }
    private static bool HasDigit { get; set; }
    private static bool HasUpperT { get; set; }
    private static bool HasAmpersand { get; set; }
    //CONSTRUCTORS

    //METHODS
    public static bool ValidatePassword(string password)
    {
        IsCorrectLength = password.Length >= 6 && password.Length <= 13;
        HasUppercase = password.Any(char.IsUpper);
        HasLowercase = password.Any(char.IsLower);
        HasDigit = password.Any(char.IsDigit);
        HasUpperT = password.Contains('T');
        HasAmpersand = password.Contains('&');
        return IsCorrectLength && HasUppercase && HasLowercase && HasDigit && !HasUpperT && !HasAmpersand;        
    }
}
public static class ConsoleHelper
{
    //FIELDS
    //PROPERTIES
    //CONSTRUCTORS
    //METHODS
    public static string RequestPassword()
    {
        Console.Write("Please enter a password to validate or type quit to exit: ");
        string input = Console.ReadLine();
        if (input == null)
            input = "";
        return input;
    }
}