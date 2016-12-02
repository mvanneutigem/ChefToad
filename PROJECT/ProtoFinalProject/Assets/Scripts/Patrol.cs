﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Patrol : MonoBehaviour
{

    public Transform TransSelf;
    public Transform[] WayPoints;
    public float Speed = 3.0f;
    public float TurnSpeed = 1.0f;
    private int _currentWaypoint;

    void Update()
    {
        if (TransSelf.position.Equals(WayPoints[_currentWaypoint].position))
        {
            GoToNextWaypoint();
        }
        Vector3 lerpValue = Vector3.Lerp(TransSelf.position + TransSelf.forward, WayPoints[_currentWaypoint].transform.position, Time.deltaTime * TurnSpeed);
        TransSelf.LookAt(lerpValue);
        TransSelf.position = Vector3.MoveTowards(TransSelf.position, WayPoints[_currentWaypoint].transform.position, Speed * Time.deltaTime);
    }

    void GoToNextWaypoint()
    {
        ++_currentWaypoint;
        if (_currentWaypoint >= WayPoints.Length)
        {
            _currentWaypoint = 0;
        }
    }
}
