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

    [SerializeField] private GameObject activeImage;
    [SerializeField] private List<GameObject> activeGroup;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private List<Material> activeGroupMaterials;

    [SerializeField] private GameObject pastImage;
    [SerializeField] private List<GameObject> pastGroup;
    [SerializeField] private Material pastMaterial;
    [SerializeField] private List<Material> pastGroupMaterials;

    [SerializeField] private Button[] allButtons;

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
        if (activeImage != image)
        {
            MoveActiveToPast();

            activeImage = image;
            activeMaterial = activeImage.GetComponent<Renderer>().material;

            activeImage.SetActive(true);
            SetMaterialAlpha(activeMaterial, 0f);

            StartCoroutine(FadeInMaterial(activeMaterial));
        }
        else
        {
            MoveActiveToPast();
            StartCoroutine(FadeOutMaterial(activeMaterial));
        }
    }

    public void ActivateGroup(string groupName)
    {
        if (groupMaterials.ContainsKey(groupName))
        {
            if (activeGroup != null && AreGroupsEqual(groupMaterials[groupName], activeGroupMaterials))
            {
                MoveActiveGroupToPast();
                StartCoroutine(FadeOutGroup(activeGroupMaterials));
            }
            else
            {
                MoveActiveGroupToPast();

                ImageGroup foundGroup = imageGroups.Find(group => group.groupName == groupName);
                if (foundGroup != null)
                {
                    activeGroup = new List<GameObject>(foundGroup.quads);
                    activeGroupMaterials = groupMaterials[groupName];

                    foreach (var quad in activeGroup)
                    {
                        quad.SetActive(true);
                        SetMaterialAlpha(quad.GetComponent<Renderer>().material, 0f);
                    }

                    StartCoroutine(FadeInGroup(activeGroupMaterials));
                }
            }
        }
        else
        {
            MoveActiveGroupToPast();
            StartCoroutine(FadeOutGroup(activeGroupMaterials));
        }
    }

    private bool AreGroupsEqual(List<Material> groupA, List<Material> groupB)
    {
        if (groupA == null || groupB == null) return false;
        if (groupA.Count != groupB.Count) return false;

        for (int i = 0; i < groupA.Count; i++)
        {
            if (groupA[i] != groupB[i])
                return false;
        }
        return true;
    }

    private void MoveActiveToPast()
    {
        pastImage = activeImage;
        pastMaterial = activeMaterial;
        activeImage = null;
        activeMaterial = null;
        StartCoroutine(FadeOutMaterial(pastMaterial));
    }

    private void MoveActiveGroupToPast()
    {
        pastGroup = activeGroup;
        pastGroupMaterials = activeGroupMaterials;
        activeGroup = null;
        activeGroupMaterials = null;
        StartCoroutine(FadeOutGroup(pastGroupMaterials));
    }

    private IEnumerator FadeInMaterial(Material material)
    {
        SetButtonsInteractable(false);
        float fadeTime = 0f;
        while (fadeTime < fadeDuration)
        {
            float alpha = fadeTime / fadeDuration;
            SetMaterialAlpha(material, alpha);
            fadeTime += Time.deltaTime;
            yield return null;
        }
        SetMaterialAlpha(material, 1f);
        SetButtonsInteractable(true);
    }

    private IEnumerator FadeOutMaterial(Material material)
    {
        SetButtonsInteractable(false);
        float fadeOutTime = 0f;
        while (fadeOutTime < fadeDuration)
        {
            float alpha = 1f - (fadeOutTime / fadeDuration);
            SetMaterialAlpha(material, alpha);
            fadeOutTime += Time.deltaTime;
            yield return null;
        }
        if (material == pastMaterial)
        {
            pastImage.SetActive(false);
            pastImage = null;
            pastMaterial = null;
        }
        SetButtonsInteractable(true);
    }

    private IEnumerator FadeInGroup(List<Material> materials)
    {
        SetButtonsInteractable(false);
        float fadeTime = 0f;
        while (fadeTime < fadeDuration)
        {
            float alpha = fadeTime / fadeDuration;
            foreach (var mat in materials)
            {
                SetMaterialAlpha(mat, alpha);
            }
            fadeTime += Time.deltaTime;
            yield return null;
        }
        foreach (var mat in materials)
        {
            SetMaterialAlpha(mat, 1f);
        }
        SetButtonsInteractable(true);
    }

    private IEnumerator FadeOutGroup(List<Material> materials)
    {
        SetButtonsInteractable(false);
        float fadeOutTime = 0f;
        while (fadeOutTime < fadeDuration)
        {
            float alpha = 1f - (fadeOutTime / fadeDuration);
            foreach (var mat in materials)
            {
                SetMaterialAlpha(mat, alpha);
            }
            fadeOutTime += Time.deltaTime;
            yield return null;
        }

        foreach (var quad in pastGroup)
        {
            quad.SetActive(false);
        }

        pastGroup = null;
        pastGroupMaterials = null;
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