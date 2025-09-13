using UnityEngine;
using VContainer;

[CreateAssetMenu(menuName = "New Scriptable Object/Items/Active/Meat")]
public class Meat : ActiveItemContext
{
    public float additionalHealth,addHealthAfterUse;
    
    [Inject]
    private PlayerHealth _playerHealth;
    
    public override void Buy()
    {
        if(Money.Instance.Amount.Value < cost) 
        {
            Debug.Log("Not enough money!");
            return;
        }
        
        base.Buy();
        _playerHealth.Health.Max.Value += additionalHealth;
        _playerHealth.Health.Add(additionalHealth);
        Debug.Log($"Now adding {additionalHealth} health and now max {_playerHealth.Health.Max.Value} and current is {_playerHealth.Health.Current.Value}");
    }

    public override void Sell()
    {
        Money.Instance.GetMoney(additionalHealth / 2);
        _playerHealth.Health.Max.Value -= additionalHealth;
    }

    public override void UseItem()
    {
        _playerHealth.Health.Add(additionalHealth);
    }
}
