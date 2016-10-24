using UnityEngine;
using System.Collections;

//This contains the properties for the shots being fired.
public class ShotProperties : MonoBehaviour {

	public float timeToDissapear;		//How long will the shot last before dissapearing?
	public string shotColor;			//What is the color of the shot?
	public Sprite[] shotColorSprites;	//What look is the current sprite at?

    //Starts the countdown for the shot to dissapear
    void Start () 
	{
		Invoke("DestroyShot",timeToDissapear);
	}

	//If the enemy is of complimentry color to the shot, it will take damage. Else, it will speed it up.
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			if(CheckIfComplimentryColor(other.gameObject.GetComponent<EnemyHealth>().enemyColor) == true)
				other.gameObject.GetComponent<EnemyHealth>().DepleteHealth();
			else
				other.gameObject.GetComponent<EnemyMovement>().speed += 0.2f;
				
		}
		else if(other.gameObject.tag == "Boss")
		{
			if(CheckIfComplimentryColor(other.gameObject.GetComponent<BossAI>().GetBossColor()) == true)
				other.gameObject.GetComponent<BossAI>().OnSuccessHit();
			else
				other.gameObject.GetComponent<BossAI>().UnSucessfullHit();
		}

		DestroyShot();
	}

	//Gets rid of the shot
	void DestroyShot()
	{
		Destroy(gameObject);
	}

	//This is called when the shots are getting shot.
	public void ChangeColorSprite()
	{
		switch(shotColor)
		{
			case "Yellow":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[0];
				break;
			case "Green":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[1];
				break;
			case "Blue":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[2];
				break;
			case "Purple":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[3];
				break;
			case "Red":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[4];
				break;
			case "Orange":
				gameObject.GetComponent<SpriteRenderer>().sprite = shotColorSprites[5];
				break;
		}
	}

	//checks if the passed in color is a complimentry color of the shot.
	bool CheckIfComplimentryColor(string otherColor)
	{
		switch(otherColor)
		{
			case "Yellow":
				if(shotColor == "Purple")
					return true;
				break;
			case "Green":
				if(shotColor == "Red")
					return true;
				break;
			case "Blue":
				if(shotColor == "Orange")
					return true;
				break;
			case "Purple":
				if(shotColor == "Yellow")
					return true;
				break;
			case "Red":
				if(shotColor == "Green")
					return true;
				break;
			case "Orange":
				if(shotColor == "Blue")
					return true;
				break;
		}
		return false;
	}
}
