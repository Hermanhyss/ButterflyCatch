using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;                
    public Vector3 offset = new Vector3(0, 3, -6); 
    public float rotationSpeed = 5f;     
    public float smoothTime = 0f;      
    public float verticalRotationLimit = 80f; 

    private Vector3 currentVelocity;       
    private float currentYaw = 0f;         
    private float currentPitch = 0f;      

    void LateUpdate()
    {
        if (target == null) return;
       
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
    
        currentYaw += horizontal;
        currentPitch -= vertical;
        
        currentPitch = Mathf.Clamp(currentPitch, -verticalRotationLimit, verticalRotationLimit);
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        Vector3 targetPosition = target.position + rotation * offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        transform.LookAt(target.position);
    }
}







