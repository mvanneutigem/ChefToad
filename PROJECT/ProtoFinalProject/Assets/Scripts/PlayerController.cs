using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    //PROPERTIES
    public float Speed { get { return _speed; } set { _speed = value; } }//value is created as magic variable entered by outside

    //FIELDS
    private Vector3 _moveVector;
    private CharacterController _characterController;
    public GameObject mainCamera;
    [SerializeField]
    private float _speed = 5.0f;
    private float _rotateSpeed = 5.0f;

    //METHODS
    void Awake()
    {
        _characterController = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        //input
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if (_characterController.isGrounded)
        {
            //rotate
            //transform.right = Vector3.Slerp(transform.right, Vector3.left * hInput, 0.1f);
            //if (hInput > 0)
            //    transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            //else if (hInput < 0)
            //    transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));

            transform.Rotate(0, Input.GetAxis("Horizontal") * _rotateSpeed * Time.deltaTime, 0);

            _moveVector = new Vector3(0, 0, vInput * Speed);
            //camera align
            _moveVector = mainCamera.transform.rotation * transform.localRotation * _moveVector;
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (_characterController.isGrounded)
            {
                _moveVector += Vector3.up * _speed;
            }
            _moveVector.x = hInput * Speed / 2;
            _moveVector.z = vInput * Speed / 2;
        }

        //Gravity
        _moveVector += Physics.gravity * Time.deltaTime;

        //Move
        _characterController.Move(_moveVector * Time.deltaTime);
       
    }
}