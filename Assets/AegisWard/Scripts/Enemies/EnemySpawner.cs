using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private Transform[] mazles = new Transform[2];
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();


    private void Start()
    {
        SpawnEnemies(enemies,CalculateSpawningPosition(mazles));
    }
    
    private Vector3 CalculateSpawningPosition(Transform[] mazles)
    {
        if (mazles.Length != 2)
        {
            Debug.LogError("Can't calculate spawning zones");
            return Vector3.zero;
        }
        
        Vector3 a = mazles[0].position;
        Vector3 b = mazles[1].position;
        
        float minX = Mathf.Min(a.x, b.x);
        float maxX = Mathf.Max(a.x, b.x);
        float minZ = Mathf.Min(a.z, b.z);
        float maxZ = Mathf.Max(a.z, b.z);

        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomZ = UnityEngine.Random.Range(minZ, maxZ);
        
        return new Vector3(randomX,transform.position.y,randomZ);
    }

    private void SpawnEnemies(List<Enemy> enemies,Vector3 position)
    {
        int index = UnityEngine.Random.Range(0, enemies.Count);
        
        var _ = Instantiate(enemies[index], position, Quaternion.identity);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mazles[0].position,-mazles[0].position+mazles[1].position);
    }
}
