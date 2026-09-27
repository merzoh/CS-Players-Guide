namespace PackingInventory;

internal class Water : InventoryItem
{
    public Water() : base(2, 3, "Water of Life") { }
    public override string ToString() => "Water";
}