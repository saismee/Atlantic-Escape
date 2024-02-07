using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] warnings;

    public float spawnTime = 0;
    private float spawnCooldown = 0;

    private void Update()
    {
        if (spawnTime == 0) return;
        // prevents spawning infinitely

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown > 0) return;

        spawnCooldown = spawnTime / GameManager.Instance.difficulty;

        GameObject newPrefab = Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform);
        newPrefab.transform.position = new Vector2(50, Random.Range(-newPrefab.transform.position.y, newPrefab.transform.position.y));

        Obstacle obstacle = newPrefab.GetComponent<Obstacle>();
        GameObject newWarning = Instantiate(warnings[(int)obstacle.warningType]);
        newWarning.transform.position = new Vector2((Camera.main.orthographicSize * Screen.width / Screen.height) -1.25f, newPrefab.transform.position.y + obstacle.yOffset);
    }
}
