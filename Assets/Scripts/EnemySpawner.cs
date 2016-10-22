using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy_prefab;
    public float spawn_rate;
    public float time_interval;
    public float enemy_speed;

    // range of spawn
    public int left;
    public int right;
    public int top;
    public int bottom;
    public int z_depth;

	
    void Start()
    {
        InvokeRepeating("SpawnEnemy", time_interval, spawn_rate);
    }

    void SpawnEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(enemy_prefab, new Vector3(Random.Range(left, right), Random.Range(top, bottom), z_depth), Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().speed += enemy_speed;
    }
}
