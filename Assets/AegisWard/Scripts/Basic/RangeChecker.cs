using UnityEngine;

public class RangeChecker : AttackChecker
{
    private Transform _target;
    private float _attackRange;
    private Transform _transform;

    public RangeChecker(Transform target,float attackRange,Transform transform)
    {
        this._target = target;
        this._transform = transform;
        this._attackRange = attackRange;
    }
    
    public override bool Check()
    {
        bool result = Vector3.Distance(_transform.position, _target.position) <= _attackRange;
        if (result && _nextChecker != null)
        {
            return _nextChecker.Check();
        }
        else if(result && _nextChecker == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
