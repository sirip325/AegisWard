using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PathFinder : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float detectDistance = 5f;
    [SerializeField]
    private Transform target;

    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
    private void FixedUpdate()
    {   
        Vector3 toTarget = (target.position - transform.position).normalized;
        Vector3 desiredVelocity = toTarget * speed;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, detectDistance))
        {
            
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            
            Vector3 avoidDirection = Vector3.Reflect(transform.forward, hit.normal);
            Debug.DrawRay(hit.point, avoidDirection * 3f, Color.red);
            
            desiredVelocity = (toTarget + avoidDirection).normalized * speed;
        }
        
        _rb.MovePosition(_rb.position + desiredVelocity * Time.fixedDeltaTime);
        
        if (desiredVelocity != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(desiredVelocity), 0.1f);
    }
}
