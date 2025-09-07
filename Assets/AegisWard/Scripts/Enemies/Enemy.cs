using System.Linq;
using UnityEngine;
using UniRx;

public abstract class Enemy : MonoBehaviour,IHittable
{
    [field: SerializeField]public EnemyContext Context { get; private set; }
    
    protected IAttackChecker _attackRateChecker;
    
    private PathFinder _pathFinder;
    
    protected abstract void Attack(float damage, Health targetHealth);

    
    private void Start()
    {
        Context.Health = new Health(Context.startHealth);
        _attackRateChecker = new AttackRateChecker(Context.fireRate);
        _pathFinder = GetComponent<PathFinder>();

        Context.Health.Current.Subscribe(_ =>
        {
            if (_ <= 0f)
            {
                Die();
            }
        });
    }
    protected virtual void CheckForHittableObjects()
    {
        var hits = Physics.OverlapSphere(transform.position, Context.range);
        
        
        if(hits.Length == 0) return;
        
        var hit = hits.Where(h => !h.TryGetComponent(out Enemy enemy))
                             .OrderBy(h => Vector3.Distance(transform.position,h.transform.position))
                             .FirstOrDefault();
        
        
        if (hit == null) return;
        
        
        
        if (hit.gameObject.TryGetComponent(out IHittable hittable))
        {
            ChangeTarget(hit.transform);
            if (_attackRateChecker.Check()) 
            {
                Attack(Context.damage, hittable.Health);
            }
        }
    }

    private void ChangeTarget(Transform newTarget)
    {
        _pathFinder.ChangeTarget(newTarget);
    }
    
    protected virtual void Die()
    {
        print("I'm Dead...");
        Money.Instance.GetMoney(CalculateAwardFromDeath());
        Destroy(gameObject);
    }

    private int CalculateAwardFromDeath()
    {
        var minReward = Context.reward - Context.reward * Context.rewardFactor;
        var maxReward = Context.reward + Context.reward * Context.rewardFactor;
        
        float totalReward = Random.Range(minReward, maxReward);
        
        print($"Total reward is {totalReward}");
        
        return Mathf.RoundToInt(totalReward);
    }
    public Health Health => Context.Health;
}
