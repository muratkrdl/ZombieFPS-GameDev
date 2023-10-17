using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image gameOver;
    [SerializeField] TextMeshProUGUI gameOverWave;

    [SerializeField] TextMeshProUGUI inGameWave;

    [SerializeField] GameObject zombiePrefab;

    public int enemiesAlive = 0;
    [SerializeField] int round = 0;

    [SerializeField] GameObject[] spawnPoints;

    void Start()
    {
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
        }
    }

    public void NextWave(int round)
    {
        inGameWave.text = "Wave " + round.ToString();
        for (int i = 0; i < round; i++)
        {
            GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            var enemy = Instantiate(zombiePrefab, spawnpoint.transform.position, Quaternion.identity);

            enemy.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
    }

    public void ShowGameOver()
    {
        Cursor.lockState = CursorLockMode.None;

        inGameWave.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);

        gameOverWave.text = round.ToString();
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quitttt");

        //Application.Quit();
    }

    public void Play()
    {
        
    }

}
