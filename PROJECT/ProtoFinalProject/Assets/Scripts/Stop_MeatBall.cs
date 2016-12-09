using UnityEngine;
using System.Collections;

public class Stop_MeatBall : MonoBehaviour {

    public GameObject MeatBall;

	void Start () {
	
	}
	
	void Update () {
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garlic")
        {
            MeatBall.GetComponent<Patrol>()._isMoving = false;
        }
    }
}
