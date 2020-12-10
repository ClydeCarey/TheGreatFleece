using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //create a variable to hold our navmesh agent
    //handle to navmesh agent
    private NavMeshAgent _agent;

    //get handle to animator
    private Animator _anim;
    private Vector3 _target;

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
                Debug.Log(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;

            }
        }

        float distance = Vector3.Distance(transform.position, _target);
        Debug.Log(distance);
        if (distance < 2.0f)
        {
            Debug.Log("walk set to false");
            _anim.SetBool("Walk", false);
        }

    }
}
