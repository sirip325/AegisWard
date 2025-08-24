using UnityEngine;

public interface IAttackChecker
{
    void SetNext(IAttackChecker next);
    bool Check();
}
