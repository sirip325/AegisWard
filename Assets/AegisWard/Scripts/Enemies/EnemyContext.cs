using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Enemy",menuName = "New Scriptable Object/Enemy")]
public class EnemyContext : ScriptableObject
{
    public Health Health;
    public float startHealth;
    public float damage;
    public float range;
    public float fireRate;
    public float speed;
    [Header("Award Settings"),Space] 
    public float reward;
    public float rewardFactor;
}
