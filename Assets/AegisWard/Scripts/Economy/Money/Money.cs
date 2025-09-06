using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Money
{
    private Money(){}
    
    private static Money _instance = null;
    
    private static readonly object Padlock = new object();

    public static Money Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Money();
                    }
                }
            }

            return _instance;
        }
    }

    [Range(0f, 9999999f)]
    public readonly ReactiveProperty<float> Amount = new ReactiveProperty<float>(0);

    public void SetMoneyCount(float amount)
    {
        Amount.Value = amount;
    }
    
    public void GetMoney(float amount)
    {
        if (amount <= 0f) return;
        Amount.Value += amount;
    }

    public void SpendMoney(float amount)
    {
        if (amount <= 0f) return;
        Amount.Value -= amount;
    }
}
