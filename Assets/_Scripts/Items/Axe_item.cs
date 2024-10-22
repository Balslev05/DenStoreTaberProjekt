using System.ComponentModel;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Axe_item : ItemBehavior
{   
    [Header("Axe gives %damage to the baseStats of the player")]
    public GameObject Item_axe;
    public Vector3 PlaceOnModel;
    public float damageProcentBuff = 25;
    public float ActualValue;

    void Start()
    {
        FindPlayerStats();
        ActualValue = damageProcentBuff*0.01f;
    }
    public void PickUp()
    {
        InstatiateOnModel(Item_axe,PlaceOnModel);
    }
    public override void ChangeStats(PlayerStats playerStats)
    {
        playerStats.attackDamage += ActualValue;
    }

    public override void WriteDescreption()
    {

    }
}
