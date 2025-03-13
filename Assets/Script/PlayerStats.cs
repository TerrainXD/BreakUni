using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    private GameManager gameManager;
    public static PlayerStats playerStats;
    public Image[] hpImage;
    private AudioSource audiosr;

    [SerializeField]
    private AudioClip audioClip;

    public int curHealth;
    public int maxHealth = 10;

    void Start()
    {
        curHealth = maxHealth;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audiosr = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            gameManager.GameOver();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            curHealth--;
            hpImage[curHealth - 0].enabled = false;
            gameObject.GetComponent<Animation>().Play("Red");
            audiosr.PlayOneShot(audioClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            curHealth--;
            hpImage[curHealth - 0].enabled = false;
            gameObject.GetComponent<Animation>().Play("Red");
            audiosr.PlayOneShot(audioClip);
        }
    }
}
