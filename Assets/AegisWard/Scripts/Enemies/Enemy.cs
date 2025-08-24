using UnityEngine;

public abstract class Enemy
{
    public EnemyContext Context { get; private set; }

    public Enemy(EnemyContext context)
    {
        Context = context;
    }

    public abstract void Attack(float damage, Health targetHealth);

    protected virtual void OnHit(float damage)
    {
        Context.health.Reduce(damage);
    }
}
