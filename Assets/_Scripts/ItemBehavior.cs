using UnityEngine;

public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats")]
    public PlayerStats P_Stats;
    public string ItemDescription;

    public virtual void FindPlayerStats()
    {
        P_Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    public virtual void InstatiateOnModel(GameObject item,Vector3 pos)
    {
        GameObject i = Instantiate(item, P_Stats.gameObject.transform);
        i.transform.localPosition = pos;
    }
    public abstract void ChangeStats(PlayerStats playerStats);
    public abstract void WriteDescreption();
}
