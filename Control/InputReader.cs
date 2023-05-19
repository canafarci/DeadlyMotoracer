using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour
{
    public Vector3 HitVector { get; private set; }
    public float ZValue { get; private set; }
    public bool IsDragging { get { return _isDragging; } }
    [SerializeField] LayerMask _moveLayer;
    DynamicJoystick _joystick;
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
    }
    bool _isDragging;
    private void Update()
    {
        ZValue = _joystick.Horizontal * Time.deltaTime;
    }

}
