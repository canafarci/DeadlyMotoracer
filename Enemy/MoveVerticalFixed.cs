using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVerticalFixed : MonoBehaviour
{
    public float Speed = 0f;
    [SerializeField] bool _isMovingForward;

    private void Start()
    {
        if (!_isMovingForward)
            Speed = Speed * -1;
    }
    private void Update()
    {
        Vector3 pos = transform.localPosition;
        Vector3 forward = -1 * transform.forward * Speed * Time.deltaTime;
        pos += forward;
        // pos.x += _speed * Time.deltaTime;
        transform.localPosition = pos;
    }

    public void StopMove()
    {
        DOTween.To(() => Speed, x => Speed = x, 0, 1);
    }
}
