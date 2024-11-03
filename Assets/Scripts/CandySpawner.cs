using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject[] candiesPrefab;

    [SerializeField] private Transform[] spawnPts;

    private void Awake()
    {
        int totalCandies = Random.Range(0,spawnPts.Length);
        List<int> indices = new();
        for(int i = 0; i < totalCandies;)
        {
            int spawnPtIndex = Random.Range(0, spawnPts.Length);
            int candyIndex = Random.Range(0, candiesPrefab.Length);
            if (!indices.Contains(spawnPtIndex))
            {
                indices.Add(spawnPtIndex);
                Instantiate(candiesPrefab[candyIndex], spawnPts[spawnPtIndex].transform.position, Quaternion.identity);
                i++;
            }
            else
            {
                continue;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
