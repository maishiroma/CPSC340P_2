using UnityEngine;
using System.Collections;

// This script takes care of the player shooting.
// I used http://answers.unity3d.com/questions/591383/fire-at-mouse-position-2d-game.html to help with this.
public class PlayerShooting : MonoBehaviour {

	public GameObject paintBallObj;		//The GameObject used to represent the shot.
	public GameObject paintBallSpawn;	//Where the shot will spawn when shooting
	public float shotSpeed;				//How fast is the shot going?
	public float shotDelay;				//How much delay is in between each shot?
	public bool inCoolDown;				//Is the player currently in cooldown?
	public string[] shotColors;			//All of the colors the player has?
	public int currColorIndex;			//What color is the player currently on?

	//This part does the shooting mechanic. The player shoots a shot that moves in the direction the player is facing.
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.LeftShift) == true)
		{
			CycleColorWheel();
			print(shotColors[currColorIndex]);
		}

		if(inCoolDown == false)
		{
			if(Input.GetMouseButtonUp(0) == true)
			{
				//This part takes the mouse position and sets it to be relative to the game space itself.
				Vector3 mouseAim = Input.mousePosition;
				mouseAim.z = transform.position.z - Camera.main.transform.position.z;
				mouseAim = Camera.main.ScreenToWorldPoint(mouseAim);

				//The shot is rotated in order to position it for firing at a set speed no matter the disitance.
				Quaternion shotRotation = Quaternion.FromToRotation(Vector3.up, mouseAim - transform.position);

				//The shot is created and moved.
				GameObject shot = (GameObject)Instantiate(paintBallObj, paintBallSpawn.transform.position, shotRotation);
				shot.GetComponent<ShotProperties>().shotColor = shotColors[currColorIndex];
				shot.GetComponent<ShotProperties>().ChangeColorSprite();
				shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * shotSpeed);

				//After firing a shot, the player is in cool down, where they have to wait for shotDelay in order to shoot again.
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

	//Shifts the color wheel to a different color.
	void CycleColorWheel()
	{
		if(currColorIndex == shotColors.Length - 1)
			currColorIndex = 0;
		else
			currColorIndex++;
	}
}
