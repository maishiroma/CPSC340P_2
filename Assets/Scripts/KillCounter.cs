using UnityEngine;
using System.Collections;

public class KillCounter : MonoBehaviour {

    public int kill_count = 0;
    
    // sets values to position counter
    public int pos_x;
    public int pos_y;
    public int screen_w;
    public int screen_h;

    public GUIStyle gui_style = new GUIStyle();

    void Start() {

        gui_style.fontSize = 30;
        gui_style.font = (Font)Resources.Load("Fonts/Painterz/Painterz.tff");

    }

    public void scoreKill() {
        kill_count++;
    }

    void OnGUI() {
        if (kill_count == 1)
            GUI.Label(new Rect(pos_x, pos_y, screen_w, screen_h), kill_count.ToString() + " KO", gui_style);
        else
            GUI.Label(new Rect(pos_x, pos_y, screen_w, screen_h), kill_count.ToString() + " KOs", gui_style);
    }
}
