using UnityEngine;
using System.Collections.Generic;

//	This script controls how the boss does the color swap mechanic.
/*	When the boss spawns (and after ever success pattern), the boss flashes N colors (N starts at one) and the player has to hit the boss in the order that the
 *  boss flashed its colors. After it's done (by showing a nautral color), the player can then hit the boss in the order that the boss flashed the colors.
 *  Once the player has hit the boss with all of the colors that it showed, it repeats with N incrementing up by one.
 */

public class BossAI : MonoBehaviour {

	public Sprite[] bossColors;										//What are the sprites for the boss?
	public List<string> colorList = new List<string>();				//What colors does the boss contain?
	public int currRound = 1;										//What round is the boss currently on?
	public bool inColorFlash = false;								//Is the boss currently flashing its colors?
	public bool canShoot = false;									//Is the boss vulnerable to attacks now?

	//This is called to allow the boss to flash the colors to the player.
	void Update () 
	{
		if(inColorFlash == false && canShoot == false)
		{
			inColorFlash = true;
			int rand = Random.Range(0,6);

			switch(rand)
			{
			case 0:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[1];
				colorList.Add("Yellow");
				break;
			case 1:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[2];
				colorList.Add("Green");
				break;
			case 2:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[3];
				colorList.Add("Blue");
				break;
			case 3:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[4];
				colorList.Add("Purple");
				break;
			case 4:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[5];
				colorList.Add("Red");
				break;
			case 5:
				gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[6];
				colorList.Add("Orange");
				break;
			}

			Invoke("ResetColorFlash",2f);
		}
	}

	//Called in the Update function to run the Update function again as well as checking if the color list is equal to the curr round number.
	void ResetColorFlash()
	{
		inColorFlash = false;

		if(colorList.Count == currRound)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = bossColors[0];
			canShoot = true;
		}
	}

	//Returns the first color in the boss's color list
	public string GetBossColor()
	{
		if(colorList.Count != 0)
			return colorList[0];
		else
			return "Yellow";
	}

	//Upon a successful hit, decrements the list of colors for the player to hit. If the color list is empty, the boss's round increments.
	public void OnSuccessHit()
	{
		if(colorList.Count != 0 && canShoot == true)
		{
			colorList.Remove(colorList[0]);
			GameObject.FindGameObjectWithTag("Counter").GetComponent<KillCounter>().scoreKill();

			if(colorList.Count == 0)
			{
				canShoot = false;
				currRound++;
			}
		}
	}


}
