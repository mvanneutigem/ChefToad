using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    //FIELDS
    public Transform panel;

    //METHODS
    public void ExitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        //set first scene
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void LevelsMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }

    public void loadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        int sceneIndex = PlayerPrefs.GetInt("PreviousScene");
       // Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        int sceneIndex = PlayerPrefs.GetInt("NextScene");
        // Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
