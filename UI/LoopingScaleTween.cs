using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoopingScaleTween : MonoBehaviour
{
    [SerializeField] float _scaleFactor, _loopHalfTime;
    bool _isLooping = true;
    Vector3 _startScale;
    void Start()
    {
        StartCoroutine(LoopingTweenRoutine());
        StartCoroutine(Timer());
        _startScale = transform.localScale;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        _isLooping = false;
        transform.DOScale(_startScale, _loopHalfTime);
    }

    IEnumerator LoopingTweenRoutine()
    {
        Sequence sequence = DOTween.Sequence();
        while (_isLooping)
        {
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(_startScale * _scaleFactor, _loopHalfTime)).
            Append(transform.DOScale(_startScale, _loopHalfTime));

            yield return sequence.WaitForCompletion();
        }

        sequence.Kill();
    }
}
