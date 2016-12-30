using UnityEngine;
using System.Collections;

public class CameraRot : MonoBehaviour {

    //FIELDS
    public Transform Target;
    private float _rotSpeed = 50.0f;
    private Vector3 _offset;
    public float distance = 15;
    private float _followSpeed = 5.0f;//higher is slower
    private float _prevValueR = 0;
    private float _prevValueL = 0;
    private const float _rot = 45.0f;
    //METHODS
    void Update ()
	{
        //input
	    var inputX = Input.GetAxis("CameraX");
        var inputY = Input.GetAxis("CameraY");
        var zoom = Input.GetButton("Zoom");
	    var triggerR = Input.GetButton("TriggerR");
        var triggerL = Input.GetButton("TriggerL");
	    var prevY = transform.position.y;
	    var prevZ = transform.position.z;

        //followcam
        var playerpos = Target.position;
	    var camerapos = transform.position;
	    var camToPlayer = playerpos - camerapos;
        camToPlayer = camToPlayer.normalized * distance;
	    var newPosition = (playerpos - camToPlayer);
	    newPosition = Vector3.Lerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
        transform.position = newPosition;

        //slow lookat
        var targetLookat = Target.position - transform.position;
        var nextlookat = Vector3.Lerp(transform.forward, targetLookat, _rotSpeed * Time.deltaTime);
        transform.forward = nextlookat;

        //rotatearound
        transform.RotateAround(Target.position, Vector3.up, Time.deltaTime * _rotSpeed * inputX);
        transform.RotateAround(Target.position, transform.right, Time.deltaTime * _rotSpeed * inputY);

        //triggers
	    if (triggerR)
	    {
            var interp = Mathf.Lerp(_prevValueR, _rot, Time.deltaTime * 15.0f);
            transform.RotateAround(Target.position, Vector3.up, interp - _prevValueR);
            _prevValueR = interp;

        }
	    else
	    {
            _prevValueR = 0;
	    }
        if (triggerL)
        {
            var interp = Mathf.Lerp(_prevValueL, -_rot, Time.deltaTime * 15.0f);
            transform.RotateAround(Target.position, Vector3.up, interp - _prevValueL);
            _prevValueL = interp;
        }
        else
        {
            _prevValueL = 0;
        }

        //clamp
	    if (Mathf.Abs(transform.position.y - Target.position.y) > distance - 1.0f)
	    {
            Debug.Log("fix");
            transform.position = new Vector3(transform.position.x, prevY, prevZ);
	    }

        //-------------------------------------------------------------
        //i fucked up so i started over ^^
        //Debug.Log(_offset);
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
        //var targetLookat = Target.position - transform.position;
        //var nextlookat = Vector3.Lerp(transform.forward, targetLookat, Time.deltaTime);
        //transform.forward = nextlookat;

        //lookat
        //transform.LookAt(Target.position);

        //slow followcam
        //var spherepos = Target.position;
        //var camerapos = transform.position;
        //var camToSphere = new Vector3(spherepos.x - camerapos.x, spherepos.y - camerapos.y, spherepos.z - camerapos.z);
        //camToSphere = camToSphere.normalized;
        ////camToSphere = Vector3.Lerp(camToSphere, Quaternion.AngleAxis(Input.GetAxis("CameraX") * _rotSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("CameraY") * _rotSpeed, transform.right) * camToSphere, Time.deltaTime * _rotSpeed);
        //var targetpos = new Vector3(spherepos.x - camToSphere.x * distance, spherepos.y - camToSphere.y * distance, spherepos.z - camToSphere.z * distance);
        //var targetVector = new Vector3(targetpos.x - camerapos.x, targetpos.y - camerapos.y, targetpos.z - camerapos.z) / _followSpeed;
        //var newpos = new Vector3(camerapos.x + targetVector.x, camerapos.y + targetVector.y, camerapos.z + targetVector.z);

        ////if (Mathf.Abs(newpos.y - Target.transform.position.y) > distance - 1.0f)
        ////{
        ////    newpos.y = distance - 1.0f;
        ////}

        //transform.position = newpos;


    }
}
