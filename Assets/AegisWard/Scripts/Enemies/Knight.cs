using System;
using System.Linq;
using UnityEngine;

public class Knight : Enemy
{
    
    protected override void Attack(float damage,Health targetHealth)
    {
        targetHealth.Reduce(damage);
    }

    

    private void Update()
    {
        CheckForHittableObjects();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Context.range);
    }
}
