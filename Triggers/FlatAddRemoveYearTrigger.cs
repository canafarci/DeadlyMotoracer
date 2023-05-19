using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatAddRemoveYearTrigger : VariableCalculateBase
{
    [SerializeField] GameObject _linkedFX;
    protected override void OnPlayerEnterTrigger(PlayerState state)
    {
        // base.OnPlayerEnterTrigger(state);

        // Destroy(_linkedFX, .2f);
        // Destroy(gameObject, .22f);
        // //PlayFX
        // GameObject prefab = GameManager.Instance.References.GameConfig.LevelUpFX;
        // Transform playerModelTransfrom = GameObject.FindGameObjectWithTag("PlayerModel").transform;

        // if (playerModelTransfrom != null)
        // {
        //     GameObject fx = Instantiate(prefab, playerModelTransfrom);
        //     Destroy(fx, 2f);
        // }


    }

}
