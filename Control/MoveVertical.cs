using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    [SerializeField] Transform _rayOrigin;
    [SerializeField] LayerMask _verticalLayer;
    Vector3 _targetPos;
    float _maxHeight = 20f;

    private void Update()
    {
        Ray ray = new Ray(_rayOrigin.position, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _verticalLayer))
        {
            _targetPos = hit.point;
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 currentPos = transform.localPosition;

        pos.y = _targetPos.y;

        if (pos.y == currentPos.y)
            return;
        else if (pos.y > currentPos.y)
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 0.75f);
        else
        {
            float dist = currentPos.y - pos.y;
            transform.localPosition = Vector3.MoveTowards(currentPos, pos, (_maxHeight - dist) * 2f * Time.deltaTime);
        }
    }
}
