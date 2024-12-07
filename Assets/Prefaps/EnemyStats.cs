using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyStats : HealthSystem
{
    public GameObject coinsPrefab;
    public int lootforce;
    public int minCoins = 3;
    public int maxCoins = 7;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            //give cards
            SpawnLoot();
            Destroy(gameObject);
        }
    }
    public void SpawnLoot()
    {
        int lootCount = Random.Range(minCoins, maxCoins);
        for (int i = 0; i < lootCount; i++)
        {
            GameObject coin = Instantiate(coinsPrefab, transform.position, Quaternion.identity);
            var vector3 = coin.transform.position;
            vector3.x = Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f);
            vector3.z = Random.Range(transform.position.z - 1f, transform.position.z + 1f);
            coin.transform.position = vector3;
            Rigidbody rb = coin.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDirection = Random.insideUnitSphere;
                rb.AddForce(randomDirection * lootforce, ForceMode.Impulse);
            }
        }
    }
}
