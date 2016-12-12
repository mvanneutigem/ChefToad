using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Patrol : MonoBehaviour
{
    public Transform[] Throwables;
    public Transform TransSelf;
    public Transform[] WayPoints;
    public float Speed = 3.0f;
    public float TurnSpeed = 1.0f;
    public bool _isMoving = true;
    private int _currentWaypoint;

    void Update()
    {
        if (_isMoving == true)
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
            TransSelf.localScale = new Vector3 (2.0f, 1.0f, 2.0f);
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
