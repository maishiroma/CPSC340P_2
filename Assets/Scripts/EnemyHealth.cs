using UnityEngine;
using System.Collections;

//This controls the enemy health when they get hit.
public class EnemyHealth : MonoBehaviour {

	public int numbRainbowPoints;	//How many rainbow nuke points will this enemy give upon being defeated?
	public int amountHealth;		//How much health will this enemy have?
	public string enemyColor;		//What color is associated with the enemy?
	public GameObject[] splatColors;	//Effect on destroying an enemy.

	//Called when the enemy gets hit by a complimentry color.
	public void DepleteHealth()
	{
		amountHealth--;
		GameObject.FindGameObjectWithTag("PowerBar").GetComponent<RainbowNukeShot>().AddToGauge(numbRainbowPoints);
		if(amountHealth <= 0)
			DestroyEnemy();
<<<<<<< HEAD
            GameObject.FindGameObjectWithTag("Counter").GetComponent<KillCounter>().scoreKill();
        }
    }
=======
			
	}
>>>>>>> 82574ee3c0a0526867f1d331b913ba491af7118a

	//This is called to destroy the enemy.
	public void DestroyEnemy()
	{
		//int rand = Random.Range(0,splatColors.Length);
		//Instantiate(splatColors[rand], gameObject.transform.position, Quaternion.identity);

		Destroy(this.gameObject);
	}
}
