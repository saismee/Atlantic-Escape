using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public float spawnTime = 0;
    private float spawnCooldown = 0;

    [SerializeField] private GameObject prefab;

    private void Update()
    {
        if (spawnTime == 0) return;
        // prevents spawning infinitely

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown > 0) return;

        spawnCooldown = spawnTime;
        GameObject newPrefab = Instantiate(prefab, transform);
        newPrefab.transform.position = new Vector2(30, Random.Range(-5.5f, 5.5f));
    }
}
