using System.Threading.Tasks;
using AegisWard.Scripts.Abilities.Model;
using AegisWard.Scripts.Player.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameEntryPoint : IStartable
{
    private PlayerStats _playerStats;
    private StatsViewModel _statsViewModel;
    
    
    [Inject]
    public GameEntryPoint(PlayerStats playerStats, StatsViewModel statsViewModel)
    {
        _playerStats = playerStats;
        _statsViewModel = statsViewModel;
    }
    public void Start()
    {
        LockCursor();
        _playerStats.Init();
        _statsViewModel.Init();
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
