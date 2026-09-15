class Program
{
    static void Main()
    {
        while (true)
        {
            string password = ConsoleHelper.RequestPassword();
            if (PasswordValidator.ValidatePassword(password))
                Console.WriteLine("Password is valid.");
            else if (password.ToLower() == "quit")
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
    
    //CONSTRUCTORS

    //METHODS
    public static bool ValidatePassword(string password)
    {
        bool isCorrectLength = password.Length >= 6 && password.Length <= 13;
        bool hasUppercase = password.Any(char.IsUpper);
        bool hasLowercase = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasUpperT = password.Contains('T');
        bool hasAmpersand = password.Contains('&');
        return isCorrectLength && hasUppercase && hasLowercase && hasDigit && !hasUpperT && !hasAmpersand;        
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