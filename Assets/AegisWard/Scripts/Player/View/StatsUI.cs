using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class StatsUI : MonoBehaviour
{
    private VisualElement root;
    private ProgressBar _manaBar;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }
    
    public void Init()
    {
        _manaBar = root.Q<ProgressBar>("ManaBar");
    }

    public void ChangeFillAmount(float amount)
    {
        if(amount < 0 || amount > _manaBar.highValue) return;
        _manaBar.value = amount;
    }

    public float SetManaHighValue(float value)
    {
        Debug.Log(_manaBar);
        print(_manaBar.highValue);
        _manaBar.highValue = value;
        return value;
    }

    public float GetHighValue()
    {
        return _manaBar.highValue;
    }
}