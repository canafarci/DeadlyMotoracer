using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStartSetActive : MonoBehaviour
{
    [SerializeField] GameObject[] _objectsToEnable;
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;

    void OnGameStart() => _objectsToEnable.ToList().ForEach(x => x.SetActive(true));
}
