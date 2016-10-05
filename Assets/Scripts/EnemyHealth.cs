using UnityEngine;
using System.Collections;

//This controls the enemy health when they get hit.
public class EnemyHealth : MonoBehaviour {

	public int amountHealth;	//How much health will this enemy have?
	public string enemyColor;	//What color is associated with the enemy?

	//Called when the enemy gets hit by a complimentry color.
	public void DepleteHealth()
	{
		amountHealth--;
		if(amountHealth <= 0)
		{
			DestroyEnemy();
		}
	}

	//This is called to destroy the enemy.
	void DestroyEnemy()
	{
		Destroy(this.gameObject);
	}
}
