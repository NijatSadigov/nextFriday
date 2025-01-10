using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] trains = new GameObject[3];
    [SerializeField] GameObject[] points = new GameObject[3];
    [SerializeField] float spawnInterval = 2f; // Time between spawns
    [SerializeField] float trainSpeed = 5f; // Speed at which trains move
    private Coroutine spawnCoroutine;

    void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnTrains());
    }

    void OnDisable()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void ClearSpawnedTrains()
    {
        // Iterate over children of the spawner and destroy all trains (not spawn points)
        foreach (Transform child in transform)
        {
            bool isSpawnPoint = false;

            // Check if the child is a spawn point
            foreach (GameObject point in points)
            {
                if (child.gameObject == point)
                {
                    isSpawnPoint = true;
                    break;
                }
            }

            // Destroy only the trains, not the spawn points
            if (!isSpawnPoint)
            {
                Destroy(child.gameObject);
            }
        }
    }

    IEnumerator SpawnTrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject chosenTrain = trains[Random.Range(0, trains.Length)];
            Transform chosenPoint = points[Random.Range(0, points.Length)].transform;

            GameObject spawnedTrain = Instantiate(chosenTrain, chosenPoint.position, Quaternion.identity);
            spawnedTrain.GetComponent<Rigidbody2D>().linearVelocity= Vector2.left * trainSpeed;

            // Parent the train to the spawner for better organization
            spawnedTrain.transform.parent = transform;

            Destroy(spawnedTrain, 10f);
        }
    }
}
