using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float lifetime;


    private void Start()
    {
        StartCoroutine(DeadthDelay());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<EnemyRCDM>() != null)
            {
                collision.GetComponent<EnemyRCDM>().DealDamage(damage);
            }
            Destroy(gameObject);
            if (collision.GetComponent<PlanetRCDM>() != null)
            {
                collision.GetComponent<PlanetRCDM>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    IEnumerator DeadthDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
