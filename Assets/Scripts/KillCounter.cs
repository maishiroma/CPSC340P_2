using UnityEngine;
using System.Collections;

public class KillCounter : MonoBehaviour {

    public int kill_count = 0;
    
    // sets values to position counter
    // default values set as following
    public int pos_x = 40;
    public int pos_y = 285;
    public int screen_w = 16;
    public int screen_h = 9;

    public GUIStyle gui_style = new GUIStyle();

    void Start() {

        gui_style.fontSize = 52;
        gui_style.font = (Font)Resources.Load("Fonts/Painterz/Painterz.tff");

    }

    public void scoreKill() {
        kill_count++;
    }

    void OnGUI() {
        // display kills only when they are obtained
        if (kill_count == 1)
            GUI.Label(new Rect(pos_x, pos_y, screen_w, screen_h), kill_count.ToString() + " KO", gui_style);
        else if  (kill_count > 1)
            GUI.Label(new Rect(pos_x, pos_y, screen_w, screen_h), kill_count.ToString() + " KOs", gui_style);
    }
}
