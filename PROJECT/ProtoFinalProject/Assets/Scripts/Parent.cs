using UnityEngine;
using System.Collections;

public class Parent : MonoBehaviour {

    //METHODS
	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("parent");
            col.transform.parent = transform.parent;
        }

    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("unparent");
        if (col.transform.parent == transform.parent)
        {
            col.transform.parent = null;
        }

    }
}
