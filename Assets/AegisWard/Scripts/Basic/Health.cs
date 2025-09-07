using System;
using UniRx;
using UnityEngine;


public class Health
{
    private ReactiveProperty<float> _current, _max;


    public Health(float maxValue)
    {
        _max = new ReactiveProperty<float>(maxValue);
        _current = new ReactiveProperty<float>(maxValue);
    }
    public ReactiveProperty<float> Current
    {
        get { return _current; }
    }

    public ReactiveProperty<float> Max
    {
        get { return _max; }
    }

    public void Add(float value)
    {
        if (value <= 0f) return;
        _current.Value += Mathf.Clamp(value, 0f, _max.Value);
    }
    public void Reduce(float value)
    {
        if (value <= 0f) return;
        _current.Value -= Mathf.Clamp(value, 0f, _max.Value);
    }
}
