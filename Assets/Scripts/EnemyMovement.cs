using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private GameObject target;
    public float speed;
    private float minDistance = 1.0f;
    private float range;

    void Start()
    {
        target = GameObject.FindWithTag("Player").gameObject;
    }

	void Update () {
        range = Vector2.Distance(transform.position, target.transform.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
	}
}
