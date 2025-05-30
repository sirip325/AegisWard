using AegisWard.Scripts.Abilities.Model;
using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameEntryPoint : IStartable
{
    private PlayerStats _playerStats;
    
    [Inject]
    public GameEntryPoint(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }
    public void Start()
    {
        LockCursor();
        _playerStats.Init();
        var fireball = new FireBall();
        fireball.manaCost = 100;
        var manaChecker = new ManaChecker(_playerStats);
        var secondChecker = new ManaChecker(_playerStats);
        //manaChecker.SetNext(secondChecker);
        
        Debug.Log($"Mana Cost is:{fireball.manaCost}");
        Debug.Log($"Current Mana is{_playerStats.currentMana}");
        var checkResult = manaChecker.Check(fireball);
        Debug.Log(checkResult);
        
        _playerStats.currentMana -= fireball.manaCost;
        Debug.Log($"Current Mana is{_playerStats.currentMana}");
        checkResult = manaChecker.Check(fireball);
        Debug.Log(checkResult);
        
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
