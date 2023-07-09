using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public static WinLevel instance;
    
    private bool isCollectedGoals;
    private bool isDestroyedGifts;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isDestroyedGifts && isCollectedGoals) OnWinLevel();
    }

    public void CollectGoal()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Goal").Length);
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0) isCollectedGoals = true;
    }

    public void DestroyGift()
    {
        if (GameObject.FindGameObjectsWithTag("Gift").Length == 0) isDestroyedGifts = true;
    }

    private void OnWinLevel()
    {
        SceneManager.LoadScene("Boss");
    }
}
