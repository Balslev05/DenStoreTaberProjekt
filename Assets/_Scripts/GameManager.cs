using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    void Awake()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }

    
}
