using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour {

    public Transform SpawnPoint;
    public Transform Player;
    public Transform Self;
    public float _carryHight = 0.2f;
    public int _throwStrength = 500;
    private bool _carying = false;
    private Vector3 _position;
    private float _toadHeight;


	void Start ()
    {
        _toadHeight = Player.GetComponent<CharacterController>().height;
    }
	
	void Update ()
    {
        _position.x = Player.position.x;
        _position.y = Player.position.y + _toadHeight / 2 + _carryHight;
        _position.z = Player.position.z;

        if (_carying == true)
        {
            Self.position = _position;
            if (Input.GetButtonDown("Fire1"))
            //if (Input.GetKeyDown("e"))
            {
                _carying = false;
                Self.GetComponent<Rigidbody>().isKinematic = false;
                //Self.GetComponent<SphereCollider>().isTrigger = false;
                Self.GetComponent<Rigidbody>().AddForce(Player.forward*_throwStrength);
            }
        }

        if (Self.position.y <= -10)
        {
            StartCoroutine(Respawn());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other == Player.GetComponent<Collider>())
        {
            if (Input.GetButtonUp("Fire1"))
            // if (Input.GetKeyUp("e"))
            {
                _carying = true;
            }
        }

        if (other.tag == "InvisibleWall")
        {
            Physics.IgnoreCollision(other, gameObject.GetComponent<Collider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != Player.GetComponent<Collider>())
        {
            StartCoroutine(Respawn());
            //Self.position = SpawnPoint.position;
            //Self.GetComponent<Rigidbody>().isKinematic = true;
        }

        if(other.tag == "wall")
        {
            Physics.IgnoreCollision(other, gameObject.GetComponent<Collider>());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        Self.position = SpawnPoint.position;
        Self.GetComponent<Rigidbody>().isKinematic = true;
    }
    }
