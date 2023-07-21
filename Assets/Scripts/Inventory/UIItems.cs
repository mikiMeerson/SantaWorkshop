using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItems : MonoBehaviour
{
    public TextMeshProUGUI freezePotionsText;

    void Update()
    {
        freezePotionsText.text = GameData.freezePotions.ToString();
    }
}
