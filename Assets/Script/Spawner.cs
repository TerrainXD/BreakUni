using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform player;
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;

    public float lineOfSite;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    IEnumerator Spawn()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            yield return new WaitForSeconds(0);

            if (timeBtwSpawns <= 0)
            {
                rand = Random.Range(0, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
       
    }
}
