using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
    
    public int _scene;

    void OnTriggerEnter(Collider col)
    {
        int prevLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("PreviousScene", prevLevel);
        SceneManager.LoadScene(_scene);
    }
}
