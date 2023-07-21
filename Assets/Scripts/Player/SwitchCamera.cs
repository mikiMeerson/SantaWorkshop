using System.Collections;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public float transitionDuration = 0.5f;

    private Camera activeCamera;
    private PlayerLook playerLook;
    private PlayerInteract playerInteract;

    private void Start()
    {
        playerLook = GetComponent<PlayerLook>();
        playerInteract = GetComponent<PlayerInteract>();
        SetActiveCamera(thirdPersonCamera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeCamera == firstPersonCamera)
            {
                StartCoroutine(Switch(thirdPersonCamera, true));
                playerInteract.isInteracting = false;
            }
            else
            {
                StartCoroutine(Switch(firstPersonCamera, false));
                playerInteract.isInteracting = true;
            }
        }
    }

    private IEnumerator Switch(Camera newCamera, bool zoomIn)
    {
        enabled = false;

        float targetFieldOfView = zoomIn ? 60f : 1f;

        while (activeCamera.fieldOfView > targetFieldOfView)
        {
            activeCamera.fieldOfView -= (Time.deltaTime / transitionDuration) * 100;
            yield return null;
        }

        activeCamera.gameObject.SetActive(false);

        SetActiveCamera(newCamera);

        while (activeCamera.fieldOfView < 60)
        {
            activeCamera.fieldOfView += (Time.deltaTime / transitionDuration) * 100;
            yield return null;
        }

        enabled = true;
    }

    private void SetActiveCamera(Camera camera)
    {
        camera.gameObject.SetActive(true);
        activeCamera = camera;
        playerLook.cam = activeCamera;
    }
}
