using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.GetComponent<Collider>().isTrigger)
        {
            FindObjectOfType<StartEndGame>().EndGameStart();
            //FindObjectOfType<StackMover>().PauseStacker();
        }
    }
}

