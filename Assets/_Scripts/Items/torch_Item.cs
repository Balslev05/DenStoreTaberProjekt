using UnityEngine;

public class torch_Item : ItemBehavior
{
    void Start()
    {
        FindObjectNeeded();
    }

    public override void ChangeStats(PlayerStats playerStats)
    {
        //playerStats.armor *= ActualValue;
    }
}
