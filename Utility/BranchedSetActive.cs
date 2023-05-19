using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BranchedSetActive : MonoBehaviour
{
    public int Level;
    [SerializeField] GameObject _handle;
    [SerializeField] GameObject[] _fXs;
    [SerializeField] Animator _animator;
    public void SetItemActive()
    {
        gameObject.SetActive(true);
        Vector3 scale = transform.localScale;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(scale * 1.25f, 0.15f)).
        Append(transform.DOScale(scale, 0.15f));

        FindObjectOfType<TiltPlayer>().Handle = _handle;
        FindObjectOfType<EnableDisableFX>().FXs = _fXs;
        FindObjectOfType<PlayerTiltAnimation>().Animator = _animator;
    }
    public void SetItemInactive() => gameObject.SetActive(false);
}
