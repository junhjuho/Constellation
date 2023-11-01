using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellaImageManager : MonoBehaviour
{
    public GameObject activeImage;
    public float fadeDuration = 10f;
    private Material activeMaterial;
    private float fadeTime;

    void Update()
    {
        if (activeImage != null && activeMaterial != null)
        {
            FadeInImage();
        }
    }

    public void SetActiveImage(GameObject quad)
    {
        if (activeImage != null)
        {
            activeImage.SetActive(false);
        }

        activeImage = quad;
        activeImage.SetActive(true);
        activeMaterial = activeImage.GetComponent<Renderer>().material;

        Color color = activeMaterial.color;
        color.a = 0;
        activeMaterial.color = color;

        fadeTime = 0;
    }

    private void FadeInImage()
    {
        fadeTime += Time.deltaTime / fadeDuration;
        float alpha = Mathf.Clamp(fadeTime, 0, 1);

        Color color = activeMaterial.color;
        color.a = alpha;
        activeMaterial.color = color;
    }
}