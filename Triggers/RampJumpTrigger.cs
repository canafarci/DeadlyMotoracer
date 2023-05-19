using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RampJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 _rotation = other.transform.GetChild(0).localRotation.eulerAngles;

            Sequence sequence = DOTween.Sequence();

            sequence.Append(other.transform.GetChild(0).DOLocalRotate(new Vector3(40f, 0f, 0f), 0.5f)).
            Append(other.transform.GetChild(0).DOLocalRotate(new Vector3(75f, 0f, 0f), 0.15f)).
            Append(other.transform.GetChild(0).DOLocalRotate(_rotation, 0.35f));
        }
    }
}
