using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    CanvasGroup _fader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fade(FindObjectOfType<CanvasGroup>()));
        }
    }

    IEnumerator Fade(CanvasGroup fader)
    {
        while (fader.alpha < 1)
        {
            fader.alpha += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
