using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawAI : MonoBehaviour
{
    public GameObject[] aiPrefab; 
    public Vector2 spawnArea; // Khu vực xuất hiện trên trục X và Y
    public float TimeSpawn;

    private void Start()
    {
        StartRepeatingSpawnAI();
    }
    public void StartRepeatingSpawnAI()
    {
        InvokeRepeating("SpawnAI",0f , TimeSpawn);
    }

    void SpawnAI()
    {
        float randomX = Random.Range(spawnArea.x, spawnArea.y); // Tạo vị trí X ngẫu nhiên
        float randomY = Random.Range(spawnArea.x, spawnArea.y); // Tạo vị trí Y ngẫu nhiên
        int randSpawPoint = Random.Range(0,aiPrefab.Length);

        Vector2 spawnPosition = new Vector2(randomX, randomY); 

        Instantiate(aiPrefab[randSpawPoint], spawnPosition, Quaternion.identity); // Tạo đối tượng AI tại vị trí ngẫu nhiên
    }


}
