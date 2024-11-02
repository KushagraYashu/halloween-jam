using UnityEngine;
using UnityEngine.UI;

public class ImagePulseAndRotate : MonoBehaviour
{
    public Image imageToPulseAndRotate;
    public float pulseSpeed = 1f;
    public float pulseAmount = 0.1f;
    public float rotationSpeed = 0.5f;
    public float rotationAmount = 5f; // Adjust this to control the rotation angle

    private Vector3 originalScale;
    private float originalRotation;

    void Start()
    {
        originalScale = imageToPulseAndRotate.transform.localScale;
        originalRotation = imageToPulseAndRotate.transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float scaleFactor = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount + 1f;
        float rotationAmountSin = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;

        imageToPulseAndRotate.transform.localScale = originalScale * scaleFactor;
        imageToPulseAndRotate.transform.rotation = Quaternion.Euler(0, 0, originalRotation + rotationAmountSin);
    }
}