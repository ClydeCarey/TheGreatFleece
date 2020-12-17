using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    //ontrigger check for player
    //has keycard?
    //check gm for key
    //trigger wincut scne
    //else you need the key
    public GameObject winCutScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasCard == true)
            {
                winCutScene.SetActive(true);
            }
            else
            {
                Debug.Log("You must have the key card!");
            }
        }
    }

}
