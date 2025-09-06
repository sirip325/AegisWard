using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ShopUI : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _shopPanel;
    private bool _isOpen = false;
    
    private InputSystem_Actions _inputSystemActions;
    
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
    }

    private void OpenCloseShop(InputAction.CallbackContext context)
    {
        _isOpen = !_isOpen;
        
        if(_isOpen)
            _shopPanel.AddToClassList("open");
        else
            _shopPanel.RemoveFromClassList("open");
    }
}
