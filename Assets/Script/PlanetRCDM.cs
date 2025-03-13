using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRCDM : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private CircleCollider2D cd;
    public GameObject effect;
    public float health;
    public float maxHealth;

    private AudioSource audiosr;

    [SerializeField] private AudioClip audioClip;
   
    public void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        cd = GetComponent<CircleCollider2D>();
        audiosr = GetComponent<AudioSource>();
    }
    public void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            audiosr.Play();
            particle.Play();

            sr.enabled = false;
            cd.enabled = false;
            Destroy(this.gameObject, 1);
        }
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
      
    }

}
