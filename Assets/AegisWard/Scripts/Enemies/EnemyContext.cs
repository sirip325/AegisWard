using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "New Scriptable Object/Enemy")]
public class EnemyContext : ScriptableObject
{
    public Health health;
    public float damage;
    public float range;
    public float fireRate;
    public float speed;
    public float reward;
    public float rewardFactor;
}
