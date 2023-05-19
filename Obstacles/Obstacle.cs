using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerState state = other.GetComponent<PlayerState>();
            OnPlayerEnterObstacle(other, state);

        }
    }

    protected virtual void OnPlayerEnterObstacle(Collider other, PlayerState state)
    {
        GetComponents<Collider>().ToList().ForEach(x => x.enabled = false);
        int playerYear = state.CurrentLevel;
        int finalValue = playerYear - 1;

        state.ChangeCurrentSpeed(finalValue);

        // GameObject prefab = GameManager.Instance.References.GameConfig.ObstacleFX;
        // GameObject fx = Instantiate(prefab, transform.position, prefab.transform.rotation);

        // Destroy(fx, 2f);
    }
}