using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerState : MonoBehaviour
{
    public event Action<int, int> SpeedChangeHandler;
    public event Action<int> StageChangeHandler;
    public int CurrentLevel { get { return _currentLevel; } }
    [SerializeField] int _currentLevel;
    Coroutine _levelChangeRoutine;
    private void Start() => _currentLevel = (int)GameManager.Instance.References.GameConfig.PlayerSpeed;
    public void ChangeCurrentSpeed(int change) => OnSpeedChange(_currentLevel, _currentLevel + change);
    void OnSpeedChange(int startSpeed, int targetSpeed)
    {
        SpeedChangeHandler?.Invoke(startSpeed, targetSpeed);

        _currentLevel = targetSpeed;

        //0, 400, 1000, 1500, 2000, 2500 f.e.
        List<int> stageChangeLevels = GameManager.Instance.References.GameConfig.StageChangeLevels.ToList();


        //! LINQ METHOD
        // int closestLevelDownYear = lvlChangeYears.TakeWhile(p => p <= startYear).Last();
        // int closestLevelUpYear = lvlChangeYears.SkipWhile(p => p <= startYear).First();

        //! BINARY SEARCH METHOD
        //* Return value: The zero-based index of item in the sorted List, if item is found; otherwise, 
        //* a negative number that is the bitwise complement of the index of the next element that is larger than item or,
        //* if there is no larger element, the bitwise complement of Count."

        int binaryIndex = stageChangeLevels.BinarySearch(startSpeed);
        int closestStageDownLevel = binaryIndex < 0 ? stageChangeLevels[~binaryIndex - 1] : stageChangeLevels[binaryIndex];
        int closestStageUpLevel = binaryIndex < 0 ? stageChangeLevels[~binaryIndex] : stageChangeLevels[binaryIndex + 1];

        //print(closestStageDownLevel + "  " + closestStageUpLevel);

        if (targetSpeed >= closestStageUpLevel && startSpeed != closestStageUpLevel)
            StageChange(stageChangeLevels.IndexOf(closestStageUpLevel), true);
        else if (targetSpeed < closestStageDownLevel)
            StageChange(stageChangeLevels.IndexOf(closestStageDownLevel) - 1, false);
    }

    private void StageChange(int index, bool levelUp)
    {
        StageChangeHandler?.Invoke(index);
        BranchedSetActive[] array = GetComponentsInChildren<BranchedSetActive>(true);
        BranchedSetActive branch = array.FirstOrDefault(x => x.Level == index);
        if (branch != null)
            branch.SetItemActive();
        array.Where(x => x.Level != index).ToList().ForEach(x => x.SetItemInactive());

        if (levelUp)
        {
            GameObject fx = Instantiate(GameManager.Instance.References.GameConfig.StageUpFX, transform);

            Destroy(fx, 2f);
        }
        else
        {
            GameObject fx = Instantiate(GameManager.Instance.References.GameConfig.StageDownFX, transform);
            Destroy(fx, 2f);
        }


    }

    // private void Start() => StartCoroutine(OnYearChange(0, 400));
}
