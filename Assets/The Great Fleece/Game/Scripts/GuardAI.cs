﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{   

    public List<Transform> wayPoints;    
    private NavMeshAgent _agent;
    [SerializeField]
    private int _currentTarget;
    private bool _reverse = false;
    private bool _targetReached;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
                
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
                        
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1.0f && _targetReached == false)
            {
                _targetReached = true;                
                Debug.Log("target reached" + _targetReached);

                StartCoroutine(WaitBeforeMoving());                             
                
            }            
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        Debug.Log("waitBeforeMoving");
        yield return new WaitForSeconds(2.0f);

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }

        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
                
            }

        }

        _targetReached = false;
    }
}
