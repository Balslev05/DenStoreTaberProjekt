using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Chest : MonoBehaviour
{
    public int BasePrise;
    [Header("Rarity Change")]
    public int CommenChange;
    public int RareChange;
    public int LegendaryChange;
    [Header("Animation")]
    public GameObject TopChest;
    public Vector3 rotation = new Vector3(-90,0,0);
    
    ItemManager item_Manager;
    void Start()
    {
        item_Manager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
       
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenChest();
        }
    }

    // Update is called once per frame
    public void OpenChest()
    {
        TopChest.transform.DOLocalRotate(rotation, 1f).SetEase(Ease.Linear);
        for (int i = 0; i < 3; i++)
        {
            GetRarity();
        }
    }

    public void GetRarity()
    {
        int procentage = Random.Range(1, 101);
        string Rarity = WhatRarity(procentage);

        switch(Rarity)
        {
            case "Commen":
                Debug.Log("You got a commen item" + procentage);
                break;
            case "Rare":
                Debug.Log("You got a rare item" + procentage);
                break;
            case "Legendary":
                Debug.Log("You got a legendary item" + procentage);
                break;
            case "Null":
                Debug.Log("There was a error" + procentage);
                break;
        }
    }
    public string WhatRarity(int Procentage)
    {
        if(Procentage > LegendaryChange)
        {
            return "Legendary";
        }
        if(Procentage > RareChange)
        {
            return "Rare";
        }
        if(Procentage > CommenChange)
        {
            return "Commen";
        }
        return null;
    }

}