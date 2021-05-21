using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySpawnerEnemies : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Transform spawnPoint;
    [Range(1, 1000)]
    public int numberOfEnemies = 1;
    [Range(1,60)]
    public float spawnDelay = 1;

    private int counter = 0;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    private void SpawnEnemy()
    {
        Instantiate(prefabEnemy, spawnPoint.position, spawnPoint.rotation);
        counter++;
        if (counter == numberOfEnemies)
        {
            CancelInvoke();
        }
    }
}
