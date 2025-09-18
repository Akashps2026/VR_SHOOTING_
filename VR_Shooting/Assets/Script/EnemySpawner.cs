using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isGameOver = false;
    public int enemyCount= 0;
    public int enemyMaxCount = 15;


    private void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (!isGameOver && enemyCount<enemyMaxCount)
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
}
