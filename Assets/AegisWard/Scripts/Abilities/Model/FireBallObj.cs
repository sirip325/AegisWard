using UnityEngine;

public class FireBallObj : MonoBehaviour
{
    [SerializeField] private GameObject exploisonPrefab;


    private float _damage;
    
    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
        if (collision.TryGetComponent(out IHittable hittable))
        {
            print($"FireBall Damage is {_damage}");
            hittable.Health.Reduce(_damage);
            print($"Now Target Has {hittable.Health.Current}/{hittable.Health.Max}");
        }
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
