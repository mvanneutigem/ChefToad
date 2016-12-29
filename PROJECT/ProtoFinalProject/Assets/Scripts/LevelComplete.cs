using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
    
    public int _scene;

    void OnTriggerEnter(Collider col)
    {
            SceneManager.LoadScene(_scene);
    }
}
