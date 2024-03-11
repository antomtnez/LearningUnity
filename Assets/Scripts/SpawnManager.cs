using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
            SpawnRandomAnimalInRange();
    }

    void SpawnRandomAnimalInRange()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
