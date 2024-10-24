using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    public int currentHealth;
    public float attackSpeed = 3;
    public float attackDamage = 10;
    public float critChance = 10;
    public float critDamage = 2;
    public float blockChance = 0;
    [Header("Items")]
    [SerializedDictionary("Items", "Amount")]
    public SerializedDictionary<string, int> items = new SerializedDictionary<string, int>();
    [Header("UI-Elementer")]
    public GameObject IconPrefab;
    public GameObject inventory_UI;
    public GameObject inventoryHolder;
    public GameObject LastAddedIcon;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
}
