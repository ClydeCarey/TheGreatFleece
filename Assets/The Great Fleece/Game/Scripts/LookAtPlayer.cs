using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //variable to look at Player
    public Transform target;

  
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
