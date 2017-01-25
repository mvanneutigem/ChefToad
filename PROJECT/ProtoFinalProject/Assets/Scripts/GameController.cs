﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //FIELDS
    public Text scoreText;
    public Text ingredientText;
    public Text LivesText;
    public Text ToadalLivesText;
    public Transform Player;
    public bool ScoreScreen = false;
    public int _toadalLives;
    private int score;
    private int ingredients;
    private int lives;
    //METHODS

	// Use this for initialization
	void Start () {
        score = 0;
        ingredients = 0;
    }
	
	// Update is called once per frame
	void Update () {
	if(ScoreScreen)
        {
            score = PlayerPrefs.GetInt("Score");
            UpdateScore();
            ingredients = PlayerPrefs.GetInt("Ingredients");
            UpdateIngredients();
        }
        lives = Player.GetComponent<Death>()._lives;
        LivesText.text = "Lives: " + lives;
        if (score == 10)
        {
            _toadalLives++;
            score = 0;
            UpdateScore();
        }
        ToadalLivesText.text = "ToadalLives: " + _toadalLives;

        PlayerPrefs.SetInt("ToadalLives", _toadalLives);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("Score", score);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateIngredients()
    {
        ingredientText.text = "Ingredients: " + ingredients;
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
    }
}
