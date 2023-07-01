using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVitals : MonoBehaviour
{
    public static PlayerVitals instance;

    public ProgressBar healthBar;
    public ProgressBar warmthBar;

    private int healthAmount;
    private int warmthAmount;

    private void Awake()
    {
        instance = this;
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
    }

    public void IncreaseWarmth(int value)
    {
        warmthBar.current += value;
    }
}
