using UnityEngine;
using System.Collections;

public class Throwable2 : MonoBehaviour {

    public Transform Toad;
    public Transform Arch;
    public Transform Spawn;
    public float _carryHeight = 0.2f;
    public int _respawnTime = 2;

    private int _throwStrength = 200;
    private float _toadHeight;
    private float _velocity;
    private double _timer = 0;
    private bool _carry;
    private bool _respawning = false;
    private Vector3 _position;
    private Vector3 _previous;

    void Start()
    {
        Arch.GetComponent<MeshRenderer>().enabled = false;
    }
    void Update ()
    {
        _velocity = (40 * (transform.position - _previous).magnitude) / Time.deltaTime;
        _previous = transform.position;
        _toadHeight = Toad.GetComponent<CharacterController>().height;

        _position.x = Toad.position.x;
        _position.y = Toad.position.y + _toadHeight + _carryHeight;
        _position.z = Toad.position.z;

        if(_respawning == true)
        {

            _timer += Time.deltaTime;
        }

        if(_timer >= _respawnTime)
        {
            _respawning = false;
            _timer = 0;
            transform.position = Spawn.position;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetComponent<MeshRenderer>().enabled = true;
        }

        if(_carry == true)
        {
            transform.position = _position;
            if(Input.GetButtonDown("Fire1"))
            {
                _carry = false;
                transform.GetComponent<Rigidbody>().isKinematic = false;
                transform.GetComponent<Rigidbody>().AddForce(Toad.forward * (_throwStrength + _velocity));
                transform.GetComponent<Rigidbody>().AddForce(0, 100, 0);
                Arch.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other == Toad.GetComponent<Collider>())
        {
            if(Input.GetButtonUp("Fire1"))
            {
                _carry = true;
                transform.GetComponent<Rigidbody>().isKinematic = true;
                Arch.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if(_carry == false)
        {
            _respawning = true;
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
