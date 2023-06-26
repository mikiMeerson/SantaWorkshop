using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
