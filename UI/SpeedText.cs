using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    [SerializeField] Image _image;
    TextMeshProUGUI _text;
    int _currentLevel = 1;
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();
    private void OnEnable()
    {
        FindObjectOfType<PlayerState>().SpeedChangeHandler += OnSpeedChange;
        GameStart.OnGameStart += OnGameStart;
        EnemyTrigger.StopPlayerHandler += OnStopPlayer;
    }
    private void OnDisable()
    {
        PlayerState state = FindObjectOfType<PlayerState>();
        if (state != null)
            state.SpeedChangeHandler -= OnSpeedChange;

        GameStart.OnGameStart -= OnGameStart;
        EnemyTrigger.StopPlayerHandler -= OnStopPlayer;
    }
    private void OnGameStart() => _text.text = GameManager.Instance.References.GameConfig.PlayerSpeed.ToString();
    private void OnStopPlayer() => StartCoroutine(SpeedChangeRoutine(0));
    void OnSpeedChange(int startSpeed, int targetSpeed) => StartCoroutine(SpeedChangeRoutine(targetSpeed));
    IEnumerator SpeedChangeRoutine(int targetSpeed)
    {
        if (targetSpeed > _currentLevel)
            _text.DOColor(Color.green, .1f);
        else
            _text.DOColor(Color.red, .5f);

        _text.transform.DOScale(Vector3.one * 1.2f, .25f);

        Tween tween = DOTween.To(() => _currentLevel, x => _currentLevel = x, targetSpeed, .25f);
        DOTween.To(() => _image.fillAmount, x => _image.fillAmount = x, targetSpeed / 70f, 1f);

        while (tween.IsActive())
        {
            _text.text = (_currentLevel * 2).ToString();
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _text.transform.DOScale(Vector3.one, .25f);
        _text.DOColor(Color.white, .15f);
        yield break;
    }
}
