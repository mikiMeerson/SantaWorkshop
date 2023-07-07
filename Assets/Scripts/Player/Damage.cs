using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    const int ENEMY_DAMAGE = 5;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            Debug.Log(PlayerVitals.instance.GetHealthAmount());
            if (PlayerVitals.instance.GetHealthAmount() <= ENEMY_DAMAGE)
            {
                SceneManager.LoadScene("GameOverMenu");
            } else
                PlayerVitals.instance.DecreaseHealth(ENEMY_DAMAGE);
        }
    }
}
