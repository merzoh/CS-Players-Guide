Console.Title = "Simula's Soup";

int userChoice;
(FoodTypes meal, Ingredients component, Seasonings flavor) userMeal;

Console.WriteLine("What type of food do you want? ");
foreach (FoodTypes foodType in Enum.GetValues<FoodTypes>())
{
    Console.WriteLine($"{(int)foodType + 1}: {foodType}");
}
userChoice = int.Parse(Console.ReadLine()) - 1;
userMeal.meal = (FoodTypes)userChoice;

Console.Clear();
Console.WriteLine("What type of ingredient do you want? ");
foreach (Ingredients ingredient in Enum.GetValues<Ingredients>())
{
    Console.WriteLine($"{(int)ingredient + 1}: {ingredient}");

}
userChoice = int.Parse(Console.ReadLine()) - 1;
userMeal.component = (Ingredients)userChoice;

Console.Clear();
Console.WriteLine("What type of seasoning do you want? ");
foreach (Seasonings seasoning in Enum.GetValues<Seasonings>())
{
    Console.WriteLine($"{(int)seasoning + 1}: {seasoning}");
}
userChoice = int.Parse(Console.ReadLine()) - 1;
userMeal.flavor = (Seasonings)userChoice;

Console.Clear();
Console.WriteLine($"You want {userMeal.flavor} {userMeal.component} {userMeal.meal}");
Console.ReadKey(true);

//ENUMS
enum FoodTypes { Soup, Stew, Gumbo }
enum Ingredients { Mushroom, Chicken, Carrot, Potatoe }
enum Seasonings { Spicy, Salty, Sweet }