using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{

    //FIELDS
    public int Scorevalue = 1;
    private GameController _gameController;

    //METHODs

    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null)
        {
            _gameController = gameControllerObj.GetComponent<GameController>();
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
            _gameController.AddIngredient(Scorevalue);
            Destroy(gameObject);

        }
    }
}
