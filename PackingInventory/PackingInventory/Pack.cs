namespace PackingInventory;

internal class Pack
{
    private readonly int _maxItems = 10;

    private readonly float _maxWeight = 40;
    private readonly float _maxVolume = 30;
    public Pack()
    {
        Items = new InventoryItem[_maxItems];
    }
    public int ItemsHeld { get; private set; } = 0;
    public float CurrentWeight { get; private set; } = 0;
    public float CurrentVolume { get; private set; } = 0;
    public int MaxItems { get { return _maxItems; } }
    public float MaxWeight { get { return _maxWeight; } }
    public float MaxVolume { get { return _maxVolume; } }
    public int CurrentItemCount { get; private set; } = 0;
    public InventoryItem[] Items { get; private set; }
    public bool Add(InventoryItem item)
    {
        if (CurrentItemCount != MaxItems && CurrentWeight + item.Weight <= MaxWeight && CurrentVolume + item.Volume <= MaxVolume)
        {
            Items[CurrentItemCount] = item;
            CurrentWeight += item.Weight;
            CurrentVolume += item.Volume;
            CurrentItemCount++;
            return true;
        }
        return false;
    }
}
