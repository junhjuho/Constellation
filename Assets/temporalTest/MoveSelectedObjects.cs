using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedObjects : MonoBehaviour
{
    public GameObject parentObject;
    public float rotationSpeed = 30f;

    void Update()
    {
        if (parentObject)
        {
            parentObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            foreach (Transform child in parentObject.transform)
            {
                LineRenderer lineRenderer = child.GetComponent<LineRenderer>();
                if (lineRenderer)
                {
                    for (int i = 0; i < lineRenderer.positionCount; i++)
                    {
                        Vector3 originalPos = lineRenderer.GetPosition(i);
                        lineRenderer.SetPosition(i, originalPos);
                    }
                }
            }
        }
    }
}