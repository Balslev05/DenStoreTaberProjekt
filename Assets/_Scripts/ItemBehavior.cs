using UnityEngine;

public abstract class ItemBehavior : MonoBehaviour
{
    [Header("Inheritance Stats")]
    public PlayerStats P_Stats;
    public string ItemDescription;
    public PlayerStats FindPlayerStats()
    {
        Debug.Log("Find Player Stats" + this.gameObject.name + "-" + P_Stats);
        return GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    public abstract void InstatiateOnModel(Vector3 pos);
    public abstract void ChangeStats(PlayerStats playerStats);
    public abstract void WriteDescreption();
}
