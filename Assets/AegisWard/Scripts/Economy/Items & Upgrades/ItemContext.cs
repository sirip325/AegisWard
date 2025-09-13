using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemContext : ScriptableObject
{
    public float cost;
    public Sprite icon;

    public virtual void Buy()
    {
        Money.Instance.SpendMoney(cost);
    }

    public abstract void Sell();
    
}
