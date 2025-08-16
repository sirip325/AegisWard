using AegisWard.Scripts.Abilities.Model;
using UnityEngine;

public class CooldownChecker : CastChecker
{
    public override bool Check(IAbility ability)
    {
        Debug.Log($"Check cooldown: {ability.timer}\n Next Checker: {_nextChecker}");
        
        if (ability.timer == 0f && _nextChecker != null)
        {
            Debug.Log("Will be used the next checker");
            return _nextChecker.Check(ability);
        }
        else if (ability.timer == 0f && _nextChecker == null)
        {
            Debug.Log("It is last checker");
            return true;
        }
        else
        {
            return false;
        }
    }
}
