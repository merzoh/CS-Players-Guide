namespace PackingInventory;

internal class Sword : InventoryItem
{
    public Sword() : base(5, 3, "Sword of Cleaving") { }
    public override string ToString() => "Sword";
}