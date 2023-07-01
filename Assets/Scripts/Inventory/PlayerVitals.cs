using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVitals : MonoBehaviour
{
    public static PlayerVitals instance;

    public int health;
    public int warmth;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI warmthText;

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        healthText.text = $"Health: {health}";
    }

    public void IncreaseWarmth(int value)
    {
        warmth += value;
        warmthText.text = $"Warmth: {warmth}";
    }
}
