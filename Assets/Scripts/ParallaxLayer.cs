using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxEffectMultiplier; // Adjust this per layer for speed (e.g., 0.1 for far layers, 0.5 for close ones)

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
