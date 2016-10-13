using UnityEngine;
using System.Collections;

// This simply expands the rainbow nuke so that it enalrgens for 1 seconds and goes away.
public class RainbowNukeGraphic : MonoBehaviour {

	void Start () 
	{
		Invoke("DestroyObject", 1f);
	}
	
	void Update()
	{
		gameObject.transform.localScale += new Vector3(0.01f,0.01f,0);
	}

	void DestroyObject()
	{
		Destroy(this.gameObject);
	}
}
