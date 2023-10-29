using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFade : MonoBehaviour
{
    public GameObject quad; // Quad ������Ʈ�� ���⿡ �Ҵ��մϴ�.
    public float fadeDuration = 1.0f; // ���̵� �� ���� �ð� (��)

    bool isFading = false;
    float currentAlpha = 0.0f;
    Material quadMaterial;
    Color originalColor;

    void Start()
    {
        // Quad ������Ʈ�� Material �� ���� ������ �����ɴϴ�.
        quadMaterial = quad.GetComponent<Renderer>().material;
        originalColor = quadMaterial.color;
    }

    void Update()
    {
        if (isFading)
        {
            // ���̵� �� ���̶�� ���İ��� ������ ������ŵ�ϴ�.
            currentAlpha += Time.deltaTime / fadeDuration;
            Color newColor = quadMaterial.color;
            newColor.a = Mathf.Clamp01(currentAlpha);
            quadMaterial.color = newColor;

            if (currentAlpha >= 1.0f)
            {
                // ���̵� ���� �Ϸ�Ǹ� �÷��׸� �����մϴ�.
                isFading = false;
            }
        }
    }

    public void OnQuadClick()
    {
        if (!isFading)
        {
            // Ŭ�� �� ���̵� �� �ִϸ��̼��� �����մϴ�.
            currentAlpha = 0.0f;
            isFading = true;
        }
    }
}
