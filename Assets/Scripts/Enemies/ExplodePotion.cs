using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePotion : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private bool once = true;

    void OnCollisionEnter(Collision collision)
    {
        if (once)
        {
            var em = particleSystem.emission;
            var dur = particleSystem.duration;

            em.enabled = true;
            particleSystem.Play();

            once = false;
            Invoke(nameof(DestroyObj), dur);
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
