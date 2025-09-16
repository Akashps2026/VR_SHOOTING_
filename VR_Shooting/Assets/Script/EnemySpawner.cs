using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isGameOver = false;


    private IEnumerator EnemySpawnCoroutine()
    {
        while (!isGameOver)
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void SpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }
}
