using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCanvas : MonoBehaviour
{
    StartEndGame _endGameStarter;
    void Awake() => _endGameStarter = FindObjectOfType<StartEndGame>();
    private void OnEnable() => _endGameStarter.EndGameStartHandler += OnEndGameStart;
    private void OnDisable()
    {
        if (_endGameStarter != null)
            _endGameStarter.EndGameStartHandler -= OnEndGameStart;
    }
    private void OnEndGameStart() => transform.GetChild(0).gameObject.SetActive(true);
}
