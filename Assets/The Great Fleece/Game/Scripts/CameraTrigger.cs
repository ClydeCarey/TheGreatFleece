using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform myCamera;

    //check foir trigger when player crosses
    //update main camera to the triggers camera progression angle

    //check for trigger
    //debug.log trigger activated
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigger activated");
            Camera.main.transform.position = myCamera.transform.position;
            Camera.main.transform.rotation = myCamera.transform.rotation;
        }    
    }

}
