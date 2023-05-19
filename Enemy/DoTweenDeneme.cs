using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenDeneme : MonoBehaviour
{
    public float duration;
    public int vibrato;
    public float elasticity;

    private void Start()
    {

    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform.DOPunchRotation(new Vector3(0, 40, 30), duration, vibrato, elasticity));

        }
    }
    /*private void LateUpdate()
    {
        Vector3 Pos = transform.localPosition;
        if (Pos.y>0)
        {
            Pos.y = 0;
        }
        transform.localPosition = Pos;
    }*/

}
