using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ColorSystem() {
        SceneManager.LoadScene("SystemsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
