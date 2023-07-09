using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeGift : MonoBehaviour
{
    public GameObject fracturedObject;
    public GameObject explosionVFX;
    public GameObject minimapIcon;

    public float explosionMinForce = 5;
    public float exosionMaxForce = 100;
    public float explosionForceRadius = 10;
    public float fragScaleFactor = 1;

    private GameObject fracObj;

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Pile" && collision.gameObject.tag != "Ground")
        {
            Explode();
        }
    }

    void Explode()
    {
        fracObj = Instantiate(fracturedObject, transform.position, transform.rotation) as GameObject;
        Instantiate(explosionVFX, transform.position, transform.rotation);

        gameObject.SetActive(false);
        minimapIcon.SetActive(false);

        foreach (Transform t in fracObj.transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(explosionMinForce, exosionMaxForce), transform.position, explosionForceRadius);
            }
        }

        WinLevel.instance.DestroyGift();
    }
}
