using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearChangeTrigger : VariableCalculateBase
{
    public TimeType TimeType;
    int _processedValue;

    private void Start()
    {
        if (TimeType == TimeType.Month)
            _processedValue = Mathf.FloorToInt((float)Value / 12f);
        else
            _processedValue = Value;
    }

    protected override void OnPlayerEnterTrigger(PlayerState state)
    {
        int playerYear = state.CurrentLevel;
        int finalValue = CalculateReturnValue(playerYear, _processedValue);
        state.ChangeCurrentSpeed(finalValue);
    }
}