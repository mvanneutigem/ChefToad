using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Platform : MonoBehaviour
{

    //FIELDS
    public Transform TransSelf;
    public Transform[] WayPoints;
    public float Speed = 2.0f;
    private int _currentWaypoint;
    private bool _wait = false;
    public float WaitTime = 1.0f;
    private float _counter;

    //METHODS
    void Start()
    {
        _counter = WaitTime;
    }
    void Update()
    {
        if (TransSelf.position.Equals(WayPoints[_currentWaypoint].position))
        {
            GoToNextWaypoint();
            _wait = true;
        }
        if (!_wait)
        {
            TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
        }
        else
        {
            if (_currentWaypoint !=0 && WayPoints[_currentWaypoint-1].tag == "Smooth")
            {
                _wait = false;
            }
            else
            {

                _counter -= Time.deltaTime;
                if (_counter <= 0)
                {
                    _counter = WaitTime;
                    _wait = false;
                }
            }
        }
        
    }

    private void GoToNextWaypoint()
    {
        ++_currentWaypoint;
        if (_currentWaypoint >= WayPoints.Length)
        {
            _currentWaypoint = 0;
        }
        _wait = true;
    }
}
