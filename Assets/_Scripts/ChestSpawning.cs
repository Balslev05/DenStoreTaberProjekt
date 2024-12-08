using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class ChestSpawning : MonoBehaviour
{
    public List<GameObject> _spawnPoints = new List<GameObject>();
    private List<GameObject> _spawnedPoints = new List<GameObject>();
    public GameObject commonChest;
    public GameObject rareChest;

    private int _numberOfCommonChests = 5;
    private int _numberOfRareChests = 3;
    
    Random random = new Random();

    private void Start()
    {
        GameObject[] tempSpawnPoints;
        tempSpawnPoints = GameObject.FindGameObjectsWithTag("ChestSpawn");
        foreach (GameObject Spawnpoint in tempSpawnPoints)
        {
            _spawnPoints.Add(Spawnpoint);
        }
    }


    public void SpawnChest()
    {
        
        for (int i = 0; i < _numberOfCommonChests; i++)
        {
            if (_spawnedPoints.Count == _spawnPoints.Count)
            {
                break;
            }
            int rnd = PreventChestCollisions();
            _spawnedPoints.Add(_spawnPoints[rnd]);
           GameObject chest = Instantiate(commonChest, _spawnPoints[rnd].transform.position, Quaternion.identity);
           chest.transform.DORotate(new Vector3(0, -90, 0),0);
        }
        for (int i = 0; i < _numberOfRareChests; i++)
        {
            if (_spawnedPoints.Count == _spawnPoints.Count)
            {
                break;
            }
            int rnd = PreventChestCollisions();
            _spawnedPoints.Add(_spawnPoints[rnd]);
            GameObject chest = Instantiate(rareChest, _spawnPoints[rnd].transform.position, Quaternion.identity);
            chest.transform.DORotate(new Vector3(0, -90, 0),0);

        }
    }

    private int PreventChestCollisions()
    {
        int rnd = random.Next(_spawnPoints.Count);
        if (_spawnedPoints.Contains(_spawnPoints[rnd]))
        {
            rnd = PreventChestCollisions();
        }
        return rnd;
    }
}
