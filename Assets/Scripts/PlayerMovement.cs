using UnityEngine;
using System.Collections;

// This class will simply have the player moving around as well as shooting.
// I used http://answers.unity3d.com/questions/597800/top-down-2d-movement-without-being-affected-by-rot.html to help me for the rotation and movement. 

public class PlayerMovement : MonoBehaviour {

	public GameObject paintBallObj;		//The GameObject used to represent the shot.
	public GameObject paintBallSpawn;	//Where the shot will spawn when shooting
	public float moveSpeed;				//How fast will the player move?
	public float shotSpeed;				//How fast is the shot going?
	public float shotDelay;				//How much delay is in between each shot?
	public bool inCoolDown;				//Is the player currently in cooldown?

	//Makes sure there's only one player in the room.
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		//This part controls the movement of the player by allowing for 8 directional movement
		Vector2 movePos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
		transform.position += Vector3.right * movePos.x;
		transform.position += Vector3.up * movePos.y;

		//This part takes the rotation of the player to match the position of the mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 playerRotationPos = mousePos - transform.position;
		float angle = Mathf.Atan2(playerRotationPos.y, playerRotationPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

		//This part does the shooting mechanic. The player shoots a shot that goes toward the mouse position.
		if(inCoolDown == false)
		{
			if(Input.GetMouseButtonUp(0) == true)
			{
				GameObject shot = (GameObject)Instantiate(paintBallObj, paintBallSpawn.transform.position, Quaternion.identity);
				shot.GetComponent<Rigidbody2D>().velocity = mousePos * shotSpeed;
				inCoolDown = true;
				Invoke("ResetCoolDown", shotDelay);
			}
		}
	}

	//Takes the player out of cool down mode.
	void ResetCoolDown()
	{
		inCoolDown = false;
	}

}
