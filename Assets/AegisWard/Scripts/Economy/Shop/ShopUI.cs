using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using VContainer;
using Cursor = UnityEngine.Cursor;

public class ShopUI : MonoBehaviour
{
    public List<ItemContext> items = new List<ItemContext>();
    
    private VisualElement _root;
    private VisualElement _shopPanel;
    private VisualElement _itemGroupBox;
    
    private bool _isOpen = false;
    
    private InputSystem_Actions _inputSystemActions;
    [Inject]
    private IObjectResolver _container;
    
    private void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        
        _inputSystemActions = new InputSystem_Actions();
        
        _inputSystemActions.Enable();
        _inputSystemActions.Player.OpenCloseShop.performed += OpenCloseShop;
    }
    
    private void Start()
    {
        _shopPanel = _root.Q<VisualElement>("shopPanel");
        _itemGroupBox = _root.Q<VisualElement>("itemGroupBox");
        foreach (var item in items)
        {
            _container.Inject(item);
            AddItemToGroup(item);
        }
    }

    private void AddItemToGroup(ItemContext item)
    {
        Button newButton = new Button
        {
            text = "",
            iconImage = item.icon.texture,
            style =
            {
                width = 50,
                height = 50
            }
        };

        _itemGroupBox.Add(newButton);
        newButton.clicked += item.Buy;
    }

    private void OpenCloseShop(InputAction.CallbackContext context)
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            _shopPanel.AddToClassList("open");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }

        else
        {
            _shopPanel.RemoveFromClassList("open");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    
}
