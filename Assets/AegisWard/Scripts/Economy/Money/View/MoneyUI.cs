using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;

public class MoneyUI : MonoBehaviour
{
   private VisualElement _root;
   private Label _moneyLabel;
   
   private void OnEnable()
   {
      _root = GetComponent<UIDocument>().rootVisualElement;
   }

   private void Start()
   {
      _moneyLabel = _root.Q<Label>("MoneyText");
      print(_moneyLabel);
      Money.Instance.Amount.Subscribe(UpdateMoneyText);
      UpdateMoneyText(0f);
   }

   private void UpdateMoneyText(float newValue)
   {
      if(newValue < 0) return;
      _moneyLabel.text = newValue.ToString();
   }
}
