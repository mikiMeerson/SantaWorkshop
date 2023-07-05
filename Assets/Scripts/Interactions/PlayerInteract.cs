using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera firstPersonCam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    public bool isInteracting;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        playerUI.UpdateText(string.Empty);
    }

    void Update()
    {
        if (isInteracting)
        {
            playerUI.UpdateText(string.Empty);

            Ray ray = new Ray(firstPersonCam.transform.position, firstPersonCam.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    playerUI.UpdateText(interactable.promptMessage);

                    if (inputManager.onFoot.Interact.triggered)
                    {
                        interactable.BaseInteract();
                    }
                }
            }
        }
        else
            playerUI.UpdateText(string.Empty);
    }
}
