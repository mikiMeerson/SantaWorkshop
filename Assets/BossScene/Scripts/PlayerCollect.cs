using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameObject enemyAgent;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            enemyAgent.GetComponent<MoveToGoalAgent>().LoseEpisode();
        }
    }
}
