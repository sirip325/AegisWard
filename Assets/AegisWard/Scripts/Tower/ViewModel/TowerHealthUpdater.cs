using UniRx;
using UnityEngine;

public class TowerHealthUpdater : MonoBehaviour
{
    [SerializeField]private TowerHealth_UI _ui;
    [SerializeField]private float _maxHealth;
    private TowerHealth _health;

    private void Start()
    {
        _health = new TowerHealth(_maxHealth);

        GameObject bar = Instantiate(_ui.healthBar, _ui.pivot.transform.position, Quaternion.Euler(90f, 0f, 0f));
        bar.transform.SetParent(_ui.pivot.transform);
        
        _health.Current.Subscribe(x => ChangeBar(bar,x,_maxHealth)).AddTo(this);
    }
    
    private void ChangeBar(GameObject bar,float newValue, float maxValue)
    {
        _ui.SetHealth(bar,newValue, maxValue);
    }
}
