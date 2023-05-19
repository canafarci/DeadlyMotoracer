using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StateChangeDotween : MonoBehaviour
{
    Vector3 _rotation;
    int _counter = 0;
    float _duration = 0.175f;

    private void Awake() => _rotation = transform.localRotation.eulerAngles;
    private void OnEnable()
    {
        GetComponent<PlayerState>().StageChangeHandler += OnStateChange;
    }

    private void OnDisable()
    {
        GetComponent<PlayerState>().StageChangeHandler -= OnStateChange;
    }

    private void OnStateChange(int obj)
    {
        // Sequence sequence = DOTween.Sequence();

        // sequence.Append(transform.DOLocalRotate(new Vector3(40f, 270f, 0f), 0.7f)).
        // Append(transform.DOLocalRotate(new Vector3(60f, 270f, 0f), 0.15f)).
        // Append(transform.DOLocalRotate(_rotation, 0.25f));
    }
}
