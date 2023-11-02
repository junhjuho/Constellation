using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealth ��ũ��Ʈ�� ���� ����

    // �ٸ� Collider�� �� ������Ʈ�� Trigger�� ������ ȣ��˴ϴ�.
    private void OnTriggerEnter(Collider other)
    {
        // 'other'�� �÷��̾����� Ȯ���մϴ�.
        if (other.CompareTag("Player"))
        {
            // ���� Ŭ���� ������ ���⿡ �ۼ��մϴ�.
            // ���� ���, ��ũ�� �����ϰ� �����ϴ� �ڵ� ���� �� �� �ֽ��ϴ�.
            float playerHealthPoints = playerHealth.health; // �÷��̾��� ���� ü���� �����ɴϴ�.
            string rank = DetermineRank(playerHealthPoints); // ��ũ�� �����ϴ� �Լ��� ȣ���մϴ�.

            // ��ũ�� �ؽ�Ʈ�� ����ϴ� ������ ������ �����Ͻø� �˴ϴ�.
            // ��: someUITextElement.text = "Your rank: " + rank;
            Debug.Log("Your rank: " + rank); // �ֿܼ� ��ũ�� ����մϴ�.
        }
    }

    // �÷��̾��� ü�� ������ ���� ��ũ�� �����ϴ� �޼ҵ��Դϴ�.
    private string DetermineRank(float health)
    {
        if (health >= 100) return "SSS";
        if (health >= 90) return "SS";
        if (health >= 80) return "S";
        // 10�� ������ ��� �������ϴ�.
        if (health >= 70) return "A";
        if (health >= 60) return "B";
        if (health >= 50) return "C";
        // 50�� �̸��� ������ D ��ũ�Դϴ�.
        return "D";
    }
}