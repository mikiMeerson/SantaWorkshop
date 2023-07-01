using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowBomb : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown = 2.0f;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce = 70.0f;
    public float throwUpwardForce = 10.0f;

    bool readyToThrow = false;

    private void Update()
    {
        readyToThrow = !CameraSwitcher.instance.IsThirdPersonCamera();

        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = !CameraSwitcher.instance.IsThirdPersonCamera();
    }
}