using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    
    public List<GameObject> Commen_Items = new List<GameObject>();
   
    public List<GameObject> Rare_Items = new List<GameObject>();
    
    public List<GameObject> Legendary_Items = new List<GameObject>();


    public GameObject GetRandomItem(string rarity)
    {
        switch (rarity)
        {
            case "Commen":
                return Commen_Items[Random.Range(0, Commen_Items.Count)];
            case "Rare":
                return Rare_Items[Random.Range(0, Rare_Items.Count)];
            case "Legendary":
                return Legendary_Items[Random.Range(0, Legendary_Items.Count)];
            default:
                throw new System.ArgumentException("Invalid rarity type");
        }
    }   
    
}
