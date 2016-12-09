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
    [SerializeField]
    private float _speed = 5.0f;
    private float _rotateSpeed = 0.03f;
    private bool _onLadder = false;
    private float _climbspeed = 5.0f;

    //METHODS
    void Awake()
    {
        _characterController = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        //input
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        if (_characterController.isGrounded)
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
            if (_characterController.isGrounded && vInput > 0 || !_characterController.isGrounded)
            {
                _moveVector = Vector3.up * vInput * _climbspeed;
            }
        }

        //Gravity
        _moveVector += Physics.gravity * Time.deltaTime;
        //pass movement to char controller
        _characterController.Move(_moveVector * Time.deltaTime);

        _onLadder = false;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("triggered");
        //ladder
        if (other.tag == "Ladder")
        {
            Debug.Log("enterladder");
            _onLadder = true;
            Physics.gravity = Vector3.zero;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("untriggered");
        //ladder
        if (other.tag == "Ladder")
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
}