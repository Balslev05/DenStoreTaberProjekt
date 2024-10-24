using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats")]
    public type rareity;
    public PlayerStats P_Stats;
    public GameObject Item_model;
    [Header("viewOnModel")]
    public Vector3 pos;
    public Vector3 rotation;
    public Vector3 scale = new Vector3(1, 1, 1);
    [Header("InUI")]
    public Sprite TwoDSprite;
    public string ItemName;
    public string ItemDescription;


    public enum type
    {
        legendary, // color red
        rare, // color blue
        common // color grey
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
            P_Stats.items.Add(i2.name,1);
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

    public abstract void ChangeStats(PlayerStats playerStats);
    public abstract void WriteDescreption();
    public virtual void PickUp()
    {
      
        InstatiateOnModelAndUI();
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Item picked up");
            ChangeStats(P_Stats);
            WriteDescreption();
            PickUp();
            Destroy(gameObject);
        }
    }
}
