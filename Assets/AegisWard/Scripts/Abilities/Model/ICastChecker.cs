using AegisWard.Scripts.Abilities.Model;
using UnityEngine;

public interface ICastChecker
{
    void SetNext(ICastChecker next);
    bool Check(IAbility ability);
}
