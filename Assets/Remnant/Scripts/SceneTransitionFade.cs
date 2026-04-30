using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionFade : MonoBehaviour
{
    public string sceneToLoad;
    public Image fadeImage;
    public float fadeDuration = 0.8f;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTransitioning)
        {
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        isTransitioning = true;

        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}