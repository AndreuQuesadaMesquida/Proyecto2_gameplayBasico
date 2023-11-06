using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManeger : MonoBehaviour
{

    [SerializeField] private GameObject[] animalPrefabsArray;
    private int animalIndex;

    private float spawnRangeX = 15f;
    private float spawnPosZ = 20f;

    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, animalPrefabsArray.Length);
        Instantiate(animalPrefabsArray[animalIndex], RandomSpawnPos(), Quaternion.Euler(0, 180, 0));
    }

    private Vector3 RandomSpawnPos()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        return new Vector3(randomX, 0, spawnPosZ);
    }
}
