using UnityEngine;

public interface IItem
{
    void Buy();
    void Sell();
    ItemContext GetItemContext();
    
    virtual void UseItem(){}
    virtual void GetPassiveItemStats(){}
}
