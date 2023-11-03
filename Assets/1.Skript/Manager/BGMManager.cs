using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip[] musicTracks; // ������� Ʈ�� �迭
    private int currentTrackIndex = -1; // ���� Ʈ�� �ε���
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    void Awake()
    {
            audioSource = GetComponent<AudioSource>();
            SelectRandomMusic(); // ������ ���� ����
    }

    void SelectRandomMusic()
    {
        if (musicTracks.Length > 0)
        {
            int randomIndex = Random.Range(0, musicTracks.Length);
            // ������ ���õ� Ʈ���� �ٸ� Ʈ���� ���õǵ��� ��
            if (randomIndex == currentTrackIndex)
            {
                randomIndex = (randomIndex + 1) % musicTracks.Length;
            }
            currentTrackIndex = randomIndex;
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();
            audioSource.loop = true; // ���� �ݺ� ���
        }
    }

    // �ٸ� ������ �̵��� �� �� �Լ��� ȣ���Ͽ� ������ ����
    public void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}