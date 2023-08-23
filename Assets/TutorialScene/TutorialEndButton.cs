using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEndButton : MonoBehaviour
{
    public GameObject toHide;
    public GameObject toShow;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    private bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator EndTutorial() {
        toShow.SetActive(true);
        toHide.SetActive(false);
        Vector3 explosionPosition = toShow.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach(Collider hit in colliders)
        {
            hit
                .GetComponent<Rigidbody>()
                ?.AddExplosionForce(
                    power,
                    explosionPosition,
                    radius,
                    upForce,
                    ForceMode.Impulse
                );
        }

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("SantaWorkshop");
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !buttonPressed) {
            buttonPressed = true;
            StartCoroutine(EndTutorial());
        }
    }
}
