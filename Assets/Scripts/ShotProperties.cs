using UnityEngine;
using System.Collections;

//This contains the properties for the shots being fired.

public class ShotProperties : MonoBehaviour {

	public float timeToDissapear;		//How long will the shot last before dissapearing?

	//Starts the countdown for the shot to dissapear
	void Start () 
	{
		Invoke("DestroyShot",timeToDissapear);	
	}

	void Update () 
	{
		
	}

	//Gets rid of the shot
	void DestroyShot()
	{
		Destroy(gameObject);
	}
}
