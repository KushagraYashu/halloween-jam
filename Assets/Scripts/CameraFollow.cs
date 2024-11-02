using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing speed
    public Vector3 offset; // Offset from the player
    public float startHeight = 10f; // Height above the player before camera starts following

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = player.position + offset;

            // Check if the player has moved above the starting height
            if (player.position.y > startHeight)
            {
                // Only update the Y position of the camera to follow the player
                desiredPosition.x = transform.position.x; // Lock X position
                desiredPosition.z = transform.position.z; // Keep the Z position unchanged
                // Smoothly interpolate between the camera's current position and the desired position
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);
            }
        }
    }
}
