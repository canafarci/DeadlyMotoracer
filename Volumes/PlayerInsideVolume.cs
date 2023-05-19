using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInsideVolume : MonoBehaviour
{
    public bool InsideVolume { get { return _insideVolume; } }
    bool _insideVolume;
    float _cooldown = 0.1f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cooldown = 0.1f;
        }
    }

    private void FixedUpdate()
    {
        _cooldown -= Time.fixedDeltaTime;

        if (_cooldown < 0)
            _insideVolume = false;
        else
            _insideVolume = true;

        //print(_insideVolume);
    }
}
