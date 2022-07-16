using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Vector2 spawnPosition;
        public float spawnRadius = 5f;
        public int enemyCount;
        public float rate;
    }
    public float timeBetweenWaves = 4f;
    public int enemiesPerWave;

    public GameObject[] enemyPrefabs;

    private GameObject[] enemies;
    
    public static EnemyManager Instance;
    public static GameObject Manager;
    
    // Start is called before the first frame update
    void Awake() {
        print("GameManager Awake");
        Manager = GameObject.Find("GameManager");
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Manager);
    }

    public void StartWave()
    {
        
    }
    
    public void SpawnEnemies()
    {
        // Sample from enemy array
        // Instantiate enemies in a random location inside spawn sphere
        
    }
    
}
