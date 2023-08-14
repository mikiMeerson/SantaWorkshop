using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    public Animator animator;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    private bool lerpCrouch;
    private float crouchTimer = 0f;
    private bool crouching;

    private bool sprinting;

    private bool shooting;
    public bool isShootingEnabled = false;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    private float bulletSpeed = 2000f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        GameData.bottleMisses = 0;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (animator.GetBool("isJumping") && isGrounded && playerVelocity.y <= 0)
            animator.SetBool("isJumping", false);
        
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded) {
            animator.SetBool("isJumping", true);
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        animator.SetBool("isRunning", sprinting);

        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }

    public void Shoot()
    {
        if (isShootingEnabled)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.transform.forward * bulletSpeed);
        }
    }
}
