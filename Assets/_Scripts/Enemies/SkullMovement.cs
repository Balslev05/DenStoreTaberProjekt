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
        damage = 2;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(target.GetComponent<HealthSystem>().TakeDamage(damage, false));
        }
    }

    private void OnColisionExit(Collision other)
    {
        
    }
}
