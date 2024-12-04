using System.ComponentModel;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Axe_item : ItemBehavior
{   
    [Header("ScriptStats")]
    public float damageProcentBuff = 25;
    public float ActualValue;

    void Start()
    {
        FindObjectNeeded();
        ActualValue = (damageProcentBuff*0.01f) + 1;
    }
    public override void ChangeStats(PlayerStats playerStats)
    {
        playerStats.DamageMultiplayer *= ActualValue;
    }
}
