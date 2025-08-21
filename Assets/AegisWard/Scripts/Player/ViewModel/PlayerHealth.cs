using UniRx;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float _maxHP;
    
    private PlayerHealthData _playerHealthData;
    private HealthBarUI _healthBarUI;

    private void Start()
    {
        _playerHealthData = new PlayerHealthData(_maxHP);
        _healthBarUI = FindObjectOfType<HealthBarUI>().GetComponent<HealthBarUI>();
        
        _healthBarUI.Init();
        _healthBarUI.SetBarMaxValue(_maxHP);
        
        _playerHealthData._health.Current.Subscribe(UpdateBar);
    }

    private void UpdateBar(float newValue)
    {
        _healthBarUI.ChangeHealthFillAmount(newValue);
    }
}
