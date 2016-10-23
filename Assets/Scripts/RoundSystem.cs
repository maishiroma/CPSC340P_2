using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RoundSystem : MonoBehaviour {

    // Round 1: Defeat 10 Enemies
    // Following Rounds: Defeat 5 More than Previous
    // Bonus Round/Boss Fight: Triggers when user sustains three hits (carries over)

    public int current_round = 1;
    public int target_objective = 10;
    public float change_inSpeed;
    
    // position to display current round
    public int pos_x;
    public int pos_y;

    public GUIStyle gui_style = new GUIStyle();

	private Vector3 posOfGUI;							//Used to dynamically shape the font's position on screens <= 1600x900 resolution

    void Start()
    {
		posOfGUI = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
    }

	// Depending on the Scene, changes the logic flow in what happens if the kill count == target_objective
    public void checkIfTargetReached()
    {
        GameObject counter = GameObject.FindGameObjectWithTag("Counter");

		if (counter.GetComponent<KillCounter>().kill_count == target_objective)
		{
			current_round++;

			if(SceneManager.GetActiveScene().name == "MainScene")
			{
				target_objective += 10;

				GameObject[] temp = GameObject.FindGameObjectsWithTag("Spawner");
				GameObject[] splats = GameObject.FindGameObjectsWithTag("Splat");

				for (int i = 0; i < temp.Length; i++) {
					temp[i].GetComponent<EnemySpawner>().enemy_speed += change_inSpeed;
				}

				for (int i = 0; i < splats.Length; i++) {
					splats[i].GetComponent<SplatDestroy>().DestroySplat();
				}

				counter.GetComponent<KillCounter>().resetCounter();
			}
			else
			{
				target_objective += current_round;

				GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyMovement>().speed += change_inSpeed;
			}
		}
			
    }

    void OnGUI()
    {
		GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new Vector3( Screen.width / 1600.0f, Screen.height / 900.0f, 1.0f ) );

		if(SceneManager.GetActiveScene().name == "MainScene")
			GUI.Label(new Rect(pos_x, pos_y, posOfGUI.x, posOfGUI.y), "Round: " + current_round.ToString(), gui_style);
		else
			GUI.Label(new Rect(pos_x, pos_y, posOfGUI.x, posOfGUI.y), "Bonus Round: " + current_round.ToString(), gui_style);
    }

}
