using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [field:SerializeField,
    Header("Movement Speed")] 
    public float _speed { get; private set; }

    private Vector2 _dir;


    private void Update()
    {
        var newDir = new Vector3(_dir.x,0f, _dir.y);
        transform.Translate(newDir * (_speed * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _dir = context.ReadValue<Vector2>();
    }
}
