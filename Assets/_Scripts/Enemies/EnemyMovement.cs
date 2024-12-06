using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    
    public float damage = 2;
    

    public void AssignVariables()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
