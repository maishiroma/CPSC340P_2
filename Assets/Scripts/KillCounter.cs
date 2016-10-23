using UnityEngine;

public class KillCounter : MonoBehaviour {

    public int kill_count = 0;
    
    // sets values to position counter
    // default values set as following
    public int pos_x = 40;
    public int pos_y = 285;

    public GUIStyle gui_style = new GUIStyle();

	private Vector3 posOfGUI;							//Used to dynamically shape the font's position on screens <= 1600x900 resolution

    void Start() {
		posOfGUI = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
    }

    public void scoreKill() {
        kill_count++;
       	GameObject.FindGameObjectWithTag("RoundSystem").GetComponent<RoundSystem>().checkIfTargetReached();
    }

    public void resetCounter() {
        kill_count = 0;
    }

    void OnGUI() {
		GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new Vector3( Screen.width / 1600.0f, Screen.height / 900.0f, 1.0f ) );
		// display kills only when they are obtained
        if (kill_count == 1)
			GUI.Label(new Rect(pos_x, pos_y, posOfGUI.x, posOfGUI.y), kill_count.ToString() + " KO", gui_style);
        else if  (kill_count > 1)
			GUI.Label(new Rect(pos_x, pos_y,posOfGUI.x, posOfGUI.y), kill_count.ToString() + " KOs", gui_style);
    }
}
