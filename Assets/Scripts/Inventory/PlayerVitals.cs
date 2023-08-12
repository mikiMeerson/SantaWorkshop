using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVitals : MonoBehaviour
{
    public static PlayerVitals instance;

    public ProgressBar healthBar;
    public ProgressBar warmthBar;

    private void Awake()
    {
        if (healthBar != null && warmthBar != null)
        {
            instance = this;

            if (GameData.healthAmount == 0 || GameData.warmthAmount == 0)
            {
                GameData.healthAmount = 100;
                GameData.warmthAmount = 90;
            }

            healthBar.current = GameData.healthAmount;
            warmthBar.current = GameData.warmthAmount;
        }
    }

    public void IncreaseHealth(int value)
    {
        healthBar.current += value;
        GameData.healthAmount += value;
    }

    public void IncreaseWarmth(int value)
    {
        warmthBar.current += value;
        GameData.warmthAmount += value;
    }

    public void DecreaseHealth(int value)
    {
        healthBar.current -= value;
        GameData.healthAmount -= value;
    }

    public void DecreaseWarmth(int value)
    {
        warmthBar.current -= value;
        GameData.warmthAmount -= value;
    }
}
