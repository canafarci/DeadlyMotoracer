using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using System.Linq;
using UnityEngine.SceneManagement;

public class HitRagdoll : MonoBehaviour
{
    public GameObject target;
    private void OnEnable() => EnemyTrigger.StopPlayerHandler += OnStopPlayer;
    private void OnDisable() => EnemyTrigger.StopPlayerHandler -= OnStopPlayer;
    private void OnStopPlayer()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 4 || index == 5 || index == 6 || index == 7)
            target.transform.parent = null;
        target.GetComponent<FullBodyBipedIK>().enabled = false;
        Animator animator = target.GetComponent<Animator>();
        // Find bones (Humanoids)
        BipedRagdollReferences r = BipedRagdollReferences.FromAvatar(animator);
        animator.enabled = false;

        // How would you like your ragdoll?
        BipedRagdollCreator.Options options = BipedRagdollCreator.AutodetectOptions(r);
        BipedRagdollCreator.Create(r, options);

        target.transform.GetComponentsInChildren<Transform>().ToList().FirstOrDefault(x => x.gameObject.name == "Hips").GetComponent<Rigidbody>().AddForce(Vector3.right * 1500f, ForceMode.Impulse);


        Debug.Log("A ragdoll was successfully created.");


        if (index == 4 || index == 5 || index == 6 || index == 7)
            gameObject.SetActive(false);
    }
}
