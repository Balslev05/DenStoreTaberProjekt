using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    public int passivelifeRegen = 0;
    public int currentHealth;
    public float attackSpeed = 3;
    public float moveSpeed = 5;
    public float attackDamage = 10;
    public float critChance = 10;
    public float critDamage = 2;
    public float blockChance = 0;
    
   public virtual void TakeDamage()
   {
     
   }

   private int calculateDamage()
   {
       return 0;
   }
}
