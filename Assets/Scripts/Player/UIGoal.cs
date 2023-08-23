using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGoal : MonoBehaviour
{
    public TextMeshProUGUI giftsText;

    void Start()
    {
        GameObject[] giftsToExplode = GameObject.FindGameObjectsWithTag("Gift");

        int activeGiftsToExplode = 0;

        foreach (GameObject gift in giftsToExplode)
        {
            if (gift.activeSelf)
                activeGiftsToExplode++;
        }
        GameData.giftsToExplode = activeGiftsToExplode;
    }

    void Update()
    {
        if (
            GameData.giftsToExplode == 0 &&
            SceneManager.GetActiveScene().name == "SantaWorkshop" 
        ) {
            SceneManager.LoadScene("Boss");
        }
        else giftsText.text = GameData.giftsToExplode.ToString();
    }
}
