  using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] CinemachineCamera cinemachineCamera;

    public void ChangeCameraFOV(float speedAmout)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmout));

        if(speedAmout > 0)
        {
            particleSystem.Play();
        }
    }
    IEnumerator ChangeFOVRoutine(float speedAmout)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmout * zoomSpeed, minFOV, maxFOV);
        Mathf.Lerp(Camera.main.fieldOfView, 60f, 0.1f);
        float elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float newFOV = Mathf.Lerp(startFOV, targetFOV, elapsedTime / zoomDuration);
            cinemachineCamera.Lens.FieldOfView = newFOV;
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
