using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : HealthSystem
{
    [Header("Items")]
    [SerializedDictionary("Items", "Amount")]
    public SerializedDictionary<string, int> items = new SerializedDictionary<string, int>();
    public GameObject[] ItemsOnBody;
    [Header("UI-Elementer")]
    public GameObject IconPrefab;
    public GameObject inventory_UI;
    public Transform inventoryHolder;
    [Header("UI-Animations")] 
    public float timer;
    public KeyCode inventoryKey;
    public Tween currentTween;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void UpdateUI()
    {
        foreach (string item in items.Keys)
        {
            inventoryHolder.Find(item).GetChild(0).GetComponent<TMP_Text>().text = items[item].ToString();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            currentTween.Kill();
            currentTween = inventory_UI.transform.DOScale(new Vector3(1, 1, 1),timer);
        }
        
        if (Input.GetKeyUp(inventoryKey))
        {
            currentTween.Kill();
            currentTween = inventory_UI.transform.DOScale(new Vector3(0, 0, 0),timer);
        }
    }
}
