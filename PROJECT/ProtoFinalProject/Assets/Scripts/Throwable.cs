using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour {

    public Transform SpawnPoint;
    public Transform Player;
    public Transform Self;
    public Transform Arch;
    public float _carryHight = 0.2f;
    public int _throwStrength = 500;
    private bool _carying = false;
    private Vector3 _position;
    private float _toadHeight;

    private Vector3 _previous;
    private float _velocity;


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
            _velocity = ((transform.position - _previous).magnitude) / Time.deltaTime;
            _previous = transform.position;
            Self.position = _position;
            if (Input.GetButtonDown("Fire1"))
            {
                _carying = false;
                Self.GetComponent<Rigidbody>().isKinematic = false;
                Self.GetComponent<Rigidbody>().AddForce(Player.forward*(_throwStrength + _velocity*10));
                if(_velocity > 0)
                {
                    Self.GetComponent<Rigidbody>().AddForce(0,100,0);
                }
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
            {
                _carying = true;
                Arch.GetComponent<MeshRenderer>().enabled = true;
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
            GetComponent<MeshRenderer>().enabled = false;
            Arch.GetComponent<MeshRenderer>().enabled = false;
        }

        if(other.tag == "InvisibleWall")
        {
            Physics.IgnoreCollision(other, gameObject.GetComponent<Collider>());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        Self.position = SpawnPoint.position;
        GetComponent<MeshRenderer>().enabled = true;
        Self.GetComponent<Rigidbody>().isKinematic = true;
    }
    }
