using UnityEngine;

public abstract class AttackChecker : IAttackChecker
{
    protected IAttackChecker _nextChecker;
    
    public void SetNext(IAttackChecker next)
    {
        _nextChecker = next;
    }

    public abstract bool Check();
}
