using System.Collections;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject player;
    //[SerializeField]private EnemyKillManager killManager;
    public GameObject winPanel;            // Assign in Inspector
    public TextMeshProUGUI killText;       // Assign UI text in Inspector
    public int killTarget = 15;            // Target kills to win
    private int currentKills = 0;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isGameOver = false;
    public int enemyCount = 0;
    public int enemyMaxCount = 15;
    public int scoreValue = 10;
    public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Start()
    {
        if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
        Debug.Log(this.gameObject.name);
        UpdateKillUI();
        if (winPanel != null) winPanel.SetActive(false); // hide at start
        //killManager = FindObjectOfType<EnemyKillManager>();

    }


    private void Update()
    {
        navMeshAgent.destination = player.transform.position;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameManager?.AddScore(scoreValue);
            // play hit FX or animation here
            gameObject.SetActive(false);          // simple "destroy"
            Destroy(other.gameObject);            // remove bullet
        }
    }

    void OnDestroy()
    {
      //  if (killManager != null)
        {
            //killManager.AddKill();
        }
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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
