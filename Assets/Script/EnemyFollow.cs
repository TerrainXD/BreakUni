using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    public float lineOfSite;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float leftside = -42f;
    private float rightside = 52f;
    private float yRange = 31f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (transform.position.x < leftside)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > rightside)
        {
            Destroy(gameObject);
        }


        if (transform.position.y > yRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -yRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
