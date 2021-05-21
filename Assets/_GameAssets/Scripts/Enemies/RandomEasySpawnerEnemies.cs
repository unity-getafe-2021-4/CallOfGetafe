using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEasySpawnerEnemies : MonoBehaviour
{
    public GameObject[] prefabsEnemy;
    public Transform spawnPoint;
    [Range(1, 1000)]
    public int numberOfEnemies = 1;
    [Range(1, 60)]
    public float spawnDelay = 1;

    private int counter = 0;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    private void SpawnEnemy()
    {
        Instantiate(
            prefabsEnemy[Random.Range(0,prefabsEnemy.Length)], 
            spawnPoint.position, 
            spawnPoint.rotation);
        counter++;
        if (counter == numberOfEnemies)
        {
            CancelInvoke();
        }
    }
}
