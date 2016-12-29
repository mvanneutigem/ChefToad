using UnityEngine;
using System.Collections;

public class sushiroll : MonoBehaviour {

    //FIELDS
    public GameObject cylinder;
    public GameObject plane;

    //METHODS
    void Start()
    {
        cylinder.GetComponent<Collider>().enabled = false;
        plane.GetComponent<Collider>().enabled = true;
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("sushiroll triggered");
        if (col.tag == "Player")
        {
            StartCoroutine( playanimation());
        }
    }

    private IEnumerator playanimation()
    {
        GetComponent<Animation>()["Take 001"].speed = 1;
        GetComponent<Animation>()["Take 001"].time = 0;
        GetComponent<Animation>().Play();
        cylinder.GetComponent<Collider>().enabled = true;
        plane.GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5.0f);
        GetComponent<Animation>()["Take 001"].speed = -1;
        GetComponent<Animation>()["Take 001"].time = GetComponent<Animation>()["Take 001"].length;
        GetComponent<Animation>().Play("Take 001");
        cylinder.GetComponent<Collider>().enabled = false;
        plane.GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
