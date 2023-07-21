using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public static CameraSwitcher instance;

    [SerializeField]
    private InputAction action;

    private Animator animator;
    private bool thirdPersonCamera = true;

    public GameObject playerCharacter;
    private Renderer[] playerRenderers;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        playerRenderers = playerCharacter.GetComponentsInChildren<Renderer>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    {
        action.performed += _ => SwitchState();
    }

    private void SwitchState()
    {
        if (thirdPersonCamera)
        {
            animator.Play("FirstPersonCamera");
        } else
        {
            animator.Play("ThirdPersonCamera");
        }

        thirdPersonCamera = !thirdPersonCamera;
        UpdatePlayerVisibility();
    }

    // Hide player when switching to first person
    private void UpdatePlayerVisibility()
    {
        foreach (Renderer renderer in playerRenderers)
        {
            renderer.enabled = thirdPersonCamera;
        }
    }

    public bool IsThirdPersonCamera()
    {
        return thirdPersonCamera;
    }
}
