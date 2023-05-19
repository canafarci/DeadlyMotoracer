using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTrigger : MonoBehaviour
{
    public static event Action StopPlayerHandler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopPlayerHandler?.Invoke();
            FindObjectOfType<MoveHorizontal>().RemoveControl();

            GameObject prefab = GameManager.Instance.References.GameConfig.BikeCrashFX;

            GameObject fx = Instantiate(prefab, other.transform.position + prefab.transform.position, prefab.transform.rotation);
            Destroy(fx, 2f);

            StartCoroutine(Fade(FindObjectOfType<CanvasGroup>()));
        }
        else if (other.CompareTag("Car"))
        {
            MoveVerticalFixed mover = GetComponentInParent<MoveVerticalFixed>();
            DOTween.To(() => mover.Speed, x => mover.Speed = x, 0, 1);

            MoveVerticalFixed moverOther = other.GetComponentInParent<MoveVerticalFixed>();
            DOTween.To(() => moverOther.Speed, x => moverOther.Speed = x, 0, 1);


            GameObject prefab = GameManager.Instance.References.GameConfig.CarCrashFX;

            GameObject fx = Instantiate(prefab, (other.transform.position + transform.position) / 2, prefab.transform.rotation);
            Destroy(fx, 2f);
        }
    }



    IEnumerator Fade(CanvasGroup fader)
    {
        yield return new WaitForSeconds(1f);
        while (fader.alpha < 1)
        {
            fader.alpha += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
