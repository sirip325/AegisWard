using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;
using UniRx;

public class StatsViewModel
{
    private StatsUI _statsUI;
    private PlayerStats _playerStats;

    [Inject]
    public StatsViewModel(StatsUI statsUI, PlayerStats playerStats)
    {
        _statsUI = statsUI;
        
        _playerStats = playerStats;



    }

    public void Init()
    {
        _statsUI.Init();
        _playerStats.maxMana.Subscribe(OnMaxManaChanged);

        _playerStats.currentMana.Subscribe(OnManaChanged);
        
        var highManaValue = _statsUI.SetManaHighValue(_playerStats.maxMana.Value);
        _statsUI.ChangeManaFillAmount(highManaValue);
        Debug.Log(_statsUI.GetManaHighValue());
    }

    private void OnMaxManaChanged(float newValue)
    {
        Debug.Log(newValue);
        _statsUI.SetManaHighValue(newValue);
    }
    
    private void OnManaChanged(float newValue)
    {
        _statsUI.ChangeManaFillAmount(newValue);
    }
}
