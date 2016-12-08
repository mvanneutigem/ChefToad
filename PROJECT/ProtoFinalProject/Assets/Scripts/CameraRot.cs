using UnityEngine;
using System.Collections;

public class CameraRot : MonoBehaviour {

    //FIELDS
    public Transform Target;
    private float _rotSpeed = 1.0f;
    private Vector3 _offset;
    public float distance = 20;
    //METHODS
    // Use this for initialization
    void Start ()
    {
        //set camera offset from target
        _offset = new Vector3(Target.position.x + distance, Target.position.y + distance, Target.position.z + distance);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //change offset relative to mouse movement
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _rotSpeed, Vector3.forward) * _offset;
        //set camera position
        transform.position = Target.position + _offset;
        //look at target
        transform.LookAt(Target.position);
	}
}
