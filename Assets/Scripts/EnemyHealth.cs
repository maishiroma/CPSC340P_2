using UnityEngine;
using System.Collections;

//This controls the enemy health when they get hit.
public class EnemyHealth : MonoBehaviour {

	public int numbRainbowPoints;	//How many rainbow nuke points will this enemy give upon being defeated?
	public int amountHealth;		//How much health will this enemy have?
	public string enemyColor;		//What color is associated with the enemy?
	public GameObject splatColor;	//Effect on destroying an enemy.
    public AudioClip splat_sound;   // Sound Effect for when the enemy dies
    public float vol_scale = 0.7f;  // Volume for FX from 0-1; default at 0.7f
    public AudioSource sound;

    void Start() {
        sound = GetComponent<AudioSource>();
    }

    //Called when the enemy gets hit by a complimentry color.
    public void DepleteHealth()
	{
		amountHealth--;
		GameObject.FindGameObjectWithTag("PowerBar").GetComponent<RainbowNukeShot>().AddToGauge(numbRainbowPoints);
		if(amountHealth <= 0)
		{
            sound.PlayOneShot(splat_sound, vol_scale);
			DestroyEnemy();
            GameObject.FindGameObjectWithTag("Counter").GetComponent<KillCounter>().scoreKill();
		}
    }
    
	//This is called to destroy the enemy.
	public void DestroyEnemy()
	{
		Instantiate(splatColor, gameObject.transform.position, Quaternion.identity);

		Destroy(this.gameObject);
	}
}
