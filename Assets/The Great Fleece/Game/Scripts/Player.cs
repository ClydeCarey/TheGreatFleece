using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;

    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;
    private bool _coinTossed;
    // Start is called before the first frame update
    void Start()
    {
        //assign handle to the navmesh component
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            //Debug.DrawRay(transform.position, r , Color.green);
            if (Physics.Raycast(rayOrigin, out hitInfo))

            {
                
                _agent.SetDestination(hitInfo.point);
                //Debug.Log(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;

            }
        }

        float distance = Vector3.Distance(transform.position, _target);
        Debug.Log(distance);
        if (distance < 2.0f)
        {
            //Debug.Log("walk set to false");
            _anim.SetBool("Walk", false);
        }
        //if right click
        if (Input.GetMouseButtonDown(1) && _coinTossed == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _coinTossed = true;
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
                SendAIToCoinSpot(hitInfo.point);
            }            
        }
        //instantiate coin at clicked position
        //play sound of the coin hitting
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
            currentAnim.SetBool("Walk", true);
            currentGuard.coinPos = coinPos;
        }
        //move guards to hitinfo point
        //navmeshagent.setdestination = coinPos
    }
}
