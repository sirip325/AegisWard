using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [field: SerializeField]public EnemyContext Context { get; private set; }
    
    protected IAttackChecker _attackRateChecker;
    
    protected abstract void Attack(float damage, Health targetHealth);

    
    private void Start()
    {
        _attackRateChecker = new AttackRateChecker(Context.fireRate);
    }
    
    protected virtual void OnHit(float damage)
    {
        Context.health.Reduce(damage);
    }

    protected virtual void CheckForHittableObjects()
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
                Attack(Context.damage, hittable.Health);
            }
        }
    }
}
