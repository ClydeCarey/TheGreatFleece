using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //create ability to detect darren if he's caught in the eye

    //void ontrigger enter
    //check for player tag
    //enable gameover cutscene
    public GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
