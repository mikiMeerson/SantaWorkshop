using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVitals : MonoBehaviour
{
    public static PlayerVitals instance;

    public ProgressBar healthBar;
    public ProgressBar warmthBar;

    private int healthAmount = 90;
    private int warmthAmount = 80;

    private void Awake()
    {
        instance = this;
        healthBar.current = healthAmount;
        warmthBar.current = warmthAmount;
    }

    public int GetHealthAmount()
    {
        return healthAmount;
    }

    public int GetWarmthAmount()
    {
        return warmthAmount;
    }

    public void IncreaseHealth(int value)
    {
        healthBar.current += value;
        healthAmount += value;
    }

    public void IncreaseWarmth(int value)
    {
        warmthBar.current += value;
        warmthAmount += value;
    }

    public void DecreaseHealth(int value)
    {
        healthBar.current -= value;
        healthAmount -= value;
    }

    public void DecreaseWarmth(int value)
    {
        warmthBar.current -= value;
        warmthAmount -= value;
    }
}
