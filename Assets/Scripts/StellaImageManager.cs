using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(FadeQuads(activeQuads, activeMaterials, 0f));

        activeQuads = newQuads ?? new List<GameObject>();
        activeMaterials.Clear();

        foreach (var quad in activeQuads)
        {
            quad.SetActive(true);
            var mat = quad.GetComponent<Renderer>().material;
            activeMaterials.Add(mat);
            SetMaterialAlpha(mat, 0f);
        }

        StartCoroutine(FadeQuads(activeQuads, activeMaterials, 1f));
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

        if (targetAlpha == 0f)
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
