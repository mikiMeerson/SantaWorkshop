using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIItems : MonoBehaviour
{
    public TextMeshProUGUI freezePotionsText;

    void Update()
    {
        freezePotionsText.text = GameData.freezePotions.ToString();
    }
}
