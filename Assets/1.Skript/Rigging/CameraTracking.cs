using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{ 
    public Transform cameraTransform;

    void Update()
    {
        // �� ������Ʈ�� ��ġ�� ī�޶� ��ġ�� ����
        transform.position = cameraTransform.position;

        // �� ������Ʈ�� ȸ���� ī�޶� ȸ������ ����
        transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);
    }
}
