using UnityEngine;

public class Hat_Item : ItemBehavior
{
    public int HPBoost;
    public void Start()
    {
       FindObjectNeeded();
    }
    public override void ChangeStats(PlayerStats playerStats)
    {
        playerStats.maxHealth += HPBoost;
        playerStats.currentHealth += HPBoost;
    }
    public override void WriteDescreption()
    {
        Debug.Log("Hat gives " + HPBoost + " ExtrA hp to The player");

    }
}
