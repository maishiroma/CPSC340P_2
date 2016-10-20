using UnityEngine;
using System.Collections;

//This will keep track of the amount of power the player can have before unleashing a screen nuke by hitting E
public class RainbowNukeShot : MonoBehaviour {

	public Sprite emptyGauge;			//The sprite that represents the empty gauge.
	public Sprite[] gaugeSprites;		//The images that represent the gauge filling up.
	public int gaugeCounter;			//The current amount that the gauge has.
	public bool isFull;					//Is the gauge full?

	private int currGaugeIndex;			//The current sprite index that the gauge is displaying
	private int nextGaugeMark = 5;		//The next value that will mark where the gauge visual will change.

	//Adds the specified points to the gauge counter. If it's above a certain threshold, the gauge's GUI is updated.
	public void AddToGauge(int numb)
	{
		if(isFull == false)
		{
			gaugeCounter += numb;
			if(gaugeCounter >= nextGaugeMark)
			{
				ChangeGaugeVisual();
				if(gaugeCounter >= 100)
					isFull = true;
			}
		}
	}

	//Activates the nuke while resetting the gauge.
	public void ActivateRainbowNuke()
	{
		GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0; i < allEnemies.Length; i++)
			allEnemies[i].GetComponent<EnemyHealth>().DestroyEnemy();

		gaugeCounter = 0;
		nextGaugeMark = 5;
		currGaugeIndex = 0;
		gameObject.GetComponent<SpriteRenderer>().sprite = emptyGauge;
		isFull = false;
	}

	//Changes the gauge's visual to represent how much it's filled
	void ChangeGaugeVisual()
	{
		if(currGaugeIndex < gaugeSprites.Length)
		{
			currGaugeIndex++;
			gameObject.GetComponent<SpriteRenderer>().sprite = gaugeSprites[currGaugeIndex];
			nextGaugeMark += 5;
		}
	}
}
