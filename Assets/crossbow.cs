using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject arrow;
    public List<GameObject> Enemies = new List<GameObject>();
    [Header("BaseStats")] 
    public float b_AttackSpeed;
    public int b_Damage;
    public float b_Reloade;
    private bool canShoot = true;
    
    void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }
    
    void Update()
    {
        if (canShoot)
        {
            Transform closestEnemy = FindClosesEnemy();
            if (closestEnemy != null)
            {
                StartCoroutine(ShootAtEnemy(closestEnemy));
            }
        }
    }

    public Transform FindClosesEnemy()
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        if (Enemies.Count == 0)
        {return null; }

        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

    private IEnumerator ShootAtEnemy(Transform target)
    {
        canShoot = false;
        GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
        newArrow.transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        newArrow.transform.DOLookAt(target.position, 2, AxisConstraint.Y);
        newArrow.AddComponent<Rigidbody>();
        newArrow.GetComponent<Rigidbody>().linearVelocity = (target.position - transform.position).normalized * b_AttackSpeed;
        newArrow.GetComponent<Projectile>().damage = playerStats.calculateDamage(b_Damage);
        yield return new WaitForSeconds(b_Reloade);
        canShoot = true;
        Destroy(newArrow, 1f);
    }
}
