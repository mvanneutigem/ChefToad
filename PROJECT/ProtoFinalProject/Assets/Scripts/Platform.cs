using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Platform : MonoBehaviour
{

    public Transform TransSelf;
    public Transform[] WayPoints;
    public float Speed = 2.0f;
    private int _currentWaypoint;
    private bool _wait = false;
    private float _counter = 1.0f;

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
            _counter -= Time.deltaTime;
            if (_counter <= 0)
            {
                _counter = 1.0f;
                _wait = false;
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
