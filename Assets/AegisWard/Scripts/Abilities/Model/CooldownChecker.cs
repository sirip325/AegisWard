using AegisWard.Scripts.Abilities.Model;
using UnityEngine;

public class CooldownChecker : CastChecker
{
    public override bool Check(IAbility ability)
    {
        Debug.Log($"Check cooldown: {ability.timer.Value}\n Next Checker: {_nextChecker}");
        
        if (ability.timer.Value == 0f && _nextChecker != null)
        {
            Debug.Log("Will be used the next checker");
            return _nextChecker.Check(ability);
        }
        else if (ability.timer.Value == 0f && _nextChecker == null)
        {
            Debug.Log("It is last checker");
            return true;
        }
        else if(ability.timer.Value > 0f)
        {
            return false;
        }

        return false;
    }
}
