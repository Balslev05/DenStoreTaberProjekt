using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    private int currentHealth;
    public float attackSpeed = 3;
    public float attackDamage = 10;
    public float critChance = 10;
    public float critDamage = 2;
    public float blockChance = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
