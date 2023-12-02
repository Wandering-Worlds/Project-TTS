using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] spawnerList;
    [SerializeField] protected GameObject[] enemyType;

    private int randomSpawnIndex;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy1), 0, spawnInterval);
        InvokeRepeating(nameof(SpawnEnemy2), 0, spawnInterval * 2);
    }

    // Update is called once per frame
    private void SpawnEnemy1()
    {
        randomSpawnIndex = Random.Range(0, spawnerList.Length);
        Instantiate(enemyType[0], spawnerList[randomSpawnIndex].transform.position, Quaternion.identity);
    }

    private void SpawnEnemy2()
    {
        randomSpawnIndex = Random.Range(0, spawnerList.Length);
        Instantiate(enemyType[1], spawnerList[randomSpawnIndex].transform.position, Quaternion.identity);
    }
}
