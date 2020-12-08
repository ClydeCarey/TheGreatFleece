using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //create a variable to hold our navmesh agent
    //handle to navmesh agent
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        //assign handle to the navmesh component
        _agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
               // Debug.Log("Hit: " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
            }
        }
        
    }
}
