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
        p_Stats.maxHealth += 3;
        p_Stats.currentHealth += 1;
        p_Stats.attackSpeed += 0.5f;
        p_Stats.DamageMultiplayer += 2;
        p_Stats.CritMultiplayer += 2;
        p_Stats.critChance += 5;
        p_Stats.blockChance += 5;
        p_Stats.moveSpeed += 0.5f;
        p_Stats.passivelifeRegen += 1;
    }
}
