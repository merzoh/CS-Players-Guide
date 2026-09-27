namespace PackingInventory;

internal class Bow : InventoryItem
{
    public Bow() : base(1, 4, "Bow of Doom") { }
    public override string ToString() => "Bow";
}