using UnityEngine;

public class Item_Weapon : ItemBehavior
{
    void Start()
    {  
        FindObjectNeeded();
    }

    // Update is called once per frame
    public override void ChangeStats(PlayerStats playerStats)
    {
        Debug.Log("Gets a weapon:" + name);
    }
}
