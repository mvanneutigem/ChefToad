using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    //FIELDS

    //METHODS
    public void ExitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene(5);
    }

    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
