using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManageBGM : MonoBehaviour {

    private static ManageBGM instance = null;
    
    public static ManageBGM Instance {
    get { return instance;  }
    }

    void Update() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded() {
        if(SceneManager.GetActiveScene().name == "MainScene") {
            if (GameObject.Find("MenuBGM")) {
                Destroy(this.gameObject);
            }
        }
    }

}
