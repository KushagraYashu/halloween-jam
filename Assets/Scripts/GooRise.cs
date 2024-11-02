using UnityEngine;

public class GooRise : MonoBehaviour
{
    public float initialRiseSpeed = 0.5f;
    public float riseAcceleration = 0.1f;
    public float maxRiseSpeed = 5f;
    public float waveFrequency = 1f;
    public float waveAmplitude = 0.5f;

    private float currentRiseSpeed;
    private float elapsedTime;

    private void Start()
    {
        currentRiseSpeed = initialRiseSpeed;
        elapsedTime = 0f;
    }

    private void Update()
    {
        currentRiseSpeed = Mathf.Min(currentRiseSpeed + riseAcceleration * Time.deltaTime, maxRiseSpeed);
        float newYPosition = transform.position.y + currentRiseSpeed * Time.deltaTime;
        float newXPosition = Mathf.Sin(elapsedTime * waveFrequency) * waveAmplitude;
        transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
        elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("kill player");
            GameManager.Instance.GameOver(); // Trigger game over on collision
        }
    }
}
