using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlashUI : MonoBehaviour
{
    public Image flashImage;
    public float maxAlpha = 0.45f;
    public float fadeTime = 0.25f;

    private Coroutine flashRoutine;

    void Start()
    {
        SetAlpha(0f);
    }

    public void TriggerFlash()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        SetAlpha(maxAlpha);

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(maxAlpha, 0f, timer / fadeTime);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(0f);
    }

    private void SetAlpha(float alpha)
    {
        if (flashImage == null) return;

        Color color = flashImage.color;
        color.r = 1f;
        color.g = 0f;
        color.b = 0f;
        color.a = alpha;
        flashImage.color = color;
    }
    public void ClearFlash()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        SetAlpha(0f);
    }
}