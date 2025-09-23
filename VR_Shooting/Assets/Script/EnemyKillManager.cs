using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Use TextMeshPro (recommended)

public class EnemyKillManager : MonoBehaviour
{
    public GameObject winPanel;            // Assign in Inspector
    public TextMeshProUGUI killText;       // Assign UI text in Inspector
    public int killTarget = 15;            // Target kills to win

    private int currentKills = 0;

    void Start()
    {
        UpdateKillUI();
        if (winPanel != null) winPanel.SetActive(false); // hide at start
    }

    // Call this when an enemy dies
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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
