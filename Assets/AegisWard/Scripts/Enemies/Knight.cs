using System;
using System.Linq;
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

    private void Update()
    {
        CheckForHittableObjects();
    }

    private void CheckForHittableObjects()
    {
        var hits = Physics.OverlapSphere(transform.position, Context.range);
        
        
        if(hits.Length == 0) return;
        
        var hit = hits.Where(h => h.gameObject != gameObject)
                             .OrderBy(h => Vector3.Distance(transform.position,h.transform.position))
                             .FirstOrDefault();
        
        
        if (hit == null) return;
        
        if (hit.gameObject.TryGetComponent(out IHittable hittable))
        {
            if (_attackRateChecker.Check()) 
            {
                hittable.Health.Reduce(Context.damage);
                Debug.Log($"Ударил {hit.name} на {Context.damage} урона");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Context.range);
    }
}
