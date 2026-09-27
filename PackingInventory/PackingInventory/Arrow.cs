using System.Reflection.Metadata.Ecma335;

namespace PackingInventory;

internal class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f, "Arrow of Death") { }
    public override string ToString() => "Arrow";
}