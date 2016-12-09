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

    //METHODS
    void Awake()
    {
        _characterController = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (_characterController.isGrounded)
        {
            //input
            float hInput = Input.GetAxisRaw("Horizontal");
            float vInput = Input.GetAxisRaw("Vertical");

            //scale camera forward to only have x and z axis to prevent character from angle-ing upwards/downwards
            var camforward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            
            //ladder
            if (_onLadder)
            {
                _moveVector = (vInput * Vector3.up + hInput * mainCamera.transform.right);
            }
            else
            {
                //set the movevector, relative to the camera direction
                _moveVector = (vInput * camforward + hInput * mainCamera.transform.right);

            }

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

        //Gravity
        _moveVector += Physics.gravity * Time.deltaTime;

        //pass movement to char controller
        _characterController.Move(_moveVector * Time.deltaTime);

        //ladder
        _onLadder = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        //ladder
        if (other.tag == "Ladder")
        {
            _onLadder = true;
            Debug.Log("ladder");
        }
    }
}