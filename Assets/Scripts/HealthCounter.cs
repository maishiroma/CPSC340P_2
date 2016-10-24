using UnityEngine;
using System.Collections;

/*	This keeps track of the player's health as well as displaying it to the screen. 
 */
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour {

	public int currHealthIndex = 3;
	public bool inviniFrames = false;
	public int inviniFramesLength = 2;
	public Sprite[] healthGUI;
	public AudioClip hitSound = new AudioClip();

	//Constantly checks if the player has taken damage. If so, it updates the GUI for it. If it falls below 0, the game switches to either the Bonus Scene ot
	// the GameOver Scene
	void Update () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = healthGUI[currHealthIndex];
		if(currHealthIndex == 0)
		{
			if(SceneManager.GetActiveScene().name == "MainScene")
				SceneManager.LoadScene("BonusScene");
			else
				SceneManager.LoadScene("GameOver");
		}
	}

	//This is called in PlayerMovement when the player hits an enemy. They also get X numb of invinicible frames.
	public void TakeDamage()
	{
		if(inviniFrames == false)
		{
			currHealthIndex--;
			inviniFrames = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
			GameObject.Find("GameBGM").GetComponent<AudioSource>().PlayOneShot(hitSound,1f);
			StartCoroutine(ResetInviniFrames());
		}
	}

	//Resets the inviniFrames back to normal.
	IEnumerator ResetInviniFrames()
	{
		yield return new WaitForSeconds(inviniFramesLength);
		inviniFrames = false;
		GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
	}
}
