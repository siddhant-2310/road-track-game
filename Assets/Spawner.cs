using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign in Inspector
    public GameObject coinPrefab;  // Assign in Inspector
    public Transform spawnPoint;   // Assign in Inspector

    public float spawnRate = 1.5f; // Time between spawns
    public float minX = -6f, maxX = 6f; // X range for spawning

    void Start()
    {
        Debug.Log("Spawner script started!"); // Debugging
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void SpawnObject()
    {
        Debug.Log("Spawning Object..."); // Debugging

        // Check if prefabs are assigned
        if (enemyPrefab == null || coinPrefab == null)
        {
            Debug.LogError("ERROR: Prefabs not assigned in Inspector!");
            return;
        }

        // Randomly choose to spawn an enemy or coin
        GameObject objectToSpawn = Random.value > 0.5f ? enemyPrefab : coinPrefab;

        // Generate random X position within the road limits
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 1f, spawnPoint.position.z);

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log($"Spawned: {spawnedObject.name} at {spawnPosition}");

        Destroy(spawnedObject, 10f); // Destroy after 10s to avoid memory overflow
    }
}
