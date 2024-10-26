using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkullMovement : MonoBehaviour
{
    private NavMeshAgent _skull;
    public GameObject target;
    private void Start()
    {
        _skull = GetComponent<NavMeshAgent>();
        
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveSkull());
        
    }
    

    IEnumerator MoveSkull()
    {
        yield return new WaitForSeconds(0.5f);
        SkullTarget();
    }

    void SkullTarget()
    {
        _skull.destination = target.transform.position;
        StartCoroutine(MoveSkull());
    }
}
