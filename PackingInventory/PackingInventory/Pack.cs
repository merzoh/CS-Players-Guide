namespace PackingInventory;

internal class Pack
{
    private int _maxItems = 6;
    private float _maxWeight = 20;
    private float _maxVolume = 15;
    public Pack()
    {

    }
    public int ItemsHeld { get; private set; } = 0;
    public float CurrentWeight { get; private set; } = 0;
    public float CurrentVolume { get; private set; } = 0;
    public int MaxItems { get { return _maxItems; } }
    public float MaxWeight { get { return _maxWeight; } }
    public float MaxVolume { get { return _maxVolume; } }
    public bool Add(InventoryItem item)
    {
        return false;
    }
}
