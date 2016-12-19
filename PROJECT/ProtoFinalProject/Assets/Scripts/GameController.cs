using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //FIELDS
    public Text scoreText;
    public Text ingredientText;
    private int score;
    private int ingredients;
    //METHODS

	// Use this for initialization
	void Start () {
        score = 0;
        ingredients = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateIngredients()
    {
        ingredientText.text = "Ingredients: " + ingredients;
    }

    public void AddIngredient(int newingredients)
    {
        ingredients += newingredients;
        UpdateIngredients();
    }
}
