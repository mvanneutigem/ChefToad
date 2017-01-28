using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{

    //FIELDS
    public int Scorevalue = 1;
    private GameController _gameController;
    private IngredientsUI _ingredientsUi;

    //METHODs

    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        GameObject ingredientsUIObj = GameObject.FindWithTag("IngredientsUI");
        if (gameControllerObj != null)
        {
            _gameController = gameControllerObj.GetComponent<GameController>();
            _ingredientsUi = ingredientsUIObj.GetComponent<IngredientsUI>();
        }
    }

    void Update()
    {
        this.transform.Rotate(0f, 0f, 1.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject Sound = GameObject.FindWithTag("SoundIngredient");
            Sound.GetComponent<AudioSource>().Play();
            _gameController.AddIngredient(Scorevalue);
            if (transform.tag == "1")
            {
                _ingredientsUi.setIngredientActive(1);
            }
            else if (transform.tag == "2")
            {
                _ingredientsUi.setIngredientActive(2);
            }
            else if (transform.tag == "3")
            {
                _ingredientsUi.setIngredientActive(3);
            }
            else if (transform.tag == "4")
            {
                _ingredientsUi.setIngredientActive(4);
            }
            Destroy(gameObject);

        }
    }
}
