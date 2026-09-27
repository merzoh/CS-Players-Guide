namespace PackingInventory;

internal static class PackRendering
{
    public static void DisplayStatus(InventoryItem[] items, Pack pack)
    {
        string packStatus = $"Items:{pack.CurrentItemCount} || Weight:{pack.CurrentWeight} || Volume:{pack.CurrentVolume}";
        int yPadding = (Console.WindowHeight - (items.Length + 2)) / (items.Length + 2);
        int yPos = yPadding + 1;
        Console.Clear();
        Console.SetCursorPosition((Console.WindowWidth - "Pack contents:".Length) / 2, yPos);
        Console.Write("Pack contents:");
        yPos += yPadding + 1;
        foreach (InventoryItem item in items)
        {
            
            if (item != null)
            {
                Console.SetCursorPosition((Console.WindowWidth - item.Name.Length) / 2, yPos);
                Console.Write(item.Name);
            }
            else
            {
                Console.SetCursorPosition((Console.WindowWidth - "Empty".Length) / 2, yPos);
                Console.Write("Empty");
            }
            yPos += yPadding + 1;
        }
        Console.SetCursorPosition((Console.WindowWidth - packStatus.Length) / 2, yPos);
        Console.Write(packStatus);
        yPos += yPadding + 1;
        Console.SetCursorPosition((Console.WindowWidth - "Press any key to return...".Length) / 2, yPos);
        Console.Write("Press any key to return...");
        Console.ReadKey(true);
    }
    public static void DisplayFailureToAdd(ItemOptions item, int quantityRemaining, int quantityAdded)
    {
        string failMessage = $"Added {quantityAdded} {item.ToString()} to pack. Failed to add remaining {quantityRemaining} {item.ToString()} to pack. Press any key to continue...";
        Console.SetCursorPosition(0, (int)(Console.WindowHeight * (2f / 3f)) - 1);
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition((Console.WindowWidth - failMessage.Length) / 2, (int)((Console.WindowHeight * (2f / 3f)) - 1));
        Console.Write(failMessage);
        Console.ReadKey(true);
        
    }
    public static void DisplayItemAdded(ItemOptions item, int quantityAdded)
    {
        string addMessage = $"Added {quantityAdded} {item.ToString()} to pack. Press any key to continue...";
        Console.SetCursorPosition(0, (int)(Console.WindowHeight * (2f / 3f)) - 1);
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition((Console.WindowWidth - addMessage.Length) / 2, (int)((Console.WindowHeight * (2f / 3f)) - 1));
        Console.Write(addMessage);
        Console.ReadKey(true);
    }
}