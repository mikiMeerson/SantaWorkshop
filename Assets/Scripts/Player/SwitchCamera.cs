using System.Collections;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public float transitionDuration = 0.5f;

    private Camera activeCamera;

    private void Start()
    {
        SetActiveCamera(firstPersonCamera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeCamera == firstPersonCamera)
                StartCoroutine(Switch(thirdPersonCamera, true));
            else
                StartCoroutine(Switch(firstPersonCamera, false));
        }
    }

    private IEnumerator Switch(Camera newCamera, bool zoomIn)
    {
        // Disable user input during the transition
        enabled = false;

        // Calculate the target field of view based on the zoom direction
        float targetFieldOfView = zoomIn ? 60f : 1f;

        // Smoothly adjust the field of view of the current camera
        while (activeCamera.fieldOfView > targetFieldOfView)
        {
            activeCamera.fieldOfView -= (Time.deltaTime / transitionDuration) * 100;
            yield return null;
        }

        // Disable the current camera
        activeCamera.gameObject.SetActive(false);

        // Enable the new camera
        newCamera.gameObject.SetActive(true);
        activeCamera = newCamera;

        // Smoothly adjust the field of view of the new camera
        while (activeCamera.fieldOfView < 60)
        {
            activeCamera.fieldOfView += (Time.deltaTime / transitionDuration) * 100;
            yield return null;
        }

        // Enable user input after the transition
        enabled = true;
    }

    private void SetActiveCamera(Camera camera)
    {
        camera.gameObject.SetActive(true);
        activeCamera = camera;
    }
}
