using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
public class PlayerStats : HealthSystem
{
    [Header("Items")]
    [SerializedDictionary("Items", "Amount")]
    public SerializedDictionary<string, int> items = new SerializedDictionary<string, int>();
    [Header("UI-Elementer")]
    public GameObject IconPrefab;
    public GameObject inventory_UI;
    public GameObject inventoryHolder;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
}
