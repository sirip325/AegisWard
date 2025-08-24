using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class AttackRateChecker : AttackChecker
{
    private float _attackRate;
    
    private bool _isRunning;
    public AttackRateChecker(float rate)
    {
        this._attackRate = rate;
    }
    
    public override bool Check()
    {
        if(_isRunning) return false;
        
        
        StartTimer().Forget();

        if (_nextChecker != null)
        {
            Debug.Log("Will Be Used Next Checker");
            return _nextChecker.Check();
        }
        Debug.Log("True");
        return true;
    }

   
    
    private async UniTaskVoid StartTimer()
    {
        _isRunning = true;
        await UniTask.Delay(TimeSpan.FromSeconds(_attackRate));
        _isRunning = false;
        
        Debug.Log("Cooldown finished!");
    }
}
