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
}
