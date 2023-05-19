using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NearMissTrigger : MonoBehaviour
{
    [SerializeField] bool _isLeftSide;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform parentTransform = transform.parent.transform.parent.transform.parent;
            //print("asd");
            if (_isLeftSide)
                LeftTween(parentTransform);
            else
                RightTween(parentTransform);


            GameObject fx = Instantiate(GameManager.Instance.References.GameConfig.CarSwingFX, transform.parent.parent);
            Destroy(fx, 2f);

            transform.parent.gameObject.SetActive(false);
        }
    }

    /*private void Update()
    {
        if (Input.anyKeyDown)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(transform.DOPunchRotation(new Vector3(0, -40, 30), 1.5f, 3, 1));

        }
    }*/


    void LeftTween(Transform parentTransform)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(parentTransform.DOPunchRotation(new Vector3(0, -40, 0), 1.5f, 3, 1));
    }

    void RightTween(Transform parentTransform)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(parentTransform.DOPunchRotation(new Vector3(0, 40, 0), 1.5f, 3, 1));
    }
}
