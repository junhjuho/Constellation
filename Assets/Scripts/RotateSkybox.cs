using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float RotationSpeed = 1.2f;

    void Update()
    {
        if(RenderSettings.skybox != null)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationSpeed);
        }
    }
}
