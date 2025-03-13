using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFolShootLockPos : MonoBehaviour
{
    private Transform player;

    public float moveSpeed = 5f;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    private AudioSource audiosr;

    [SerializeField]
    private AudioClip audioClip;

    public GameObject bullet;
    public GameObject bulletParent;
    private Rigidbody2D rb;
    private Vector2 movement;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audiosr = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            audiosr.PlayOneShot(audioClip);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}
