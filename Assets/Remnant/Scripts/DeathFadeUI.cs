using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathFadeUI : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float finalAlpha = 0.85f;

    public void StartFade()
    {
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        float timer = 0f;

        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            color.a = Mathf.Lerp(0f, finalAlpha, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }
}