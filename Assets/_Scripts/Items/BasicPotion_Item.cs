using UnityEngine;

public class BasicPotion_Item : ItemBehavior
{
    [Header("PotionStats")]
    public int lifeRegen;
    public float moveSpeed;
    public float attackSpeed;
    public int blockChange;
    void Start()
    {
        FindObjectNeeded();   
    }

    public override void ChangeStats(PlayerStats playerStats)
    {
        p_Stats.passivelifeRegen += lifeRegen;
        p_Stats.moveSpeed += moveSpeed;
        p_Stats.attackSpeed += attackSpeed;
        p_Stats.blockChance += blockChange;
    }
}
