using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float spawnDistance = 50f;

    public Transform levelStart;
    public Transform[] levelParts;

    private Transform lastLevelEnd;

    [SerializeField] List<GameObject> levelPartsList;

    private void Awake()
    {
        lastLevelEnd = levelStart.Find("LevelEnd").transform;
    }

    public void LevelPartSpawn()
    {
        int index = Random.Range(0, levelParts.Length);
        var newLevelSpawned = Instantiate(levelParts[index], lastLevelEnd.position, Quaternion.identity);
        levelPartsList.Add(newLevelSpawned.gameObject);
        lastLevelEnd = newLevelSpawned.Find("LevelEnd").transform;
        DestroyCheck();
    }

    public void DestroyCheck()
    {
        foreach (var levelPart in levelPartsList)
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, levelPart.transform.position) > spawnDistance)
            {
                Destroy(levelPart);
                levelPartsList.Remove(levelPart);
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
            if (Vector3.Distance(GameManager.Instance.player.transform.position, lastLevelEnd.position) < spawnDistance)
            {
                LevelPartSpawn();
            }
        }
}
