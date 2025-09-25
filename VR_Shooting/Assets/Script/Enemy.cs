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
    public int scoreValue = 10;
    public GameManager gameManager;
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
        
         // hide at start
        //killManager = FindObjectOfType<EnemyKillManager>();

    }
    private void Update()
    {
        navMeshAgent.destination = player.transform.position;
    }
   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameManager.AddScore(scoreValue);
            gameManager.AddKill();
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
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
