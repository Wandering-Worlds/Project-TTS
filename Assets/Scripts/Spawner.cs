using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject enemyType;
    private float spawnInterval = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
    }


    // Update is called once per frame
    void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(enemyType,transform.position,Quaternion.identity);
        
    }
}
