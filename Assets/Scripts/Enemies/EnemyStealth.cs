using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStealth : MonoBehaviour
{
    public Animator animator;
    public Transform pathHolder;
    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;

    public LayerMask viewMask;
    public Light spotLight;
    public float viewDistance;
    private float viewAngle;
    private Transform player;
    private Color originalSpotlightColor;

    public float spotPlayerTime = .5f;
    private float playerVisibleTimer;
     
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalSpotlightColor = spotLight.color;
        viewAngle = spotLight.spotAngle;

        Vector3[] waypoints = new Vector3[pathHolder.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        animator.SetBool("isWalking", true);
        StartCoroutine(FollowPath(waypoints));
    }

    void Update()
    {
        if (CanSeePlayer()) playerVisibleTimer += Time.deltaTime;
        else playerVisibleTimer -= Time.deltaTime;

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, spotPlayerTime);
        spotLight.color = Color.Lerp(originalSpotlightColor, Color.red, playerVisibleTimer / spotPlayerTime);

        if (playerVisibleTimer >= spotPlayerTime) SceneManager.LoadScene("GameOverMenu");
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }

            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        animator.SetBool("isWalking", false);
        Vector3 directionToLook = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(directionToLook.z, directionToLook.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
        
        animator.SetBool("isWalking", true);
    }


    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float diffAngle = Vector3.Angle(transform.forward, dirToPlayer);

            if(diffAngle < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 prevPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(prevPosition, waypoint.position);
            prevPosition = waypoint.position;
        }

        Gizmos.DrawLine(prevPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
