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
        
    }

    private void Update()
    {
        StartCoroutine(MoveSkull());
    }

    IEnumerator MoveSkull()
    {
        _skull.destination = target.transform.position;
        yield return new WaitForSeconds(0.5f);
    }
}
