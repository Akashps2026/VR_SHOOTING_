// GameManager.cs
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Start() => UpdateUI();

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
