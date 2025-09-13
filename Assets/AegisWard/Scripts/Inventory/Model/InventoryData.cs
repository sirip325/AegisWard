using System.Collections.Generic;
using UnityEngine;

public class InventoryData
{
    private List<ItemContext> _items = new List<ItemContext>(6);

    public void AddItem(ItemContext item)
    {
        if (_items.Count == _items.Capacity) return;
        
        _items.Add(item);
        Debug.Log($"Added Item To Inventory: {item}");
    }

    public void RemoveItem(ItemContext item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }
    public List<ItemContext> GetItemList => _items;
    public ItemContext GetItemById(int id) => _items[id];
}
