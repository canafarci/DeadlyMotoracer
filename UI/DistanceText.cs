using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void LateUpdate()
    {
        float distance = transform.position.x / 100f;

        _text.text = distance.ToString("F2");
    }
}
