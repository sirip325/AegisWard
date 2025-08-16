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

    /*private void UseFireball()
    {
        var fireball = new FireBall(_fireballPrefab, _playerStats.transform,100f);
        var manaChecker = new ManaChecker(_playerStats);
        
        Debug.Log($"Mana Cost is:{fireball.manaCost}");
        Debug.Log($"Current Mana is{_playerStats.currentMana}");
        var checkResult = manaChecker.Check(fireball);
        Debug.Log(checkResult);
        
        fireball.Execute();
    }*/
}
