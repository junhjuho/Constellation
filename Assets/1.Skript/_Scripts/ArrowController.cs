using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;
    [SerializeField] private float arrowMaxSpeed = 15f;
    [SerializeField] private AudioSource bowReleaseAudioSource;
    [SerializeField] Rigidbody bowRigidbody;

    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        bowReleaseAudioSource.Play();
        midPointVisual.SetActive(false);

        Manager.Haptic.VibrateBothControllers(HapticController.objectStrength, HapticController.objectDuration);
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        Vector3 combinedForce = (midPointVisual.transform.forward * strength * arrowMaxSpeed) + bowRigidbody.velocity;
        rb.AddForce(combinedForce, ForceMode.Impulse);
    }
}
