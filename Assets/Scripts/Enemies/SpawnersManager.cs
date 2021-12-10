using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    [Header("GameObject References")]
    [Tooltip("The enemy prefabs list that will use each spawner")]
    public GameObject[] enemyPrefab;
    public Transform target;

    [Header("Spawn Variables")]
    [Tooltip("The maximum number of enemies that can be spawned from this spawner")]
    public int[] maxSpawn;
    [Tooltip("Ignores the max spawn limit if true")]
    public bool spawnInfinite = true;
    [Tooltip("The time delay between spawning enemies")]
    public float spawnDelay = 2.5f;
    [Tooltip("The amount by which spawn delay decreases")]
    public float spawnDelayDelta = 0f;
    [Tooltip("The object to make projectiles child objects of.")]
    public Transform projectileHolder = null;
    [Tooltip("The amount by which enemies' speed increases. Leave it at 0 if you do not want enemies to speed up")]
    public float speedDelta = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount != enemyPrefab.Length || transform.childCount != maxSpawn.Length)
        {
            Debug.LogError("There is inequal amount of prefabs in the list and child spawner prefabs.");
        }
        int count = 0;
        EnemySpawner spawner = null;
        foreach (Transform child in transform)
        {
            spawner = child.GetComponent<EnemySpawner>();
            spawner.enemyPrefab = enemyPrefab[count];
            spawner.maxSpawn = maxSpawn[count++];
            spawner.spawnInfinite = spawnInfinite;
            spawner.spawnDelay = spawnDelay;
            spawner.projectileHolder = projectileHolder;
            spawner.target = target;
            spawner.speedDelta = speedDelta;
            spawner.spawnDelayDelta = spawnDelayDelta;
        }
    }
}
