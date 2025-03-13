using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI thank;
    public Button restartButton;
    public TextMeshProUGUI planetRemaining;
    public TextMeshProUGUI enemyRemaining;


    public int planetCount;
    public int EnemyCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        planetCount = FindObjectsOfType<PlanetRCDM>().Length;
        EnemyCount = FindObjectsOfType<EnemyRCDM>().Length;
        player = GameObject.FindGameObjectWithTag("Player");

        planetRemaining.text = "Planet : " + planetCount.ToString();
        enemyRemaining.text = "Enemy : " + EnemyCount.ToString();

        if(planetCount <= 0 && EnemyCount <= 0)
        {
            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            thank.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
