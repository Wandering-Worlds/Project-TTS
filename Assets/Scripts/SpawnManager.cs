using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] spawnerList;
    [SerializeField] protected GameObject enemyType;

    private int randomNumber;
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 0, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        randomNumber = Random.Range(0, spawnerList.Length - 1);        
        GameObject Enemy1 = Instantiate(enemyType, spawnerList[randomNumber].transform.position, Quaternion.identity);
    }
}
