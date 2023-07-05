using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]
    private TextMeshProUGUI notificationText;
    [SerializeField]
    private Image notificationSlot;

    private bool isNotificationActive;

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdateNotification(string notificationMessage)
    {
        if (notificationMessage == string.Empty)
        {
            Debug.Log("notificationMessage == string.Empty");
            isNotificationActive = false;
        }
        else
        {
            Debug.Log("else");
            notificationText.text = notificationMessage;
            isNotificationActive = true;
        }

        notificationSlot.GetComponent<Animator>().SetBool("IsNotificationActive", isNotificationActive);
    }
}
