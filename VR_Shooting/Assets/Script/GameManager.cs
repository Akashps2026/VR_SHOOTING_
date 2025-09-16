// GameManager.cs
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    [SerializeField] private EnemySpawner enemySpawner;

    void Start()
    {
        UpdateUI();
        enemySpawner.SpawnEnemy();
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
