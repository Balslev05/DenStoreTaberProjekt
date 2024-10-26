using UnityEngine;

public class ColorfulPotion_Item : ItemBehavior
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindObjectNeeded();
    }

    public override void ChangeStats(PlayerStats playerStats)
    {
        P_Stats.maxHealth += 3;
        P_Stats.currentHealth += 1;
        P_Stats.attackSpeed += 0.5f;
        P_Stats.attackDamage += 2;
        P_Stats.critDamage += 2;
        P_Stats.critChance += 5;
        P_Stats.blockChance += 5;
        P_Stats.moveSpeed += 0.5f;
        P_Stats.passivelifeRegen += 1;
    }
}
