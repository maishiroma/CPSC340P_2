using UnityEngine;
using System.Collections;

// This will destroy a splat once X amount of time has passed.
public class SplatDestroy : MonoBehaviour {

	void Start()
	{
		Invoke("DestroySplat",10f);
	}

	void DestroySplat()
	{
		Destroy(gameObject);
	}
}
