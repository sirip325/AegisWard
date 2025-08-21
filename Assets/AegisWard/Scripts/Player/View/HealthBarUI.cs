using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
{
    private VisualElement _root;
    private ProgressBar _healthBar;

    private void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
    }

    public void Init()
    {
        _healthBar = _root.Q<ProgressBar>("HealthBar");
    }

    public void ChangeHealthFillAmount(float amount)
    {
        if(amount < 0 || amount > _healthBar.highValue) return;
        _healthBar.value = amount;
    }

    public void SetBarMaxValue(float value)
    {
        _healthBar.highValue = value;
    }
}
