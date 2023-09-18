using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool obj = false;
    public GameObject constellationViewer;
    public GameObject stellaImage;

    public void Viewer()
    {
        if (!obj)
        {
            constellationViewer.SetActive(true);
            obj = true;
        }
        else
        {
            constellationViewer.SetActive(false);
            obj = false;
        }
    }
    public void Image()
    {
        if (!obj)
        {
            stellaImage.SetActive(true);
            obj = true;
        }
        else
        {
            stellaImage.SetActive(false);
            obj = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
