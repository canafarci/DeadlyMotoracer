using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTiltAnimation : MonoBehaviour
{
    public Animator Animator;

    private void Update()
    {
        float x = transform.localRotation.z;

        float scaled = (x + 0.0675f) * (1) / (0.125f);

        Animator.SetFloat("Blend", scaled);
    }

}
