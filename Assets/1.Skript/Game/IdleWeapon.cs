using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IdleWeapon : MonoBehaviour
{
    public XRGrabInteractable interactable;
    public GameObject interactionIndicator; // ȭ��ǥ�� �ٸ� �ð��� ǥ�� ������Ʈ
    private Quaternion defaultRotation;
    private bool isBeingGrabbed = false;

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        defaultRotation = transform.rotation; // �⺻ ȸ���� ����
        // ���ͷ��� �̺�Ʈ�� ���� �ݹ� �Լ� ���
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExit);
    }

    void Update()
    {
        // ���ͷ��� ���¿� ���� ������Ʈ�� ȸ���� ǥ�ø� ������Ʈ
        if (!isBeingGrabbed)
        {
            
            interactionIndicator.SetActive(true); // ���ͷ��� ���� ǥ�� Ȱ��ȭ
        }
        else
        {
            interactionIndicator.SetActive(false); // ���ͷ��� ���� ǥ�� ��Ȱ��ȭ
        }
    }

    // XRGrabInteractable �̺�Ʈ�� ���� ������Ʈ�� �޼���
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        isBeingGrabbed = true; // ������Ʈ�� ���� ���·� ����
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        isBeingGrabbed = false; // ������Ʈ�� ������ ���·� ����
        StartCoroutine(SetRotation());
    }

    IEnumerator SetRotation()
    {
        yield return new WaitForSeconds(3f);
        transform.rotation = defaultRotation;
        transform.position += new Vector3(0, 0.6f, 0);
    }
}