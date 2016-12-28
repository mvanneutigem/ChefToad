using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    //PROPERTIES
    public float Speed { get { return _speed; } set { _speed = value; } }//value is created as magic variable entered by outside

    //FIELDS
    private Vector3 _moveVector = Vector3.zero;
    private CharacterController _characterController;
    public GameObject mainCamera;
    public GameObject Toad;
    [SerializeField]
    private float _speed = 5.0f;
    private float _rotateSpeed = 0.03f;
    private bool _onLadder = false;
    private float _climbspeed = 5.0f;
    private float _slidespeed = 10.0f;
    private bool _onslope = false;
    private Collider _slope;
    Vector3 _ladderDir;

    //METHODS
    void Awake()
    {
        _characterController = this.GetComponent<CharacterController>();
        Toad.GetComponent<Animation>()["walk"].speed = 2.0f;
        Toad.GetComponent<Animation>()["climb"].speed = 4.0f;
        Toad.GetComponent<Animation>()["idle"].speed = 2.0f;
    }
    void Update()
    {
        //input
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        //movement when falling/ climbing... or not...
        //if (_characterController.isGrounded)
        {

            //scale camera forward to only have x and z axis to prevent character from angle-ing upwards/downwards
            var camforward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            
            //set the movevector, relative to the camera direction
            _moveVector = (vInput * camforward + hInput * mainCamera.transform.right);

            //set the speed
            _moveVector = Speed * _moveVector.normalized;

            if (!_onLadder)
            {
                //rotate character in the direction it's moving in
                if (_moveVector != Vector3.zero)
                {
                    //viewvector =
                    Quaternion targetRotation = Quaternion.LookRotation(_moveVector);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.time * _rotateSpeed);
                }
            }
        }



        //ladder
        if (_onLadder )
        {
            Debug.Log("ladder movement active");
            Debug.Log(vInput);

            if (_characterController.isGrounded && ( _ladderDir.x > 0 && vInput > 0 || _ladderDir.x < 0 && vInput < 0) || (_ladderDir.z > 0 && hInput > 0 || _ladderDir.z < 0 && hInput < 0) || !_characterController.isGrounded)
            {
                _moveVector += Vector3.up * Mathf.Abs( Mathf.Sqrt(Mathf.Pow( vInput, 2) + Mathf.Pow(hInput, 2))) * _climbspeed;
            }
        }

        if (_onslope)
        {
            //dirty af but it works,
            var left = -_slope.GetComponent<Transform>().right;
            _moveVector += left * _slidespeed;
        }
        //Gravity
        _moveVector += Physics.gravity;// * Time.deltaTime;//makes it fall too darn slowly

        //pass movement to char controller
        _characterController.Move(_moveVector * Time.deltaTime);

        //animations
        if (Mathf.Abs(hInput) > 0 || Mathf.Abs(vInput) > 0)
        {
            if (_onLadder)
            {
                //play climb anim
                Toad.GetComponent<Animation>().Play("climb");
            }
            else
            {
                //play walk
                Toad.GetComponent<Animation>().Play("walk");
            }
        }
        else
        {
            //play idle
            Toad.GetComponent<Animation>().Play("idle");
        }

        _onLadder = false;
        _onslope = false;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("triggered");
        //ladder
        if (other.tag == "Ladder")
        {
            Debug.Log("enterladder");
            _onLadder = true;

            //calculate vector from player to ladder.
            _ladderDir = new Vector3(other.transform.position.x - transform.position.x, 0, other.transform.position.z - transform.position.z);
            _ladderDir = _ladderDir.normalized;

            //obviously not the best way but itll do for now
            Physics.gravity = Vector3.zero;
        }
        if (other.tag == "Slope")
        {
            _onslope = true;
            Debug.Log("Slope");
            _slope = other;

        }
    }

    void OnTriggerExit(Collider other)
    {
        Physics.gravity = new Vector3 ( 0, -9.81f,0);
    }

}