using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public abstract class ItemContext : ScriptableObject
{
    public readonly ReactiveCommand<ItemContext> OnItemBuy = new ReactiveCommand<ItemContext>();
    
    public float cost;
    public Sprite icon;

    public virtual void Buy()
    {
        Debug.Log($"Trying to buy {name} for {cost}, money = {Money.Instance.Amount.Value}");
        if(Money.Instance.Amount.Value < cost) 
        {
            Debug.Log("Not enough money!");
            return;
        }
        Money.Instance.SpendMoney(cost);
        OnItemBuy.Execute(this);
        Debug.Log($"On Item Buy Method Executed");
    }

    public abstract void Sell();
    
}
