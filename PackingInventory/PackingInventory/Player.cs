using ConsoleUtil;

namespace PackingInventory;

internal class Player
{
    private Pack playerPack;
    public Player()
    {
        playerPack = new Pack();
    }
    public void Prepare()
    {
        while (true)
        {
            ItemOptions item = GetChoice();
            if (item == ItemOptions.Exit)
                Environment.Exit(0);

        }
    }
    private ItemOptions GetChoice()
    {
        MenuManager<ItemOptions> prepManager = new MenuManager<ItemOptions>();
        return prepManager.Run("What item would you like to pack?");
    }
}
