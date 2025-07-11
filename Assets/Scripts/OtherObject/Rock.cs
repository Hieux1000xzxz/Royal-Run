using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    CinemachineImpulseSource impulseSource;
    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float distance = Vector3.Distance(transform.position, new Vector3(0, 1, 0));
        float shakeIntensity = 1f / distance;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        impulseSource.GenerateImpulse(shakeIntensity);
    }
}

