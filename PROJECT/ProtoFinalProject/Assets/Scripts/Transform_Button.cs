using UnityEngine;
using System.Collections;

public class Transform_Button : MonoBehaviour {

    public Transform Player;
    public Transform ToTransform;
    public float _speedX;
    public float _speedY;
    public float _speedZ;
    public float _amountX;
    public float _amountY;
    public float _amountZ;
    public bool _move = false;
    public bool _rotate = false;
    private bool _x = false;
    private bool _xSign = false;
    private bool _y = false;
    private bool _ySign = false;
    private bool _z = false;
    private bool _zSign = false;
    private bool _moveTriggered = false;
    private bool _rotateTriggered = false;
    private bool _xCorrect = false;
    private bool _yCorrect = false;
    private bool _zCorrect = false;
    private Vector3 _originalPosition;
    private Vector3 _originalRotation;

    void Start ()
    {
        _originalPosition = ToTransform.position;
        _originalRotation = ToTransform.eulerAngles;

        //x
        if (_speedX > 0)
        {
            _x = true;
            _xSign = true;
        }
        else if (_speedX < 0)
        {
            _x = true;
            _xSign = false;
        }
        else if (_speedX == 0)
        {
            _x = false;
        }

        //y
        if (_speedY > 0)
        {
            _y = true;
            _ySign = true;
        }
        else if (_speedY < 0)
        {
            _y = true;
            _ySign = false;
        }
        else if (_speedY == 0)
        {
            _y = false;
        }

        //z
        if (_speedZ > 0)
        {
            _z = true;
            _zSign = true;
        }
        else if (_speedZ < 0)
        {
            _z = true;
            _zSign = false;
        }
        else if (_speedZ == 0)
        {
            _z = false;
        }

    }

    void Update()
    {
        //TRANSLATION
        if (_moveTriggered == true)
        {
            //x
            if (_x == true)
            {
                if (_xSign == true)
                {
                    if (ToTransform.position.x - _originalPosition.x < _amountX)
                    {
                        ToTransform.Translate(_speedX, 0, 0);
                        _xCorrect = false;
                    }
                    else
                    {
                        _xCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.position.x - _originalPosition.x > _amountX)
                    {
                        ToTransform.Translate(_speedX, 0, 0);
                        _xCorrect = false;
                    }
                    else
                    {
                        _xCorrect = true;
                    }
                }
            }

            //y
            if (_y == true)
            {
                if (_ySign == true)
                {
                    if (ToTransform.position.y - _originalPosition.y < _amountY)
                    {
                        ToTransform.Translate(0, _speedY, 0);
                        _yCorrect = false;
                    }
                    else
                    {
                        _yCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.position.y - _originalPosition.y > _amountY)
                    {
                        ToTransform.Translate(0, _speedY, 0);
                        _yCorrect = false;
                    }
                    else
                    {
                        _yCorrect = true;
                    }
                }
            }

            //z
            if (_z == true)
            {
                if (_zSign == true)
                {
                    if (ToTransform.position.z - _originalPosition.z < _amountZ)
                    {
                        ToTransform.Translate(0, 0, _speedZ);
                        _zCorrect = false;
                    }
                    else
                    {
                        _zCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.position.z - _originalPosition.z > _amountZ)
                    {
                        ToTransform.Translate(0, 0, _speedZ);
                        _zCorrect = false;
                    }
                    else
                    {
                        _zCorrect = true;
                    }
                }
            }
           if(_xCorrect == true || _yCorrect == true || _zCorrect == true)
            {
                _moveTriggered = false;
            }
        }


        //ROTATION
        if (_rotateTriggered == true)
        {
            //x
            if (_x == true)
            {
                if (_xSign == true)
                {
                    if (ToTransform.eulerAngles.x - _originalRotation.x < _amountX)
                    {
                        ToTransform.Rotate(_speedX, 0, 0);
                        _xCorrect = false;
                    }
                    else
                    {
                        _xCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.eulerAngles.x - _originalRotation.x > _amountX)
                    {
                        ToTransform.Rotate(_speedX, 0, 0);
                        _xCorrect = false;
                    }
                    else
                    {
                        _xCorrect = true;
                    }
                }
            }

            //y
            if (_y == true)
            {
                if (_ySign == true)
                {
                    if (ToTransform.eulerAngles.y - _originalRotation.y < _amountY)
                    {
                        ToTransform.Rotate(0, _speedY, 0);
                        _yCorrect = false;
                    }
                    else
                    {
                        _yCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.eulerAngles.y - _originalRotation.y > _amountY)
                    {
                        //Debug.Log("ToTransform.eulerAngles.y");
                        //Debug.Log(ToTransform.eulerAngles.y);
                        //Debug.Log("_originalRotation.y");
                        //Debug.Log(_originalRotation.y);
                        //Debug.Log("ToTransform.eulerAngles.y - _originalRotation.y");
                        //Debug.Log(ToTransform.eulerAngles.y - _originalRotation.y);
                        //Debug.Log("_amountY");
                        //Debug.Log(_amountY);
                        ToTransform.Rotate(0, _speedY, 0);
                        _yCorrect = false;
                    }
                    else
                    {
                        _yCorrect = true;
                    }
                }
               
            }

            //z
            if (_z == true)
            {
                if (_zSign == true)
                {
                    if (ToTransform.eulerAngles.z - _originalRotation.z < _amountZ)
                    {
                        ToTransform.Rotate(0, 0, _speedZ);
                        _zCorrect = false;
                    }
                    else
                    {
                        _zCorrect = true;
                    }
                }
                else
                {
                    if (ToTransform.eulerAngles.z - _originalRotation.z > _amountZ)
                    {
                        ToTransform.Rotate(0, 0, _speedZ);
                        _zCorrect = false;
                    }
                    else
                    {
                        _zCorrect = true;
                    }
                }
            }
            if (_xCorrect == true || _yCorrect == true || _zCorrect == true)
            {
                _rotateTriggered = false;
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other == Player.GetComponent<Collider>())
        {
            if (Input.GetButtonUp("Fire1"))
            //if (Input.GetKeyUp("e"))
            {
                if(_move == true)
                {
                    _moveTriggered = true;
                }

                if (_rotate == true)
                {
                    _rotateTriggered = true;
                }
            }
        }
    }
}
