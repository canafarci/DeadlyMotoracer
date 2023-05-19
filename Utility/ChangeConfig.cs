using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeConfig : MonoBehaviour
{
    [SerializeField] GameConfig _config;
    void Start()
    {
        GameManager.Instance.References.GameConfig = _config;
    }
}
