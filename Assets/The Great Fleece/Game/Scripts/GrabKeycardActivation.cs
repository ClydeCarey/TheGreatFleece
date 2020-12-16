using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    public GameObject sleepingGuardCutscene;
    private bool _sceneHasBeenTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _sceneHasBeenTriggered == false)
        {
            sleepingGuardCutscene.SetActive(true);
            _sceneHasBeenTriggered = true;

            GameManager.Instance.HasCard = true;
        }
    }
}
