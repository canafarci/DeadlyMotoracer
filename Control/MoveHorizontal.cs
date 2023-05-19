using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] float _smoothingFactor, _xBounds, _sensitivity = 5.71f;
    InputReader _inputReader;
    bool _controlRemoved = false;
    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_controlRemoved) return;

        Vector3 localPos = transform.localPosition;
        localPos.z = (localPos.z - 1f * _inputReader.ZValue * _sensitivity);

        localPos.z = Mathf.Clamp(localPos.z, -_xBounds, _xBounds);

        Vector3 lerpedPos = Vector3.Lerp(transform.localPosition, localPos, _smoothingFactor);
        transform.localPosition = lerpedPos;
    }

    public void RemoveControl() => _controlRemoved = true;
    public void EnableControl() => _controlRemoved = false;
    public void CenterPosition() => transform.DOLocalMoveZ(0, .5f);
}