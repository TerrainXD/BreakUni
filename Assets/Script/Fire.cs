using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    private AudioSource shootSound;

    [SerializeField]
    private AudioClip shoot;

    public GameObject bulletPrefabs;
    public float bulletForce = 10f;
    public float damage;

    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            shootSound.PlayOneShot(shoot);
        }
    }



    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
