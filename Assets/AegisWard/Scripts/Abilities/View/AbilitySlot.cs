using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public class AbilitySlot
{
    private VisualElement _root;
    private Image _icon;
    private Label _cooldown;

    public AbilitySlot(VisualElement root)
    {
        this._root = root;
        
        
        _icon = new Image();
        _icon.scaleMode = ScaleMode.ScaleToFit;
        _icon.style.width = 200;
        _icon.style.height = 200;
        

        root.Add(_icon);

        _cooldown = new Label();
        _cooldown.style.color = new StyleColor(Color.black);
        _cooldown.AddToClassList("cooldown");
        _root.Add(_cooldown);
    }

    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    public void SetCooldown(float cooldown)
    {
        _cooldown.text = cooldown.ToString("F0");
        if (cooldown <= 0)
        {
            _cooldown.text = String.Empty;
        }
    }


}
