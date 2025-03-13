using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRCDM : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public float health;
    public float maxHealth;

    public GameObject effect;
    private AudioSource audiosr;

    [SerializeField] private AudioClip audioClip;

    public void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audiosr = GetComponent<AudioSource>();
    }
    public void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            audiosr.PlayOneShot(audioClip);
            particle.Play();
            sr.enabled = false;
            bc.enabled = false;
            Destroy(this.gameObject, 0.3f);
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
