namespace PackingInventory;

internal class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
    public string Name { get; protected set; }
    public InventoryItem()
    {
        
    }
}
