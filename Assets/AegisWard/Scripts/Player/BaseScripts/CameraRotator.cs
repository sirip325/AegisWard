using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour
{
   [SerializeField] private float _turnSpeed = 180f;
   private Vector2 _currentRotation;

   private float angleX;

   private void Update()
   {
      var currentAngleY = _currentRotation.x * _turnSpeed * Time.deltaTime;
      transform.Rotate(new Vector3(0f, currentAngleY, 0f));
      
      angleX += -_currentRotation.y * _turnSpeed * Time.deltaTime;
      angleX = Mathf.Clamp(angleX, -90f, 90f);
      
      Camera.main.transform.localRotation = Quaternion.Euler(angleX,0f, 0f);
   }
   
   public void OnLook(InputAction.CallbackContext context)
   {
      _currentRotation = context.ReadValue<Vector2>();
   }
}
