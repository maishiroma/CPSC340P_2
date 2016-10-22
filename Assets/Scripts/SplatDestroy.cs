using UnityEngine;
using System.Collections;

// This will destroy a splat once the end of the round happens.
public class SplatDestroy : MonoBehaviour {

	public void DestroySplat()
	{
		Destroy(gameObject);
	}
}
