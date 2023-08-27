using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnInterval = 2.0f;
    public float spawnDelay = 2.0f;

    public GameObject enemyPrefab;

    // start spawning enemies based spawnInterval
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation.normalized);
    }
}
