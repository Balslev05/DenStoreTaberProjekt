using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;
public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats(NoNeedToAssign)")]
    public PlayerStats P_Stats;
    public GameObject Item_model;
    [Header("viewOnModel(NeedsToBeAssigned)")]
    public Vector3 pos;
    public Vector3 rotation;
    public Vector3 scale = new Vector3(1, 1, 1);
    [Header("InUI(NeedsToBeAssigned)")]
    public Sprite TwoDSprite;
    public string ItemName;
    public string ItemDescription;
    
    
    public abstract void ChangeStats(PlayerStats playerStats);
    public virtual void PickUp()
    {
        Debug.Log("Item picked up" + gameObject.name);
        InstatiateOnModelAndUI();
    }
    public void FindObjectNeeded()
    {
        P_Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Item_model = transform.GetChild(0).gameObject;
    }
    public void InstatiateOnModelAndUI()
    {
        // SHOW ON MODEL 
        GameObject i = Instantiate(Item_model, P_Stats.gameObject.transform);
        i.transform.localPosition = pos;
        i.transform.localRotation = Quaternion.Euler(rotation);
        i.transform.localScale = scale;
        GameObject i2 = GameObject.Find(ItemName);
        
        if (!CheckDuplicate(ItemName))
        {
            i2 = Instantiate(P_Stats.IconPrefab,P_Stats.inventoryHolder.gameObject.transform);
            i2.name = ItemName;
            i2.GetComponent<Image>().sprite = TwoDSprite;
            P_Stats.items.Add(i2.name,0);
            i2.GetComponent<Icon>().Descreption = ItemDescription;
        }

        if (CheckDuplicate(ItemName))
        {   
            P_Stats.items[ItemName]++;
            i2.transform.GetChild(0).GetComponent<TMP_Text>().text = P_Stats.items[i2.name].ToString();
        } 
            
    }
    public bool CheckDuplicate(string name)
    {
        foreach (string ItemList in P_Stats.items.Keys)
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
           
            ChangeStats(P_Stats);
            PickUp();
            Destroy(gameObject);
        }
    }
}
