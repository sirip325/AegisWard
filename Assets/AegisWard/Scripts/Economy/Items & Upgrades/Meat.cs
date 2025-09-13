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
        base.Buy();
        _playerHealth.Health.Max.Value += additionalHealth;
        _playerHealth.Health.Add(additionalHealth);
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
