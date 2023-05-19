using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableCalculateBase : MonoBehaviour
{
    public CalculationType CalculationType;
    public int Value;

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
        int playerYear = state.CurrentLevel;
        int finalValue = CalculateReturnValue(playerYear, Value);
        state.ChangeCurrentSpeed(finalValue);
    }

    protected int CalculateReturnValue(int playerYear, int unprocessedValue)
    {
        switch (CalculationType)
        {
            case (CalculationType.Addition):
                return (playerYear + unprocessedValue);
            case (CalculationType.Subtraction):
                return (playerYear - unprocessedValue);
            case (CalculationType.Multiplication):
                return (playerYear * unprocessedValue);
            case (CalculationType.Division):
                return Mathf.RoundToInt(((float)playerYear / (float)unprocessedValue));
            default:
                return 0;
        }
    }
}