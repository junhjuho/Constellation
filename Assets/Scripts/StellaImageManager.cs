using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellaImageManager : MonoBehaviour
{
    public GameObject activeImage;
    public GameObject pastImage;
    public float fadeDuration = 2.5f;
    private Material activeMaterial;
    private Material pastMaterial;
    private float fadeTime;
    private float fadeOutTime;

    void Update()
    {
        if (activeImage != null && activeMaterial != null)
        {
            FadeInImage();
        }

        if (pastImage != null && pastMaterial != null)
        {
            FadeOutImage();
        }
    }

    public void SetActiveImage(GameObject quad)
    {
        StartCoroutine(SetActiveImageCoroutine(quad));
    }

    private IEnumerator SetActiveImageCoroutine(GameObject quad)
    {
        if (activeImage == quad)
        {
            pastImage = activeImage;
            pastMaterial = activeMaterial;
            fadeOutTime = 0;

            yield return StartCoroutine(FadeOutImage());

            activeImage.SetActive(false);
            activeImage = null;
            activeMaterial = null;
        }
        else
        {
            if (activeImage != null)
            {
                pastImage = activeImage;
                pastMaterial = activeMaterial;
                fadeOutTime = 0;

                StartCoroutine(FadeOutImage());
            }

            activeImage = quad;
            activeImage.SetActive(true);
            activeMaterial = activeImage.GetComponent<Renderer>().material;

            Color color = activeMaterial.color;
            color.a = 0;
            activeMaterial.color = color;

            fadeTime = 0;

            yield return StartCoroutine(FadeInImage());
        }
    }

    private IEnumerator FadeInImage()
    {
        while (activeMaterial.color.a < 1)
        {
            fadeTime += Time.deltaTime / fadeDuration;
            float alpha = Mathf.Clamp(fadeTime, 0, 1);

            Color color = activeMaterial.color;
            color.a = alpha;
            activeMaterial.color = color;

            yield return null;
        }
    }

    private IEnumerator FadeOutImage()
    {
        if (pastImage == null || pastMaterial == null)
        {
            yield break;
        }

        while (pastMaterial.color.a > 0)
        {
            fadeOutTime += Time.deltaTime / fadeDuration;
            float alpha = 1 - Mathf.Clamp(fadeOutTime, 0, 1);

            Color color = pastMaterial.color;
            color.a = alpha;
            pastMaterial.color = color;

            yield return null;
        }

        pastImage.SetActive(false);
        pastImage = null;
        pastMaterial = null;
    }
}