using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public int enemyCount;
    public float duration;
    private Vector3[] spawnPositions = new Vector3[4];
    public float spawnRadius;
    private Timer spawnTimer;

    void Start()
    {
        spawnEnemy();
        // start timer spawn normal enemy
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = duration;
        spawnTimer.Run();
    }
    private void Update()
    {
        if (spawnTimer.Finished)
        {
            spawnEnemy();
            spawnTimer.Duration = duration;
            spawnTimer.Run();
        }
    }

    void spawnEnemy()
    {
        // Lấy vị trí 4 cạnh của main camera
        spawnPositions[0] = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        spawnPositions[1] = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        spawnPositions[2] = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        spawnPositions[3] = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        // Sinh ra các enermy
        for (int i = 0; i < enemyCount; i++)
        {
            int spawnObjcetId = Random.Range(0, enemyPrefab.Length);
            int spawnIndex = Random.Range(0, 4);
            Vector3 spawnPos = spawnPositions[spawnIndex] + (Random.insideUnitSphere * spawnRadius);

            spawnPos.z = 0;
            GameObject enemy = Instantiate(enemyPrefab[spawnObjcetId], spawnPos, Quaternion.identity);
            enemy.GetComponent<EnemyMove>().target = GameObject.FindGameObjectWithTag("Player2").transform;
        }
    }
}
