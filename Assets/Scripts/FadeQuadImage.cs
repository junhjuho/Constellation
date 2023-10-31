using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeQuadImage : MonoBehaviour
{
    public float fadeDuration = 2;
    public Color fadeColor;
    private Material material;
    private bool isFading = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        Color initialColor = fadeColor;
        initialColor.a = 0;
        material.color = initialColor;
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeRoutine(0, 1));
        }
    }

    public void FadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeRoutine(1, 0));
        }
    }

    private IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        isFading = true;
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            Color newColor = fadeColor;
            newColor.a = alpha;
            material.color = newColor;
            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = fadeColor;
        finalColor.a = alphaOut;
        material.color = finalColor;
        isFading = false;
    }
}