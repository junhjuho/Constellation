using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIlineManager : MonoBehaviour
{
    public GameObject constellationViewer;
    Viewer cv;

    bool obj = false;
    // Start is called before the first frame update
    void Start()
    {
        cv = constellationViewer.GetComponent<Viewer>();
    }

    public void Viewer() // 전체 별자리
    {
        obj = !obj;

        constellationViewer.SetActive(obj);
    }

    public void stellImageBtn(int i)
    {
        GameObject stellaObject = cv.stellaObject[i];

        obj = !obj;

        stellaObject.SetActive(obj);
    }
    
}
