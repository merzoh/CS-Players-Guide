Console.Title = "Simula's Test";

Chest test = Chest.Locked;
while (true)
{
    Console.Write($"The chest is {test}. What do you want to do? ");
    test = Interact(Console.ReadLine(), test);

    
}
static Chest Interact(string? entry, Chest prize)
{
    if (entry != null)
        entry = entry.ToLower();
    switch (entry)
    {
        case "unlock":
            if (prize == Chest.Locked)
                return Chest.Closed;
            else return prize;
        case "lock":
            if (prize == Chest.Closed)
                return Chest.Locked;
            else return prize;
        case "open":
            if (prize == Chest.Closed)
                return Chest.Open;
            else return prize;
        case "close":
            if (prize == Chest.Open)
                return Chest.Closed;
            else return prize;
        default:
            return prize;
    }
}

//ENUMS
enum Chest { Open, Closed, Locked }