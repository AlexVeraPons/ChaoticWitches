internal class Inventory
{
    private const int _maxItems = 3;
    private Item[] _items = new Item[3];

/// <summary>
/// Constructor for Inventory, must include three items in the array.
/// </summary>
/// <param name="items"></param>
    public  Inventory(Item[] items)
    {
        for (int i = 0; i < _maxItems; i++)
        {
            this._items[i] = items[i];
        }
    }    
    
    public bool HasItem(Item item)
    {
        foreach (Item i in _items)
        {
            if (i == item)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasGatheredAllItems()
    {
        foreach (Item i in _items)
        {
            if (!i.IsGathered())
            {
                return false;
            }
        }
        return true;
    }
}

