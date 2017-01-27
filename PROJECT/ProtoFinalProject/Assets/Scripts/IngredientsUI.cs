using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngredientsUI : MonoBehaviour
{
    public GameObject I1;
    public GameObject I2;
    public GameObject I3;
    public GameObject I4;

    public Sprite GarlicSprite;
    public Sprite SalmonSprite;
    public Sprite TomatoSprite;
    public Sprite SoySauceSprite;
    public Sprite hotSauceSprite;
    public Sprite PapricaSprite;
    public Sprite MeatballSprite;
    public Sprite CheeseSprite;
    public Sprite seaweedSprite;
    public Sprite ChickenSprite;
    public Sprite CornSprite;

    private int _sceneIndex;
    void Start ()
	{
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (_sceneIndex)
	    {
            case 1:
                I2.SetActive(true);
                break;
            case 2:
                I3.SetActive(true);
                break;
            case 3:
                I4.SetActive(true);
                break;
            case 4:
                I1.SetActive(true);
                break;
	    }
	}

    public void setIngredientActive(int ingredientIndex)
    {
        switch (_sceneIndex)
        {
            case 1:
                Image im = I2.transform.GetChild(ingredientIndex -1).GetComponent<Image>();
                switch (ingredientIndex)
                {
                    case 1:
                        im.sprite = MeatballSprite;
                        break;
                    case 2:
                        im.sprite = CheeseSprite;
                        break;
                    case 3:
                        im.sprite = TomatoSprite;
                        break;
                }
                break;
            case 2:
                Image im2 = I3.transform.GetChild(ingredientIndex -1).GetComponent<Image>();
                switch (ingredientIndex)
                {
                    case 1:
                        im2.sprite = GarlicSprite;
                        break;
                    case 2:
                        im2.sprite = CheeseSprite;
                        break;
                    case 3:
                        im2.sprite = TomatoSprite;
                        break;
                    case 4:
                        im2.sprite = PapricaSprite;
                        break;
                }
                break;
            case 3:
                Image im3 = I4.transform.GetChild(ingredientIndex -1).GetComponent<Image>();
                switch (ingredientIndex)
                {
                    case 1:
                        im3.sprite = GarlicSprite;
                        break;
                    case 2:
                        im3.sprite = SoySauceSprite;
                        break;
                    case 3:
                        im3.sprite = seaweedSprite;
                        break;
                    case 4:
                        im3.sprite = SalmonSprite;
                        break;
                }
                break;
            case 4:
                int index = (ingredientIndex + 2) % 4;
                Image im4 = I1.transform.GetChild(index).GetComponent<Image>();
                Debug.Log("Ingredient index:");
                Debug.Log((ingredientIndex - 2) %4);
                switch (ingredientIndex )
                {
                    case 1:
                        im4.sprite = CheeseSprite;
                        break;
                    case 2:
                        im4.sprite = ChickenSprite;
                        break;
                    case 3:
                        im4.sprite = hotSauceSprite;
                        break;
                    case 4:
                        im4.sprite = CornSprite;
                        break;
                }
                break;
        }
    }
}
