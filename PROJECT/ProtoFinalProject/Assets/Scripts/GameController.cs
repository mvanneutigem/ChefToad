using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //FIELDS
    public Text scoreText;
    //public Text ingredientText;
    //public Text LivesText;
    public Text ToadalLivesText;
    public Transform Player;
    public bool ScoreScreen = false;
    public int _toadalLives;
    private int score;
    private int ingredients;
    private int lives;
    //METHODS

	// Use this for initialization
	void Start ()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            _toadalLives = PlayerPrefs.GetInt("ToadalLives");
            score = PlayerPrefs.GetInt("Score");
            UpdateScore();
        }
        ingredients = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (ScoreScreen)
        {
            score = PlayerPrefs.GetInt("Score");
            UpdateScore();
            ingredients = PlayerPrefs.GetInt("Ingredients");
            UpdateIngredients();
        }
        else
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("NextScene", nextLevel);
        }
        lives = Player.GetComponent<Death>()._lives;
        //LivesText.text = "Lives: " + lives;
        if (score == 10)
        {
            _toadalLives++;
            score = 0;
            UpdateScore();
        }
        ToadalLivesText.text = "X" + _toadalLives;

        PlayerPrefs.SetInt("ToadalLives", _toadalLives);
    }

    void UpdateScore()
    {
        scoreText.text = "X" + score;
        PlayerPrefs.SetInt("Score", score);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateIngredients()
    {
        //ingredientText.text = "Ingredients: " + ingredients;
        PlayerPrefs.SetInt("Ingredients", ingredients);
    }

    public void AddIngredient(int newingredients)
    {
        ingredients += newingredients;
        UpdateIngredients();
    }

    public void LifeDown()
    {
        _toadalLives--;
        UpdateScore();
        //deathscrene link
        if (_toadalLives == 0)
        {
            int prevLevel = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("PreviousScene", prevLevel);
            Debug.Log(prevLevel);
            SceneManager.LoadScene(7);
        }
    }
}
