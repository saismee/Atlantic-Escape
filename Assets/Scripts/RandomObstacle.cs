using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    public GameObject[] obstacles;

    public float spawnTime = 0;
    private float spawnCooldown = 0;

    private void Update()
    {
        if (spawnTime == 0) return;
        // prevents spawning infinitely

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown > 0) return;

        spawnCooldown = spawnTime;

        GameObject newPrefab = Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform);
        newPrefab.transform.position = new Vector2(30, Random.Range(-newPrefab.transform.position.y, newPrefab.transform.position.y));
    }
}
