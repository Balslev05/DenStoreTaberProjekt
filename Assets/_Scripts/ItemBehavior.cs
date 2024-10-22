using UnityEngine;

public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats")]
    public PlayerStats P_Stats;
    public string ItemDescription;
    public GameObject Item_model;
    [Header("viewOnModel")]
    public Vector3 pos;
    public Vector3 rotation;
    public Vector3 scale = new Vector3(1, 1, 1);

    public virtual void FindObjectNeeded()
    {
        P_Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Item_model = transform.GetChild(0).gameObject;
    }
    public virtual void InstatiateOnModel()
    {
        GameObject i = Instantiate(Item_model, P_Stats.gameObject.transform);
        i.transform.localPosition = pos;
        i.transform.localRotation = Quaternion.Euler(rotation);
        i.transform.localScale = scale;
    }
    public abstract void ChangeStats(PlayerStats playerStats);
    public abstract void WriteDescreption();
    public virtual void PickUp()
    {
        InstatiateOnModel();
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
