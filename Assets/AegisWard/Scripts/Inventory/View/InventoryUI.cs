using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _inventory;
    
    private VisualElement[] _slots = new VisualElement[6];
    
    private void Start()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        
        _inventory = _root.Q<VisualElement>("ItemsPanel");

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = _root.Q<VisualElement>($"ItemSlot{i+1}");
            print($"Binded slot {_slots[i].name} with index {i}");
        }
    }

    public void UpdateSlotIcon(int id,Sprite sprite)
    {
        _slots[id].style.backgroundImage = sprite.texture;
    }
}
