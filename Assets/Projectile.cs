using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<EnemyStats>().TakeDamage((damage));
        }
    }
}
