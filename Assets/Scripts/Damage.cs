using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    const int ENEMY_DAMAGE = 10;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log(PlayerVitals.instance.GetHealthAmount());
            if (PlayerVitals.instance.GetHealthAmount() <= ENEMY_DAMAGE)
            {
                //TODO GAME OVER
            } else
                PlayerVitals.instance.DecreaseHealth(ENEMY_DAMAGE);
        }
    }
}
