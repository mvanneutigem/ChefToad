using UnityEngine;
using System.Collections;

public class Parent : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        Debug.Log("parent");
        col.transform.parent = transform.parent;
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("unparent");
        col.transform.parent = null;
    }
}
