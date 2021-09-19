using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] Transform spawnPointOne, spawnPointTwo;
    [SerializeField] GameObject[] enemy;
    private GameObject enemyStatic;
    private float randomEnemy, timeSpawn;
    private int countSpawnEnemy;
    void Start()
    {
        Invoke("Spawn",2f);
        // StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        if(GameManager.countWave == 0)
        {
            Invoke("PlusCountWave",0);
        }
    }
    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i <= countSpawnEnemy; i++)
        {
            if(GameManager.isGame == true)
            {
                yield return new WaitForSeconds(timeSpawn);
                enemyStatic = enemy[Random.Range(0, enemy.Length)];
                float random = Random.Range(spawnPointOne.position.x,spawnPointTwo.position.x);
                Instantiate(enemyStatic, new Vector2(random,spawnPointTwo.position.y), Quaternion.identity);
            }
            if(countSpawnEnemy == i)
            {
                Invoke("PlusCountWave",0);
                // StartCoroutine(SpawnEnemy());
                Invoke("Spawn",4f);
            }
        }
    }
    void PlusCountWave()
    {
        GameManager.countWave++;
        GameManager.isAnim = true;
    }
    void Spawn()
    {
        if(GameManager.countWave == 1)
        {
            timeSpawn = Random.Range(1f, 1.5f);
            countSpawnEnemy = Random.Range(9, 15);
        }
        if(GameManager.countWave == 2)
        {
            timeSpawn = Random.Range(0.7f, 1.1f);
            countSpawnEnemy = Random.Range(12, 17);
        }
        if(GameManager.countWave == 3)
        {
            timeSpawn = Random.Range(0.3f, 0.7f);
            countSpawnEnemy = Random.Range(23, 30);
        }
        if(GameManager.countWave == 4)
        {
            timeSpawn = Random.Range(0.1f, 0.5f);
            countSpawnEnemy = Random.Range(35, 45);
        }
        if(GameManager.countWave == 5)
        {
            timeSpawn = Random.Range(0.1f, 0.4f);
            countSpawnEnemy = Random.Range(55, 70);
        }
        if(GameManager.countWave == 6)
        {
            timeSpawn = Random.Range(0.1f, 0.4f);
            countSpawnEnemy = Random.Range(75, 100);
        }
        if(GameManager.countWave > 6)
        {
            timeSpawn = Random.Range(0.05f, 0.2f);
            countSpawnEnemy = Random.Range(70, 150);
        }
        StartCoroutine(SpawnEnemy());
    }
}
