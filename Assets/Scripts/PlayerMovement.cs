using UnityEngine;
using System.Collections;

// This class will simply have the player moving around.
// I used http://answers.unity3d.com/questions/597800/top-down-2d-movement-without-being-affected-by-rot.html to help me for the rotation and movement. 
public class PlayerMovement : MonoBehaviour {

	public GameObject playerHealth;		//The gameobject used to keep track of the player health.
	public float moveSpeed;				//How fast will the player move?

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


	}

	// If the player runs into an enemy/boss
	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
			playerHealth.GetComponent<HealthCounter>().TakeDamage();
	}



}
