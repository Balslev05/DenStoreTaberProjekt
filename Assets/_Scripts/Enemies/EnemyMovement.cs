using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    

    public void AssignVariables()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
