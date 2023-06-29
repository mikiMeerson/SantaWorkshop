using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    public GameObject bigExplosionPrefab;
    public UnityEvent triggerBombAnimation;

    void Start()
    {
        
    }

    //void FixedUpdate()
    //{
    //    if (gameObject == enabled)
    //    {
    //        Invoke("Detonate", 6.5f);
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
        triggerBombAnimation.Invoke();
        Invoke("Detonate", 6.5f);
    }

    void Detonate()
    {
        Instantiate(bigExplosionPrefab, transform.position, transform.rotation);
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
