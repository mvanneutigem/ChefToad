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
        SceneManager.LoadScene(2);
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene(5);
    }

    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        int sceneIndex = PlayerPrefs.GetInt("PreviousScene");
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
