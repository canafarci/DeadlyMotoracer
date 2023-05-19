using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnableDisableFX : MonoBehaviour
{
    public GameObject[] FXs;
    bool _isForceActivated = false;

    PlayerInsideVolume _playerInside;
    private void Awake()
    {
        _playerInside = FindObjectOfType<PlayerInsideVolume>();
    }

    void Start()
    {
        StartCoroutine(MoveMeter());
    }

    IEnumerator MoveMeter()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {

            if (_playerInside.InsideVolume)
            {
                if (!FXs[0].gameObject.activeSelf)
                    FXs.ToList().ForEach(x => x.SetActive(true));
                yield return new WaitForSeconds(0.1f);
            }
            else if (!_playerInside.InsideVolume && !_isForceActivated)
            {
                if (FXs[0].gameObject.activeSelf)
                    FXs.ToList().ForEach(x => x.SetActive(false));
                yield return new WaitForSeconds(0.1f);
            }

            else if (_isForceActivated)
            {
                if (!FXs[0].gameObject.activeSelf)
                    FXs.ToList().ForEach(x => x.SetActive(true));
                yield return new WaitForSeconds(0.1f);
            }

        }
    }

    public IEnumerator ForceActivate()
    {
        print("called");
        _isForceActivated = true;
        yield return new WaitForSeconds(3f);
        _isForceActivated = false;
    }


}
