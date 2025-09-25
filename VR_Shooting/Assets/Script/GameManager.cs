// GameManager.cs
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isGameOver = false;
    public int enemyCount = 0;
    public int enemyMaxCount = 15;
    public int score;
    public Text scoreText;
    public int killTarget = 15;            
    private int currentKills = 0;
    public TextMeshProUGUI killText;
    public GameObject winPanel;
    void Start()
    {
        UpdateUI();
        SpawnEnemy();
        UpdateKillUI();
        if (winPanel != null) winPanel.SetActive(false);
    }
    private IEnumerator EnemySpawnCoroutine()
    {
        while (!isGameOver && enemyCount < enemyMaxCount)
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            enemyCount++;
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void SpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }
    public void AddKill()
    {
        currentKills++;
        UpdateKillUI();

        if (currentKills >= killTarget)
        {
            ShowWinPanel();
        }
    }
    void UpdateKillUI()
    {
        if (killText != null)
            killText.text = "Kills: " + currentKills + " / " + killTarget;
    }
    void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // pause game
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }
}
