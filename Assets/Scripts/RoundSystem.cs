using UnityEngine;
using System.Collections;

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
    public int screen_w = 16;
    public int screen_h = 9;

    public GUIStyle gui_style = new GUIStyle();

    void Start()
    {

        gui_style.fontSize = 52;

    }

    public void checkIfTargetReached()
    {
        GameObject counter = GameObject.FindGameObjectWithTag("Counter");


        if (counter.GetComponent<KillCounter>().kill_count == target_objective)
        {
            current_round++;
            target_objective += 10;

            GameObject[] temp = GameObject.FindGameObjectsWithTag("Spawner");

            for (int i = 0; i < temp.Length; i++) {
                temp[i].GetComponent<EnemySpawner>().enemy_speed += change_inSpeed;
            }

            counter.GetComponent<KillCounter>().resetCounter();

        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(pos_x, pos_y, screen_w, screen_h), "Round: " + current_round.ToString(), gui_style);
    }

}
