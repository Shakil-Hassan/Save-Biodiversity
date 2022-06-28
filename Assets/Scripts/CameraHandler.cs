 using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform cameraTarget;
    public float smoothSpeed;
    public Vector3 offset;

    

    void Start()
    {
       
        offset = transform.position - cameraTarget.position;

    }

    void LateUpdate()
    {
        
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + cameraTarget.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        
        
    }

    
}
