using UnityEngine;

public class BasicPotion_Item : ItemBehavior
{
    [Header("PotionStats")]
    public int lifeRegen;
    public float moveSpeed;
    public float attackSpeed;
    public int critchange;
    public bool IsDash = false;
    void Start()
    {
        FindObjectNeeded();   
    }

    public override void ChangeStats(PlayerStats playerStats)
    {
        if (IsDash)
        {
            p_Stats.dashes++;
            return;
        }
        p_Stats.moveSpeed += moveSpeed;
        p_Stats.attackSpeed = p_Stats.attackSpeed* 0.75f;
        p_Stats.critChance += critchange;
    }
}
