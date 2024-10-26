using UnityEngine;
using UnityEngine.UI;

public class DoubelAxe_Item : ItemBehavior
{
    void Start()
    { 
        FindObjectNeeded();
    }
    public override void ChangeStats(PlayerStats playerStats)
    {
        playerStats.critChance += 10f;
         playerStats.critDamage *= 2;
    }
}
