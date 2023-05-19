using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveForward : MonoBehaviour
{
    float _speed = 0f;
    int _stageIndex;

    private void OnEnable()
    {
        GameStart.OnGameStart += OnGameStart;
        FindObjectOfType<PlayerState>().SpeedChangeHandler += OnSpeedChange;
        EnemyTrigger.StopPlayerHandler += OnStopPlayer;
    }


    private void OnDisable()
    {
        GameStart.OnGameStart -= OnGameStart;
        EnemyTrigger.StopPlayerHandler -= OnStopPlayer;

        PlayerState state = FindObjectOfType<PlayerState>();
        if (state != null)
            state.SpeedChangeHandler -= OnSpeedChange;
    }
    private void OnGameStart()
    {
        _speed = GameManager.Instance.References.GameConfig.PlayerSpeed;
    }

    private void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.x += _speed * Time.deltaTime;
        transform.localPosition = pos;
    }
    private void OnSpeedChange(int index, int target)
    {
        _speed = target;
        float scaled = (((_speed - 20) * 9) / 50) + 1;
    }
    private void OnStopPlayer()
    {
        DOTween.To(() => _speed, x => _speed = x, 0, 0f);
    }
}
