using ConsoleUtil;

namespace PackingInventory;

internal class Player
{
    private Pack playerPack = new Pack();
    public void Prepare()
    {
        while (true)
        {
            switch (GetMainChoice())
            {
                case PackOptions.Add:
                    ItemOptions item;
                    while ((item = GetItemChoice()) != ItemOptions.Back)
                    {

                        InventoryItem newItem = item switch
                        {
                            ItemOptions.Arrow => new Arrow(),
                            ItemOptions.Bow => new Bow(),
                            ItemOptions.Rope => new Rope(),
                            ItemOptions.Water => new Water(),
                            ItemOptions.Food => new Food(),
                            ItemOptions.Sword => new Sword()

                        };
                        int quantity;

                        do
                        {
                            int.TryParse(ConsoleHelpers.GetInput("How many would you like to pack: "), out quantity);
                        } while (quantity < 0);
                        for (int i = 0; i < quantity; i++)
                        {
                            if (playerPack.Add(newItem))
                            {
                                if (i == quantity - 1)
                                    PackRendering.DisplayItemAdded(item, quantity);
                            }
                            else
                                PackRendering.DisplayFailureToAdd(item, quantity - i, i
                                    );
                                
                        }
                        
                    }
                    break;
                case PackOptions.Status:
                    PackRendering.DisplayStatus(playerPack.Items, playerPack);
                    break;
                case PackOptions.Exit:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }


        }
    }
    private PackOptions GetMainChoice() => new MenuManager<PackOptions>().Run("What would you like to do?");
    private ItemOptions GetItemChoice() => new MenuManager<ItemOptions>().Run("What item would you like to pack?");
}
