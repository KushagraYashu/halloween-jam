using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float followSpeed = 0.1f; // Speed at which the background follows the camera

    private Vector3 offset; // Offset from the camera

    private void Start()
    {
        offset = transform.position - cameraTransform.position; // Calculate the initial offset
    }

    private void LateUpdate()
    {
        // Calculate the new position for the background
        Vector3 targetPosition = cameraTransform.position + offset;

        // Interpolate the background's position to create a smooth follow effect
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }
}
