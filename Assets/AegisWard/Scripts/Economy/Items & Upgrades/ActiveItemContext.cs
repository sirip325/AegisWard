using UnityEngine;

public abstract class ActiveItemContext : ItemContext
{
    public override void Buy()
    {
        base.Buy();
    }

    public abstract override void Sell();

    public abstract void UseItem();
}
