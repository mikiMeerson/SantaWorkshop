using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Bottle : MonoBehaviour
{
    private TextMeshProUGUI missesText;

    private void Awake()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;

        if (canvasTransform != null)
        {
            Transform statsTransform = canvasTransform.Find("Stats");

            if (statsTransform != null)
            {
                Transform missesTransform = statsTransform.Find("Misses");

                if (missesTransform != null)
                { 
                    missesText = missesTransform.GetComponentInChildren<TextMeshProUGUI>();

                    if (missesText == null) Debug.LogError("TextMeshPro component not found under Misses.");
                }
                else  Debug.LogError("Misses transform not found under Stats.");
            }
            else  Debug.LogError("Stats transform not found under Canvas.");
        }
        else Debug.LogError("Canvas object not found.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit");
            Destroy(collision.gameObject);
            Destroy(gameObject);

        } else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameData.bottleMisses++;

            if (missesText != null) missesText.text = GameData.bottleMisses.ToString() + "/10";

            if (GameData.bottleMisses >= 10) SceneManager.LoadScene("GameOverMenu");
        }
    }
}
