using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkullMovement : EnemyMovement
{
    
    private void Start()
    {
        AssignVariables();
        StartCoroutine(MoveSkull());
        damage = 5;
    }
    IEnumerator MoveSkull()
    {
        yield return new WaitForSeconds(0.5f);
        SkullTarget();
    }

    void SkullTarget()
    {
        agent.destination = target.transform.position;
        StartCoroutine(MoveSkull());
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && attackAvailable)
        {
            StartCoroutine(target.GetComponent<HealthSystem>().TakeDamagePlayer(damage));
            attackAvailable = false;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        attackAvailable = true;
    }
}
