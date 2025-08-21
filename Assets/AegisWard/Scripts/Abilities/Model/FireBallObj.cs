using UnityEngine;

public class FireBallObj : MonoBehaviour
{
    [SerializeField] private GameObject exploisonPrefab;

    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
