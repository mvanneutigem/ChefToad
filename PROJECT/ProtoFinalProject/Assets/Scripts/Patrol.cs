using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Patrol : MonoBehaviour
{
    public Transform TransSelf;
     public GameObject cylinder;
    public Transform TransPlayer;
    public Transform[] WayPoints;
    public float Speed = 3.0f;
    public float TurnSpeed = 1.0f;
    public float _slapDistance = 2.0f;
    private bool _isMoving = true;
    public bool _scaling = true;
    public bool _isFry = false;
    private bool _slap = false;
    private int _currentWaypoint;
    private float _distance;
    public GameObject enemy;
    private bool _playinganimation = false;
    private bool _timeout = false;
    public string AnimationTitle;
    public float TimeOut = 5.0f;

    void Update()
    {
        _distance = Vector3.Distance(TransSelf.position, TransPlayer.position);
        Debug.Log(_timeout);
        if (_isMoving == true &&!_timeout)
        {
            //if (_isFry == true)
            {

                //calculate direction from enemy to player (excluding y direction)
                Vector3 dirFromAtoB = new Vector3( TransSelf.transform.position.x - TransPlayer.transform.position.x, 0,TransSelf.transform.position.z - TransPlayer.transform.position.z).normalized;
                float dotProd = Vector3.Dot(dirFromAtoB, TransSelf.transform.forward);

                if (_distance <= _slapDistance && _isFry)
                {
                    if (_slap == false)
                    {
                        //Debug.Log("no_slap");
                        //rotate in direction of player
                        var enemyLerp = TransSelf.position + TransSelf.forward;
                        enemyLerp.y = 0;
                        var playerLerp = TransPlayer.position;
                        playerLerp.y = 0;
                        Vector3 lerpValuePlayer = Vector3.Lerp(enemyLerp, playerLerp, Time.deltaTime * TurnSpeed);
                        TransSelf.LookAt(lerpValuePlayer);
                        GetComponent<Transform>().eulerAngles = new Vector3(0, GetComponent<Transform>().eulerAngles.y, 0);

                        //when small enough angle start slap
                        float angle = Mathf.Acos(dotProd);
                        //Debug.Log(angle);
                        if (Mathf.Abs( angle ) >= 3.0)
                        {
                            _slap = true;
                        }
                    }
                    if (_slap == true)
                    {
                        //Debug.Log("slap");
                        StartCoroutine(playanimation());
                    }
                }
                else
                {
                    _slap = false;
                    if (TransSelf.position.Equals(WayPoints[_currentWaypoint].position))
                    {
                        GoToNextWaypoint();
                    }
                    Vector3 lerpValue = Vector3.Lerp(TransSelf.position + TransSelf.forward, WayPoints[_currentWaypoint].transform.position, Time.deltaTime * TurnSpeed);
                    TransSelf.LookAt(lerpValue);
                    GetComponent<Transform>().eulerAngles = new Vector3(0, GetComponent<Transform>().eulerAngles.y, 0);
                    TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
                }



            }
            //else 
            //{
            //    //
            //    if (TransSelf.position.Equals(WayPoints[_currentWaypoint].position))
            //    {
            //        GoToNextWaypoint();
            //    }
            //    Vector3 lerpValue = Vector3.Lerp(TransSelf.position + TransSelf.forward, WayPoints[_currentWaypoint].transform.position, Time.deltaTime * TurnSpeed);
            //    TransSelf.LookAt(lerpValue);
            //    TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
            //}
        }
    }

    void GoToNextWaypoint()
    {
        ++_currentWaypoint;
        if (_currentWaypoint >= WayPoints.Length)
        {
            _currentWaypoint = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Throwable")
        {
            _isMoving = false;
            TransSelf.GetComponent<Collider>().isTrigger = false;
            if (_scaling == true)
            {
                TransSelf.localScale = new Vector3(2.0f, 1.0f, 2.0f);
            }
        }
    }

    private IEnumerator playanimation()
    {
        if (!_playinganimation)
        {
            Debug.Log("PlayAnimation");
            enemy.GetComponent<Animation>()[AnimationTitle].speed = 1;
            enemy.GetComponent<Animation>()[AnimationTitle].time = 0;
            enemy.GetComponent<Animation>().Play();
            _playinganimation = true;
        }

        //cylinder.transform.rotation =  Quaternion.AngleAxis(90.0f, Vector3.forward);
        // = Quaternion.AngleAxis(90.0f, Vector3.forward);
        _timeout = true;
        yield return new WaitForSeconds(0.8f);
        cylinder.transform.Rotate(Vector3.forward, 90.0f);
        yield return new WaitForSeconds(TimeOut);
        _timeout = false;
        _playinganimation = false;
        Debug.Log("waited");
        enemy.GetComponent<Animation>()[AnimationTitle].speed = -1;
        enemy.GetComponent<Animation>()[AnimationTitle].time = enemy.GetComponent<Animation>()[AnimationTitle].length;
        enemy.GetComponent<Animation>().Play(AnimationTitle);
        cylinder.transform.rotation = new Quaternion(0, 0, 0, 0);
    }


}
