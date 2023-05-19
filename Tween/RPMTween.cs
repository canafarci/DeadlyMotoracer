using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RPMTween : MonoBehaviour
{
    [SerializeField] Vector3 _maxValue1, _maxValue2, _minValue1, _minValue2;
    [SerializeField] float _tickRate;

    PlayerInsideVolume _playerInside;

    Sequence _sequence;

    void Start()
    {
        StartCoroutine(MoveMeter());
    }

    private void Awake()
    {
        _playerInside = FindObjectOfType<PlayerInsideVolume>();
    }


    IEnumerator MoveMeter()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            Sequence sequence = DOTween.Sequence();

            if (_playerInside.InsideVolume)
            {
                sequence.Append(transform.DOLocalRotate(_maxValue1, _tickRate)).
                Append(transform.DOLocalRotate(_maxValue2, _tickRate));

                yield return sequence.WaitForCompletion();
            }
            else
            {
                sequence.Append(transform.DOLocalRotate(_minValue1, _tickRate)).
                Append(transform.DOLocalRotate(_minValue2, _tickRate));

                yield return sequence.WaitForCompletion();
            }

        }
    }


}
