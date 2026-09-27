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
                        switch (item)
                        {
                            case ItemOptions.Arrow:
                                if (!playerPack.Add(new Arrow()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
                            case ItemOptions.Bow:
                                if (!playerPack.Add(new Bow()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
                            case ItemOptions.Rope:
                                if (!playerPack.Add(new Rope()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
                            case ItemOptions.Water:
                                if (!playerPack.Add(new Water()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
                            case ItemOptions.Food:
                                if (!playerPack.Add(new Food()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
                            case ItemOptions.Sword:
                                if (!playerPack.Add(new Sword()))
                                    PackRendering.DisplayFailureToAdd(item);
                                else
                                    PackRendering.DisplayItemAdded(item);
                                break;
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
