using System;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Inventory : MonoBehaviour
{
    private InventoryData _inventory = new InventoryData();
    [Inject]
    private InventoryUI _inventoryUI;
    
    [Inject]
    private ShopUI _shopUI;
    private void Start()
    {
        Debug.Log($"All Items in Shop {_shopUI.items}");
        
        foreach (var item in _shopUI.items)
        {
            item.OnItemBuy.Subscribe(x =>
            {
                AddItem(x);
                Debug.Log($"Inventory items count{_inventory.GetItemList.Count}");
                UpdateSlotIcon(_inventory.GetItemList.Count - 1);
                Debug.Log($"Added Item To Inventory: {x}");
            });
        }
        
    }

    private void UpdateSlotIcon(int id)
    {
        _inventoryUI.UpdateSlotIcon(id,_inventory.GetItemById(id).icon);
    }

    private void AddItem(ItemContext item)
    {
        _inventory.AddItem(item);
    }
}
