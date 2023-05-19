using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YearGateSetGraphics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _calculationText, _valueText, _timeTypeText;
    YearChangeTrigger _yearTrigger;
    private void Awake() => _yearTrigger = GetComponent<YearChangeTrigger>();

    void Start()
    {
        SetGateVisuals();
    }

    void SetGateVisuals()
    {
        _valueText.text = _yearTrigger.Value.ToString();

        switch (_yearTrigger.CalculationType)
        {
            case (CalculationType.Addition):
                _calculationText.text = "+";
                break;
            case (CalculationType.Subtraction):
                _calculationText.text = "-";
                break;
            case (CalculationType.Multiplication):
                _calculationText.text = "X";
                break;
            case (CalculationType.Division):
                _calculationText.text = " /";
                break;
            default:
                break;
        }

        if (_yearTrigger.TimeType == TimeType.Year)
            _timeTypeText.text = "Year";
        else
            _timeTypeText.text = "Month";

        

    }
}
