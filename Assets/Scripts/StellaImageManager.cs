using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StellaImageManager : MonoBehaviour
{
    [System.Serializable]
    public class ImageGroup
    {
        public string groupName;
        public List<GameObject> quads;
    }

    public List<ImageGroup> imageGroups;
    private Dictionary<string, List<Material>> groupMaterials = new Dictionary<string, List<Material>>();
    public float fadeDuration = 2.5f;

    private List<GameObject> activeQuads = new List<GameObject>();
    private List<Material> activeMaterials = new List<Material>();

    [SerializeField] private Button[] allButtons;

    private Coroutine currentFadeCoroutine;

    void Start()
    {
        InitializeGroups();
    }

    private void InitializeGroups()
    {
        foreach (var group in imageGroups)
        {
            List<Material> materials = new List<Material>();
            foreach (var quad in group.quads)
            {
                quad.SetActive(false);
                var mat = quad.GetComponent<Renderer>().material;
                materials.Add(mat);
                SetMaterialAlpha(mat, 0f);
            }
            groupMaterials.Add(group.groupName, materials);
        }
    }

    private void SetMaterialAlpha(Material material, float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }

    public void SetActiveImage(GameObject image)
    {
        SetActiveQuads(new List<GameObject> { image });
    }

    public void ActivateGroup(string groupName)
    {
        if (groupMaterials.ContainsKey(groupName))
        {
            ImageGroup foundGroup = imageGroups.Find(group => group.groupName == groupName);
            SetActiveQuads(foundGroup?.quads);
        }
    }

    private void SetActiveQuads(List<GameObject> newQuads)
    {
        // ���� Ȱ��ȭ�� ���� �߿��� ���ο� ���� ����Ʈ�� ���� �͵��� ���̵� �ƿ���ŵ�ϴ�.
        var quadsToFadeOut = activeQuads.Where(aq => !newQuads.Contains(aq)).ToList();
        var materialsToFadeOut = quadsToFadeOut.Select(q => q.GetComponent<Renderer>().material).ToList();

        // ���� Ȱ��ȭ�� ���带 ���̵� �ƿ���Ű�� �ڷ�ƾ�� �����մϴ�.
        if (quadsToFadeOut.Any())
        {
            StartCoroutine(FadeQuads(quadsToFadeOut, materialsToFadeOut, 0f));
        }

        // ���� Ȱ��ȭ�� ���� �߿��� ���� ��Ȱ��ȭ�� �͵鸸 ���̵� �ν�ŵ�ϴ�.
        var quadsToFadeIn = newQuads.Except(activeQuads).ToList();
        var materialsToFadeIn = quadsToFadeIn.Select(q => q.GetComponent<Renderer>().material).ToList();

        // ���ο� ���带 Ȱ��ȭ ���·� �����մϴ�.
        foreach (var quad in quadsToFadeIn)
        {
            quad.SetActive(true);
            SetMaterialAlpha(quad.GetComponent<Renderer>().material, 0f); // �ʱ� ���İ��� 0���� �����մϴ�.
        }

        // ���ο� ���带 ���̵� �ν�Ű�� �ڷ�ƾ�� �����մϴ�.
        if (quadsToFadeIn.Any())
        {
            StartCoroutine(FadeQuads(quadsToFadeIn, materialsToFadeIn, 1f));
        }

        // ���� Ȱ��ȭ�� ���� ����Ʈ�� ������Ʈ�մϴ�.
        activeQuads = newQuads;
        activeMaterials = newQuads.Select(q => q.GetComponent<Renderer>().material).ToList();
    }
    

    private IEnumerator FadeQuads(List<GameObject> quads, List<Material> materials, float targetAlpha)
    {
        SetButtonsInteractable(false);

        float fadeTime = 0f;
        float startAlpha = targetAlpha == 0f ? 1f : 0f;

        while (fadeTime < fadeDuration)
        {
            fadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, fadeTime / fadeDuration);

            foreach (var mat in materials)
            {
                SetMaterialAlpha(mat, alpha);
            }

            yield return null;
        }


        foreach (var mat in materials)
        {
            SetMaterialAlpha(mat, targetAlpha);
        }

        if (targetAlpha <= 0f)
        {
            foreach (var quad in quads)
            {
                quad.SetActive(false);
            }
        }

        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        foreach (var button in allButtons)
        {
            button.interactable = interactable;
        }
    }
    
}