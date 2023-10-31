using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    public float desiredDistance = 1000f;
    private void Update()
    {
        Vector3 fromOrigin = transform.position - Vector3.zero;
        Vector3 normalizedFromOrigin = fromOrigin.normalized;
        transform.position = Vector3.zero + normalizedFromOrigin * desiredDistance;


        Vector3 quadPosition = transform.position;

        // ���� ��ü�� Z-���� �׻� ����(0, 0, 0) �������� ����
        Vector3 lookAtPosition = Vector3.zero;
        Vector3 directionToZero = -(lookAtPosition - quadPosition);
        Quaternion rotation = Quaternion.LookRotation(directionToZero, Vector3.up);
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
    }
}
