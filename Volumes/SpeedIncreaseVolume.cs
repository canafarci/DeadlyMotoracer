using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaseVolume : MonoBehaviour
{
    PlayerState _playerState;
    static bool _insideVolume;
    private float _tickRate = 0.5f;
    float _ticker = 0;
    int _colliderCount;
    bool _isInside;
    public float speedFloat = 4f;
    private void Awake() => _playerState = FindObjectOfType<PlayerState>();
    private void OnEnable()
    {
        EnemyTrigger.StopPlayerHandler += OnStopPlayer;
    }

    private void OnDisable()
    {
        EnemyTrigger.StopPlayerHandler -= OnStopPlayer;
    }


    private void Start()
    {
        _colliderCount = GetComponents<Collider>().Length;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ticker += Time.fixedDeltaTime * speedFloat;
        }
    }

    private void FixedUpdate()
    {
        _ticker -= Time.fixedDeltaTime;


        if (_ticker > _tickRate)
        {
            _playerState.ChangeCurrentSpeed(1);
            _ticker = 0;
        }
        else if (_ticker < _tickRate * -1f)
        {
            _playerState.ChangeCurrentSpeed(-1);
            _ticker = 0;
        }
    }
    private void OnStopPlayer()
    {
        Destroy(gameObject);
    }


}
