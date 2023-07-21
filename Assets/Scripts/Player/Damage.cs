using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    const int ENEMY_DAMAGE = 5;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            if (GameData.healthAmount <= ENEMY_DAMAGE)
                SceneManager.LoadScene("GameOverMenu");
            else
                PlayerVitals.instance.DecreaseHealth(ENEMY_DAMAGE);
        }
    }
}
