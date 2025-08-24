using System;
using UnityEngine;

public class Knight : Enemy
{
    private IAttackChecker _attackRateChecker;
    public override void Attack(float damage,Health targetHealth)
    {
        targetHealth.Reduce(damage);
    }

    private void Start()
    {
        _attackRateChecker = new AttackRateChecker(Context.fireRate);
    }
    private void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.TryGetComponent<IHittable>(out IHittable hittable))
        {
            
            bool result = _attackRateChecker.Check();
            
            if(result) hittable.Health.Reduce(Context.damage);
        }
    }
}
