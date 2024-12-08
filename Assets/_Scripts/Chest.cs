using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Collections;

public class Chest : MonoBehaviour
{
    public int BasePrise;
    public int InteractionRange = 3;
    [Header("Rarity Change")]
    public int CommenChange;
    public int RareChange;
    public int LegendaryChange;
    [Header("Animation")]
    public GameObject TopChest;
    public Vector3 rotation = new Vector3(-90,0,0);
    [Header("Text")]
    public TextMesh chestText;
    [SerializeField] private bool IsOpen = false;
    private ItemManager item_Manager;
    private GameObject player;
    [Header("Mimic")] 
    [SerializeField] private GameObject mimic;
    public bool IsMimic;
    void Start()
    {
        if (mimic != null)
        {
            IsMimic = ChooseIfMimic();
        }
        item_Manager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
        chestText.text = $"Cost {BasePrise}";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool ChooseIfMimic()
    {
        int Change = Random.Range(1, 5);
        if (Change == 1)
        {
            return true;
        }
        return false;
    }
    
    public void Update()
    {
        if (IsInDistance() && Input.GetKeyDown(KeyCode.Space) && !IsOpen && player.GetComponent<PlayerStats>().gold >= BasePrise) 
            StartCoroutine(OpenChest());
    }

    public bool IsInDistance()
    {
        Vector3 chestScale = chestText.transform.localScale;
        if (Vector3.Distance(player.transform.position, transform.position) < InteractionRange)
        {
            chestText.transform.DOScale(new Vector3(0.1f,0.1f,0.1f),0.5f).SetEase(Ease.OutQuint);
            return true;
        }
        chestText.transform.DOScale(new Vector3(0,0,0),0.5f).SetEase(Ease.OutQuint);
        return false;
    }

    // Update is called once per frame
    public IEnumerator OpenChest()
    {
        if (IsMimic)
        {
            Instantiate(mimic, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        Destroy(chestText.gameObject);
        IsOpen = true;
        TopChest.transform.DOLocalRotate(rotation, 1f).SetEase(Ease.Linear);
        GetRarity();
        GameObject item = Instantiate(item_Manager.GetRandomItem(GetRarity()), transform.GetChild(0).transform);
        item.GetComponent<ItemBehavior>().CanBePickedUp = false;
        player.GetComponent<PlayerStats>().gold -= BasePrise;
        item.transform.DOLocalMove(new Vector3(0,2f,0),2f);
        yield return new WaitForSeconds(2f);
        item.transform.DOLocalMove(new Vector3(0,0,2),2f);
        yield return new WaitForSeconds(1f);
        item.GetComponent<ItemBehavior>().CanBePickedUp = true;
        yield return new WaitForSeconds(1f);
        transform.DOScale(new Vector3(0, 0, 0),1);
        Destroy(this,1);
    }

    public string GetRarity()
    {
        int procentage = Random.Range(1, 101);
        string Rarity = WhatRarity(procentage);

        switch(Rarity)
        {
            case "Commen":
                Debug.Log("You got a commen item" + procentage);
                return "Commen";
                break;
            case "Rare":
                Debug.Log("You got a rare item" + procentage);
                return "Rare";
                break;
            case "Legendary":
                Debug.Log("You got a legendary item" + procentage);
                return "Legendary";
                break;
            case "Null":
                Debug.Log("There was a error" + procentage);
                break;
        }

        return null;
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