using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [field: SerializeField]public EnemyContext Context { get; private set; }
    
    
    public abstract void Attack(float damage, Health targetHealth);

    protected virtual void OnHit(float damage)
    {
        Context.health.Reduce(damage);
    }
}
