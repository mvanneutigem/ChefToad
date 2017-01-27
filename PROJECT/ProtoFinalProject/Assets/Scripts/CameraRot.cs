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
    private const float _angleMax = 45.0f;
    private bool _isZoomed = false;
    //METHODS
    void Update ()
	{
        //input
	    var inputX = Input.GetAxis("CameraX");
        var inputY = Input.GetAxis("CameraY");
        var zoomup = Input.GetButtonUp("Zoom");
        var triggerR = Input.GetButton("TriggerR");
        var triggerL = Input.GetButton("TriggerL");
	    float vRotation = 0f;

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

        //clamp cam verticalangle
	    vRotation += _rotSpeed * inputY * Time.deltaTime;
        var camforward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;
        //making sure angle gets minus when below 0
	    float angleBetween = Vector3.Angle(camforward, transform.forward) * (playerpos.y - camerapos.y > 0 ? -1 : 1);
        float newAngle = Mathf.Clamp(angleBetween + vRotation, -_angleMax, _angleMax);
	    vRotation = newAngle - angleBetween;

        //rotatearound
        transform.RotateAround(Target.position, Vector3.up, Time.deltaTime * _rotSpeed * inputX);
        transform.RotateAround(Target.position, transform.right, vRotation);

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

        //zoom
	    if (zoomup)
	    {
	        if (!_isZoomed)
	        {
	            distance *= 0.5f;
            }
	        else
	        {
                distance *= 2.0f;
            }
	        _isZoomed = !_isZoomed;
	    }
    }
}
