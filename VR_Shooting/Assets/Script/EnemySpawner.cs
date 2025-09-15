using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   
    public Transform spawnPoint;     
    public float spawnInterval = 2f; 
    public int maxEnemies = 1;      

    private int enemyCount = 0;

    void Start()
    {
       
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyCount >= maxEnemies) return;

       
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyCount++;
    }
}
