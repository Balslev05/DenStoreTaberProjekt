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
        P_Stats.passivelifeRegen += lifeRegen;
        P_Stats.moveSpeed += moveSpeed;
        P_Stats.attackSpeed += attackSpeed;
        P_Stats.blockChance += blockChange;
    }
}
