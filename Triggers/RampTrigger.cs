using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem _fx;
    PlayerState _playerState;
    EnableDisableFX _fxEnabler;
    private void Awake()
    {
        _playerState = FindObjectOfType<PlayerState>();
        _fxEnabler = FindObjectOfType<EnableDisableFX>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _fx.Play();
            _playerState.ChangeCurrentSpeed(10);
            StartCoroutine(_fxEnabler.ForceActivate());

            Vector3 _rotation = other.transform.localRotation.eulerAngles;
        }
    }
}
