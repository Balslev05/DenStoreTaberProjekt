using AYellowpaper.SerializedCollections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public abstract class ItemBehavior : MonoBehaviour
{
    //[Header("Inheritance Stats (NoNeedToAssign)")]
    [HideInInspector] public PlayerStats p_Stats;
    private GameObject Item_model;
    private GameObject i2;
    
    [Header("InUI(NeedsToBeAssigned)")]
    public Sprite TwoDSprite;
    public string ItemName;
    public string ItemDescription;
    public bool CanBePickedUp = true;
    
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
        Debug.Log("InstatiateOnModelAndUI");
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
        
        Debug.Log("Looking for " + name );
        foreach (GameObject item in p_Stats.ItemsOnBody)
        {
            Debug.Log("Found" + item.name  );
            if (item.gameObject.name == name)
            {
                Debug.Log("Found" + name);
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
        if (other.gameObject.tag == "Player" && CanBePickedUp)
        {
            ChangeStats(p_Stats);
            PickUp();
            Destroy(gameObject);
        }
    }
}
