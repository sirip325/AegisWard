using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody _rb;
    private bool _isGrounded = false;
    
    private void Start() => _rb = GetComponent<Rigidbody>();

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!_isGrounded) return;
        
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }
}
