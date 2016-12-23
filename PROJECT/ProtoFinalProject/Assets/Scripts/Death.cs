using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public Transform TransSpawnpoint;
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<Transform>().position = TransSpawnpoint.position;
        }
    }
}
