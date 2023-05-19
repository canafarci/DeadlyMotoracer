using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndGameScrollView : MonoBehaviour
{
    ScrollRect _scrollRect;
    private void Awake() => _scrollRect = GetComponent<ScrollRect>();
    private void Start() => StartCoroutine(DelayedRoutine());

    IEnumerator DelayedRoutine()
    {
        yield return new WaitForEndOfFrame();
        float contentHeight = _scrollRect.content.sizeDelta.y;
        float individualItemheight = 100f;
        print(_scrollRect.content.sizeDelta.y);
        print((individualItemheight / contentHeight));
        _scrollRect.verticalNormalizedPosition = 0;

        _scrollRect.DOVerticalNormalizedPos(1f + (115f /* height of last item */ / contentHeight), 5f);
    }
}
