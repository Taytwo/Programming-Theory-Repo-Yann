using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    private float minDelay = 1f;
    private float maxDelay = 2.5f;
    private Vector3 topRightSpawn = new Vector3(43f, 0, 11.5f);
    private Vector3 topLeftSpawn = new Vector3(-43f, 0, 6.5f);
    private Vector3 middleRightSpawn = new Vector3(43f, 0, 1f);
    private Vector3 middleLeftSpawn = new Vector3(-43f, 0, -4f);
    private Vector3 bottomRightSpawn = new Vector3(43f, 0, -9.3f);
    private Vector3 bottomLeftSpawn = new Vector3(-43f, 0, -14.3f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCar(topRightSpawn, -90));
        StartCoroutine(spawnCar(middleRightSpawn, -90));
        StartCoroutine(spawnCar(bottomRightSpawn, -90));
        StartCoroutine(spawnCar(topLeftSpawn, 90));
        StartCoroutine(spawnCar(middleLeftSpawn, 90));
        StartCoroutine(spawnCar(bottomLeftSpawn, 90));
    }

    IEnumerator spawnCar (Vector3 spawnPos, float rotateValue)
    {
        while (true)
            {
                yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                Instantiate(cars[Random.Range(0, 4)], spawnPos, transform.rotation * Quaternion.Euler (0f,rotateValue, 0f));
            }

    }
}
