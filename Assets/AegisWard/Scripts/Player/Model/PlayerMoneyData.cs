using UniRx;
using UnityEngine;

public class PlayerMoneyData : MonoBehaviour
{
    [SerializeField] private int startCash;
   
    private void Start()
    {
        Money.Instance.SetMoneyCount(startCash);
        print(Money.Instance.Amount);
    }
}
