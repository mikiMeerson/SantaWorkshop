using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    private int bottlesAmount = 15;
    public TextMeshProUGUI bottlesText;
    
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
            bottlesAmount -= 1;
            bottlesText.text = bottlesAmount.ToString();

            if (bottlesAmount == 0) SceneManager.LoadScene("VictoryMenu");

            GameObject prefab = bottlePrefabs[Random.Range(0, bottlePrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject bottle = Instantiate(prefab, position, rotation);
            Rigidbody bottleRigidbody = bottle.GetComponent<Rigidbody>();

            float force = Random.Range(minForce, maxForce);
            bottleRigidbody.AddForce(bottle.transform.up * force, ForceMode.Impulse);

            float rotationalForce = Random.Range(100f, 300f);
            bottleRigidbody.AddTorque(bottle.transform.right * rotationalForce, ForceMode.Impulse);


            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
