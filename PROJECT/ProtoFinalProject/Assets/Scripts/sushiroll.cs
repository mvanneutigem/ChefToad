using UnityEngine;
using System.Collections;

public class sushiroll : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("sushiroll triggered");
        if (col.tag == "Player")
        {
            GetComponent<Animation>().Play();
        }
    }
}
