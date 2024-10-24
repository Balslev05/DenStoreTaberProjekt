using UnityEngine;
public class Hat_Item : ItemBehavior
{
    [Header("Stat change")]
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
}
