using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Waves : MonoBehaviour
{
    public int wave = 1;
    [SerializeField] private int[] spawns = {0,3,4,5,6,7,8,9,10,11};

    public int enemy1Unlock = 0;
    /*public int enemy2Unlock = 3;
    public int enemy3Unlock = 6;*/
    
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] public  List<GameObject> _enemies = new List<GameObject>();

    public GameObject enemy1;

    void Start()
    {
        GameObject[] tempSpawnPoints;
        tempSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject Spawnpoint in tempSpawnPoints)
        {
            _spawnPoints.Add(Spawnpoint);
        }
        WaveCalling();
    }

    private void Update()
    {
        if (_enemies.Count == 0)
        {
            wave++;
            WaveCalling();
        }
    }

    void WaveCalling()
    {
        for (int i = 0; i < spawns[wave]; i++)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Count)].GetComponent<EnemySpawn>().SpawnEnemy(enemy1);
        }
        gameObject.GetComponent<ChestSpawning>().SpawnChest();
    }
}
