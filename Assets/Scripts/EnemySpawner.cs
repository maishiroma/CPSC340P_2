using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy_prefab;
    public float spawn_rate;
    public float time_interval;

    // range of spawn
    public int left;
    public int right;
    public int top;
    public int bottom;

	
    void Start()
    {
        InvokeRepeating("SpawnEnemy", time_interval, spawn_rate);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy_prefab, new Vector3(Random.Range(left, right), Random.Range(top, bottom), z_depth), Quaternion.identity);
    }
}
