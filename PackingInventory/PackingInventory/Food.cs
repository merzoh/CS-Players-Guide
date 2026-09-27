namespace PackingInventory;

internal class Food : InventoryItem
{
    public Food()
    {
        this.Weight = 1;
        this.Volume = 0.5f;
        this.Name = "Food";
    }
}