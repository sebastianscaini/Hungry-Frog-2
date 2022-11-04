using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject fly;
    public float minTime, maxTime;
    public Vector3 minForce, maxForce;

    private Manager mg;

    private void Awake()
    {
        mg = FindObjectOfType<Manager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnFly());
    }

    private IEnumerator SpawnFly()
    {
        while(mg.currentHunger > 0f)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            GameObject instFly = Instantiate(fly);
            instFly.transform.position = transform.position;

            instFly.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y), 0f), ForceMode2D.Impulse);
        }
    }
}
