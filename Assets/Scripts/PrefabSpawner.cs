using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [Tooltip("Time in seconds between spawns")]
    public float spawnTime = 0;
    private float spawnCooldown = 0;

    [Tooltip("Time in seconds before first spawn")]
    [SerializeField] private float spawnDelay = 2;

    [Tooltip("The prefab to be instantiated")]
    [SerializeField] private GameObject prefab;

    [Tooltip("The target for spawned enemies. Leave blank if this doesn't spawn BaseEnemy")]
    [SerializeField] private Transform target;

    private void Start()
    {
        spawnCooldown = spawnDelay;
    }

    private void Update()
    {
        if (spawnTime == 0) return;
        // prevents spawning infinitely

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown > 0) return;

        spawnCooldown = spawnTime;
        GameObject newPrefab = Instantiate(prefab, new Vector2(30, Random.Range(-5f, 5f)), transform.rotation, transform);

        if (!newPrefab.TryGetComponent(out BaseEnemy enemy)) return;
        // find if we're creating an enemy, otherwise return
        enemy.target = target;
    }
}
 