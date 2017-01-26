using UnityEngine;
using System.Collections;

public class SpaghettiCurtain : MonoBehaviour
{
    public GameObject collider;

    // Use this for initialization
    void Start () {
        collider.GetComponent<Collider>().enabled = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(playanimation());
        }
    }
    private IEnumerator playanimation()
    {
        GetComponent<Animation>()["Open"].speed = 1;
        GetComponent<Animation>()["Open"].time = 0;
        GetComponent<Animation>().Play();
        collider.GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5.0f);

        GetComponent<Animation>()["Open"].speed = -1;
        GetComponent<Animation>()["Open"].time = GetComponent<Animation>()["Open"].length;
        GetComponent<Animation>().Play("Open");
        collider.GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
