using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] bottlePrefabs;

    public float minSpawnDelay = 3f;
    public float maxSpawnDelay = 6f;

    public float minAngle = -15f;
    public float maxAngle = 15;

    public float minForce = 18f;
    public float maxForce = 22f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {

            GameObject prefab = bottlePrefabs[Random.Range(0, bottlePrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject bottle = Instantiate(prefab, position, rotation);

            float force = Random.Range(minForce, maxForce);
            bottle.GetComponent<Rigidbody>().AddForce(bottle.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
