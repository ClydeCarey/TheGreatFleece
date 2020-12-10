using System.Collections;
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
    private Animator _anim;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", false);
                }

            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", true);
                }
            }

            if (distance < 1.0f && _targetReached == false)
            {
                if (wayPoints.Count <2)
                {
                    return;
                }

                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count - 1) && wayPoints.Count > 1)
                {
                    _targetReached = true;
                    //Debug.Log("target reached" + _targetReached);
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {

                    if (_reverse == true)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _reverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;

                    }

                }

            }

        }
    }

    IEnumerator WaitBeforeMoving()
    {
        //Debug.Log("waitBeforeMoving");

        if (_currentTarget == 0)
        {
            _anim.SetBool("Walk", false);
            yield return new WaitForSeconds(2.0f);    //(Random.Range(2.0f, 5.0f));
        }
        else if (_currentTarget == wayPoints.Count - 1)
        {
            _anim.SetBool("Walk", false);
            yield return new WaitForSeconds(2.0f);   //(Random.Range(2.0f, 5.0f));
        }


        if (_reverse == true)
        {
            _currentTarget--;
            //Debug.Log("ienum reverse true target--");
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }

        else if (_reverse == false)
        {
            _currentTarget++;
            //Debug.Log("ienum reverse false target++");
            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
                //Debug.Log("ienum reverse false targetwaypoints count target--");
            }

        }

        _targetReached = false;
    }
}
