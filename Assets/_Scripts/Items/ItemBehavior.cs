using AYellowpaper.SerializedCollections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats (NoNeedToAssign)")]
    public PlayerStats p_Stats;
    public GameObject Item_model;
    [Header("viewOnModel (NeedsToBeAssigned)")]
    public Vector3 pos;
    public Vector3 rotation;
    public Vector3 scale = new Vector3(1, 1, 1);
   
    [Header("InUI(NeedsToBeAssigned)")]
    public Sprite TwoDSprite;
    public string ItemName;
    public string ItemDescription;
    GameObject i2;
    public abstract void ChangeStats(PlayerStats playerStats);
    public virtual void PickUp()
    {
        InstatiateOnModelAndUI();
    }
    public void FindObjectNeeded()
    {
        p_Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Item_model = transform.GetChild(0).gameObject;
    }
    public void InstatiateOnModelAndUI()
    {
            // SHOW ON MODEL 
            FindObject(ItemName);
            //Instantiate(Item_model, p_Stats.gameObject.transform);
            
        
        if (!CheckDuplicate(ItemName)) // is on UI
        {
            i2 = Instantiate(p_Stats.IconPrefab, p_Stats.inventoryHolder);
            i2.name = ItemName;
            i2.GetComponent<Image>().sprite = TwoDSprite;
            p_Stats.items.Add(i2.name,0);
            i2.GetComponent<Icon>().Descreption = ItemDescription;
        }

        if (CheckDuplicate(ItemName))
        {   
            p_Stats.items[ItemName]++;
            p_Stats.UpdateUI();
        }
    }

    public void FindObject(string name)
    {
        foreach (GameObject item in p_Stats.ItemsOnBody)
        {
            if (item.gameObject.name == name)
            {
                item.SetActive(true);
            }
        }
    }
    
    public bool CheckDuplicate(string name)
    {
        foreach (string ItemList in p_Stats.items.Keys)
        {
            if (name == ItemList)
                return true;
        }
        return false;   
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeStats(p_Stats);
            PickUp();
            Destroy(gameObject);
        }
    }
}
