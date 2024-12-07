using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public bool crit;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            StartCoroutine(other.GetComponent<EnemyStats>().TakeDamage(damage,crit));
        }
    }
}
