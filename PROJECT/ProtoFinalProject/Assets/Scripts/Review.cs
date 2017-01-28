using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Review : MonoBehaviour
{
    public Sprite StarSprite;

    public Sprite Reviewer1Sprite;
    public Sprite Reviewer2Sprite;
    public Sprite Reviewer3Sprite;
    public Sprite Reviewer4Sprite;

    public Text LevelNameText;
    public Text IngredientsFoundText;
    public Text DishNameText;
    public Text Reviewer1Text;
    public Text Reviewer2Text;
    public Text Reviewer3Text;

    public Image Reviewer1;
    public Image Reviewer2;
    public Image Reviewer3;

    void Start ()
    {
        int ingredients = ingredients = PlayerPrefs.GetInt("Ingredients");
        int sceneIndex = PlayerPrefs.GetInt("PreviousScene");
        Debug.Log(sceneIndex);

        IngredientsFoundText.text = ingredients + " Ingredients found!";

        int random = Random.Range(0, 3);
        SetImage(random, Reviewer1);
        random = Random.Range(0, 3);
        SetImage(random, Reviewer2);
        random = Random.Range(0, 3);
        SetImage(random, Reviewer3);

        switch (sceneIndex)
        {
            case 1:
                LevelNameText.text = "Level 1: The Italian dream";
                DishNameText.text = "Super Creamy three cheese spaghetti.";
                break;
            case 2:
                LevelNameText.text = "Level 2: Parisian escargots";
                DishNameText.text = "Buttered crumb escargot in Wine cheese sauce.";
                break;
            case 3:
                LevelNameText.text = "Level 3: A tokyo adventure";
                DishNameText.text = "Money train roll sushi.";
                break;
            case 4:
                LevelNameText.text = "Level 4: Make America great again";
                DishNameText.text = "The best fried Chicken in the world.";
                break;
        }

        string[] badReviews = new string[] { "The cuisine had nothing to be proud of. The starters quantity was smaill and the main dishes were expensive and lacking of creativity.",
                                            "A pallid fart of mediocrity, priced for some dodgy clientele that’s ripped off the gross national product of a small impoverished nation and is now domiciled in MarioLand for tax reasons. ",
                                            "Hey, did you try that blue drink, the one that glows like nuclear waste? Any idea why it tastes like some combination of radiator fluid and formaldehyde?",
                                            "A funeral pyre of French fries—they taste of seared and overused cooking oil, overall an entirely negative experience.",
                                            "The food all looks like it's supposed to be good but it is not. "};
        string[] mediumReviews = new string[] { "More then one utensil and plate appeared to be questionable in cleanliness. The food remains fairly good as well as the service.",
                                            "This is a decent diner - I really appreciated the amount of menu options.",
                                            "Their deserts are okay, some better than others. Like their dishes, you need to know what to order.",
                                            "It wasn't particularly horrible, but it wasn't enjoyable either. The food is meh.",
                                            "Overall a fairly decent restaurant not great, not horrible."};
        string[] goodReviews = new string[] { "Amazing restaurant with an even better ownership! ",
                                            "Good variety of food at reasonable prices for a diner that's been here for many years.",
                                            "Excellent service and great food. Me and my wife enjoyed the meals we ate everything.",
                                            "The waiters are really attentive and your cup of coffee or tea is never empty because they're quick to refilling your cup.",
                                            "One of my favourite restaurants, chef Toad makes the most amazing creations!"};

        Image im = transform.GetChild(12).GetComponent<Image>();
        Image im2 = transform.GetChild(11).GetComponent<Image>();
        Image im3 = transform.GetChild(10).GetComponent<Image>();
        Image im4 = transform.GetChild(9).GetComponent<Image>();
        Image im5 = transform.GetChild(8).GetComponent<Image>();
        switch (ingredients)
        {
            case 1:
                random = Random.Range(0, 4);
                Reviewer1.transform.GetChild(5).GetComponent<Text>().text = badReviews[random];
                setReviewStars(2, Reviewer1);
                random = Random.Range(0, 4);
                Reviewer2.transform.GetChild(5).GetComponent<Text>().text = badReviews[random];
                setReviewStars(1, Reviewer2);
                random = Random.Range(0, 4);
                Reviewer3.transform.GetChild(5).GetComponent<Text>().text = badReviews[random];
                setReviewStars(2, Reviewer3);

                im.sprite = StarSprite;
                break;
            case 2:
                random = Random.Range(0, 4);
                Reviewer1.transform.GetChild(5).GetComponent<Text>().text = mediumReviews[random];
                setReviewStars(3, Reviewer1);
                random = Random.Range(0, 4);
                Reviewer2.transform.GetChild(5).GetComponent<Text>().text = badReviews[random];
                setReviewStars(2, Reviewer2);
                random = Random.Range(0, 4);
                Reviewer3.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(4, Reviewer3);

                im.sprite = StarSprite;
                im2.sprite = StarSprite;
                im3.sprite = StarSprite;
                break;
            case 3:
                random = Random.Range(0, 4);
                Reviewer1.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(4, Reviewer1);
                random = Random.Range(0, 4);
                Reviewer2.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(5, Reviewer2);
                random = Random.Range(0, 4);
                Reviewer3.transform.GetChild(5).GetComponent<Text>().text = mediumReviews[random];
                setReviewStars(3, Reviewer3);

                im.sprite = StarSprite;
                im2.sprite = StarSprite;
                im3.sprite = StarSprite;
                im4.sprite = StarSprite;
                break;
            case 4:
                random = Random.Range(0, 4);
                Reviewer1.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(5, Reviewer1);
                random = Random.Range(0, 4);
                Reviewer2.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(5, Reviewer2);
                random = Random.Range(0, 4);
                Reviewer3.transform.GetChild(5).GetComponent<Text>().text = goodReviews[random];
                setReviewStars(5, Reviewer3);

                im.sprite = StarSprite;
                im2.sprite = StarSprite;
                im3.sprite = StarSprite;
                im4.sprite = StarSprite;
                im5.sprite = StarSprite;
                break;
        }
    }

    private void SetImage(int index, Image image)
    {
        switch (index)
        {
            case 0:
                image.sprite = Reviewer1Sprite;
                break;
            case 1:
                image.sprite = Reviewer2Sprite;
                break;
            case 2:
                image.sprite = Reviewer3Sprite;
                break;
            case 3:
                image.sprite = Reviewer4Sprite;
                break;
        }
    }

    private void setReviewStars(int amount, Image reviewer)
    {
        Image im = reviewer.transform.GetChild(0).GetComponent<Image>();
        Image im2 = reviewer.transform.GetChild(1).GetComponent<Image>();
        Image im3 = reviewer.transform.GetChild(2).GetComponent<Image>();
        Image im4 = reviewer.transform.GetChild(3).GetComponent<Image>();
        Image im5 = reviewer.transform.GetChild(4).GetComponent<Image>();
        im.sprite = StarSprite;

        if (amount > 1)
            im2.sprite = StarSprite;
        if (amount > 2)
            im3.sprite = StarSprite;
        if (amount > 3)
            im4.sprite = StarSprite;
        if (amount > 4)
            im5.sprite = StarSprite;
    }
}
