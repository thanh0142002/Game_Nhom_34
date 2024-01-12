using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawAI : MonoBehaviour
{
    public GameObject[] aiPrefab; 
    public Vector2 spawnArea; // Khu vực xuất hiện trên trục X và Y
    public float TimeSpawn;

    //sinh boss
    public GameObject[] aiPrefabBoss;
    public Vector2 spawnAreaBoss; // Khu vực xuất hiện trên trục X và Y
    public float TimeSpawnBoss;

    private void Start()
    {
        StartRepeatingSpawnAI();
        StartRepeatingSpawnAIBoss();
    }
    public void StartRepeatingSpawnAI()
    {
        InvokeRepeating("SpawnAI",3f , TimeSpawn);
        Invoke("StopRepeatingSpawnAI", 60f);
    }
    public void StopRepeatingSpawnAI()
    {
        // Hủy lặp lại SpawnAI.
        CancelInvoke("SpawnAI");
    }

    void SpawnAI()
    {
        float randomX = Random.Range(spawnArea.x, spawnArea.y); // Tạo vị trí X ngẫu nhiên
        float randomY = Random.Range(spawnArea.x, spawnArea.y); // Tạo vị trí Y ngẫu nhiên
        int randSpawPoint = Random.Range(0,aiPrefab.Length);

        Vector2 spawnPosition = new Vector2(randomX, randomY); 

        Instantiate(aiPrefab[randSpawPoint], spawnPosition, Quaternion.identity); // Tạo đối tượng AI tại vị trí ngẫu nhiên
    }


    //boss
    public void StartRepeatingSpawnAIBoss()
    {
        Invoke("SpawnAIBoss", TimeSpawnBoss);
    }

    void SpawnAIBoss()
    {
        float randomX = Random.Range(spawnAreaBoss.x, spawnAreaBoss.y); // Tạo vị trí X ngẫu nhiên
        float randomY = Random.Range(spawnAreaBoss.x, spawnAreaBoss.y); // Tạo vị trí Y ngẫu nhiên
        int randSpawPoint = Random.Range(0, aiPrefabBoss.Length);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(aiPrefabBoss[randSpawPoint], spawnPosition, Quaternion.identity); // Tạo đối tượng AI tại vị trí ngẫu nhiên
    }

}
