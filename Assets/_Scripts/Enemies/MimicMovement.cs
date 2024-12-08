using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class MimicMovement : EnemyMovement
{
    private void Start()
    {
        AssignVariables();
        StartCoroutine(MoveMimic());
    }
    IEnumerator MoveMimic()
    {
        yield return new WaitForSeconds(0.5f);
        MimicTarget();
    }

    void MimicTarget()
    {
        agent.destination = target.transform.position;
        StartCoroutine(MoveMimic());
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
