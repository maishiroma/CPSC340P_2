using UnityEngine;
using System.Collections;

// This controls the GUI used for the color selecting.
public class ColorSelect : MonoBehaviour {

	public Sprite[] colorSprites;		//What sprites are there to represent the color that the player is on?

	// Changes the sprite to the approperiate color
	public void ChangeColorSprite(int index)
	{
		/*	
		 * 	0 = Yellow
		 *  1 = Green
		 * 	2 = Blue
		 *  3 = Purple
		 *  4 = Red
		 *  5 = Orange
		 */

		gameObject.GetComponent<SpriteRenderer>().sprite = colorSprites[index];
	}
}
