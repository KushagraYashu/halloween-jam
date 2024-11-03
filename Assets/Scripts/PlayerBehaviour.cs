using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("candy"))
        {
            GameManager.Instance.scoreManager.AddScoreForCandy(collision.gameObject.GetComponent<CandyClass>().scoreValue);
            GameManager.Instance.candySoundGO.GetComponent<AudioSource>().clip = collision.gameObject.GetComponent<AudioSource>().clip;
            GameManager.Instance.candySoundGO.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
    }
}
