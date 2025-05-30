using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;

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
        
    }
}
