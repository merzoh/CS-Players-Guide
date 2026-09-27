namespace PackingInventory;

internal class Rope : InventoryItem
{
    public Rope() : base(1, 1.5f, "Rope of Climbing") { }
    public override string ToString() => "Rope";
}