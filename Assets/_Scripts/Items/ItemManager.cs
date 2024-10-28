using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    
    public List<GameObject> Commen_Items = new List<GameObject>();
   
    public List<GameObject> Rare_Items = new List<GameObject>();
    
    public List<GameObject> Legendary_Items = new List<GameObject>();


    public GameObject GetRandomItem()
    {
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            return Commen_Items[Random.Range(0, Commen_Items.Count)];
        }
        else if (random == 1)
        {
            return Rare_Items[Random.Range(0, Rare_Items.Count)];
        }
        else
        {
            return Legendary_Items[Random.Range(0, Legendary_Items.Count)];
        }
    }
}
