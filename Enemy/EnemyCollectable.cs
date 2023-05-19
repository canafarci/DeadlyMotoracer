using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class EnemyCollectable : MonoBehaviour
{
    public int ObstacleLevel;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Image _imageBackground;
    [SerializeField] GameObject _fx;

    Color32 _redColor = new Color32(190, 0, 0, 255);
    Color32 _greenColor = new Color32(0, 193, 20, 255);

    private void Start()
    {
        _text.text = ObstacleLevel.ToString();
        _imageBackground.DOColor(_redColor, .1f);
    }

    private void OnEnable() => FindObjectOfType<PlayerState>().SpeedChangeHandler += OnLevelChange;


    private void OnDisable()
    {
        PlayerState state = FindObjectOfType<PlayerState>();
        if (state != null)
            state.SpeedChangeHandler -= OnLevelChange;
    }
    private void OnLevelChange(int startYear, int targetYear)
    {
        if (targetYear >= ObstacleLevel)
            _imageBackground.DOColor(_greenColor, .25f);
        else
            _imageBackground.DOColor(_redColor, .25f);
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerState state = other.GetComponent<PlayerState>();
            OnPlayerEnterTrigger(state);
        }
    }

    protected virtual void OnPlayerEnterTrigger(PlayerState state)
    {
        GetComponent<Collider>().enabled = false;

        int playerLevel = state.CurrentLevel;
        int finalValue = 0;

        if (playerLevel < ObstacleLevel)
        {
            finalValue = CalculateReturnValue(playerLevel, 3, CalculationType.Subtraction);
        }
        else if (playerLevel >= ObstacleLevel)
        {
            finalValue = CalculateReturnValue(playerLevel, ObstacleLevel, CalculationType.Addition);
            GetComponent<MoveVerticalFixed>().StopMove();
            GetComponentInChildren<Animator>().Play("tripping");

            StartCoroutine(DelayedPlayFX());

            Destroy(gameObject, 2f);
        }

        state.ChangeCurrentSpeed(finalValue);
    }

    IEnumerator DelayedPlayFX()
    {
        yield return new WaitForSeconds(.5f);
        _fx.SetActive(true);
    }

    protected int CalculateReturnValue(int playerYear, int unprocessedValue, CalculationType calculationType)
    {
        switch (calculationType)
        {
            case (CalculationType.Addition):
                return (playerYear + unprocessedValue);
            case (CalculationType.Subtraction):
                return (playerYear - unprocessedValue);
            default:
                return 0;
        }
    }
}
