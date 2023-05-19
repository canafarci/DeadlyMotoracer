using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndGameSetActive : MonoBehaviour
{
    [SerializeField] GameObject[] _itemsToActivate;

    private void OnEnable()
    {
        FindObjectOfType<StartEndGame>().EndGamePreStartHandler += OnEndGamePreStart;
    }
    private void OnDisable()
    {
        StartEndGame endGameStarter = FindObjectOfType<StartEndGame>();
        if (endGameStarter != null)
            endGameStarter.EndGamePreStartHandler -= OnEndGamePreStart;
    }
    private void OnEndGamePreStart()
    {
        _itemsToActivate.ToList().ForEach(x => x.SetActive(true));
    }
}
