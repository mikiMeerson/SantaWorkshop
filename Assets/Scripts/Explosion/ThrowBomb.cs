using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowBomb : MonoBehaviour
{
    public static ThrowBomb instance;
    public GameObject objectToThrow;
    public Transform cam;

    public float throwCooldown = 2.0f;

    public float throwForce = 50.0f;
    public float throwUpwardForce = 10.0f;

    bool readyToThrow = false;

    void Awake()
    {
        instance = this;
        readyToThrow = true;
    }

    public void Throw()
    {
        if (readyToThrow)
        {
            readyToThrow = false;

            // instantiate object to throw
            GameObject projectile = Instantiate(objectToThrow, transform.position, cam.rotation);

            // get rigidbody component
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            // calculate direction
            Vector3 forceDirection = cam.transform.forward;

            RaycastHit hit;

            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                forceDirection = (hit.point - transform.position).normalized;
            }

            // add force
            Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            // implement throwCooldown
            Invoke(nameof(ResetThrow), throwCooldown);
        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}