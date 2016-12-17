using UnityEngine;
using System.Collections;

public class CameraRot : MonoBehaviour {

    //FIELDS
    public Transform Target;
    private float _rotSpeed = 10.0f;
    private Vector3 _offset;
    public float distance = 10;
    private float _followSpeed = 5.0f;//higher is slower
    //METHODS
    // Use this for initialization
    void Start ()
    {
        //set camera to target
        _offset = new Vector3(Target.position.x, Target.position.y, Target.position.z );
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(_offset);
        //change offset relative to input
        ////rot axis
        //_offset = Quaternion.AngleAxis(Input.GetAxis("CameraX") * _rotSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("CameraY") * _rotSpeed, transform.right) * _offset;

        //_offset = _offset.normalized * distance;

        //var nextpos = Vector3.Lerp(_offset + Target.position, transform.position, Time.deltaTime * _followSpeed);


        //Debug.Log(nextpos);
        //Debug.Log(_offset + Target.position);
        ////set camera position
        ////transform.position = nextpos;
        //transform.position = _offset + Target.position;
        //look at target


        //slow lookat
        var targetLookat = Target.position - transform.position;
        var nextlookat = Vector3.Lerp(transform.forward, targetLookat, Time.deltaTime);

        transform.forward = nextlookat;
        //transform.LookAt(Target.position);

        //slow followcam
        var spherepos = Target.position;
        var camerapos = transform.position;
        var camToSphere = new Vector3(spherepos.x - camerapos.x, spherepos.y - camerapos.y, spherepos.z - camerapos.z);
        camToSphere = camToSphere.normalized;
        camToSphere = Vector3.Lerp(camToSphere, Quaternion.AngleAxis(Input.GetAxis("CameraX") * _rotSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("CameraY") * _rotSpeed, transform.right) * camToSphere, Time.deltaTime * _rotSpeed);
        var targetpos = new Vector3(spherepos.x - camToSphere.x * distance, spherepos.y - camToSphere.y * distance, spherepos.z - camToSphere.z * distance);
        var targetVector = new Vector3(targetpos.x - camerapos.x, targetpos.y - camerapos.y, targetpos.z - camerapos.z) / _followSpeed;
        var newpos = new Vector3(camerapos.x + targetVector.x, camerapos.y + targetVector.y, camerapos.z + targetVector.z);

        transform.position = newpos;

    }
}
