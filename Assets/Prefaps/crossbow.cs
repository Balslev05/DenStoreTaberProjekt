using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class crossbow : ItemBehavior
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
    }
    
    void Update()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
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
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy.transform;
                }
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
        ;
        newArrow.GetComponent<Projectile>().damage = playerStats.calculateDamage(b_Damage);
        // does this to find the diffrence in damage to see if they have changed
        if (b_Damage * playerStats.DamageMultiplayer != newArrow.GetComponent<Projectile>().damage)
        {
            newArrow.GetComponent<Projectile>().crit = true;
        }
        yield return new WaitForSeconds(b_Reloade);
        canShoot = true;
        Destroy(newArrow, 1f);
    }

    public override void ChangeStats(PlayerStats playerStats)
    {
        p_Stats.attackSpeed++;
    }
}
