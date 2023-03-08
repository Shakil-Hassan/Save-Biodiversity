using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float smoothSpeed;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - cameraTarget.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}