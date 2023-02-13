using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public int enemyCount;

    private Vector3[] spawnPositions = new Vector3[4];
    public float spawnRadius;

    void Start()
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
            Vector3 spawnPos = spawnPositions[spawnIndex] + (Random.insideUnitSphere * spawnRadius) ;
            Debug.Log(spawnPos + "");
            spawnPos.z = 0;
            GameObject enemy = Instantiate(enemyPrefab[spawnObjcetId], spawnPos, Quaternion.identity);
            enemy.GetComponent<EnemyMove>().target = GameObject.FindGameObjectWithTag("Player2").transform;
        }
    }
}
