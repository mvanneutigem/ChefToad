using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Patrol : MonoBehaviour
{
    public Transform TransSelf;
    public Transform TransChild;
    public Transform TransPlayer;
    public Transform[] Throwables;
    public Transform[] WayPoints;
    public float Speed = 3.0f;
    public float TurnSpeed = 1.0f;
    public float _slapDistance = 2.0f;
    public bool _isMoving = true;
    public bool _scaling = true;
    public bool _isFry = false;
    private bool _slap = false;
    private int _currentWaypoint;
    private float _distance;

    void Update()
    {
        _distance = Vector3.Distance(TransSelf.position, TransPlayer.position);

        if (_isMoving == true)
        {
            if (_isFry == true)
            {
                Vector3 dirFromAtoB = (TransPlayer.transform.position - TransSelf.transform.position).normalized;
                float dotProd = Vector3.Dot(dirFromAtoB, TransSelf.transform.forward);

                if (_distance <= _slapDistance)
                {
                    if (_slap == false)
                    {
                        Vector3 lerpValuePlayer = Vector3.Lerp(TransSelf.position + TransSelf.forward, TransPlayer.position, Time.deltaTime * TurnSpeed);
                        TransSelf.LookAt(lerpValuePlayer);

                        if (dotProd >= 0.97)
                        {
                            _slap = true;
                        }
                    }
                    if (_slap == true && TransSelf.eulerAngles.x <= 85)
                    {
                       TransSelf.Rotate(5, 0, 0);
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
                    TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
                }
            }
            else
            {
                if (TransSelf.position.Equals(WayPoints[_currentWaypoint].position))
                {
                    GoToNextWaypoint();
                }
                Vector3 lerpValue = Vector3.Lerp(TransSelf.position + TransSelf.forward, WayPoints[_currentWaypoint].transform.position, Time.deltaTime * TurnSpeed);
                TransSelf.LookAt(lerpValue);
                TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
            }
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
        //for (int i = 0; i < Throwables.Length; i++)
        //{
        //    if (other == Throwables[i].GetComponent<Collider>())
        //    {
        //        _isMoving = false;
        //        TransSelf.GetComponent<Collider>().isTrigger = false;
        //    }
        //}
    }
}
