using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotify : MonoBehaviour
{
    public static PlayerNotify instance;
    private PlayerUI playerUI;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        playerUI.UpdateText(string.Empty);

        playerUI.UpdateNotification("Discover abilities [Tab]");
        StartCoroutine(TimeoutNotify());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Notificatable"))
        {
            Notify(collider);
        }
    }

    public void Notify(Collider collider)
    {
        Notificatable notificatable = collider.GetComponent<Notificatable>();
        playerUI.UpdateNotification(notificatable.promptMessage);

        StartCoroutine(TimeoutNotify());
    }

    IEnumerator TimeoutNotify()
    {
        yield return new WaitForSeconds(5);
        playerUI.UpdateNotification(string.Empty);
    }
}