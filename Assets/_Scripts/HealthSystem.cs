using System;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;
using TMPro;

public abstract class HealthSystem : MonoBehaviour
{
    [Header("Stats")] public int maxHealth = 100;
    public int passivelifeRegen = 0;
    public int currentHealth;
    public float attackSpeed = 3;
    public float moveSpeed = 5;
    public float attackDamage = 10;
    public float critChance = 10;
    public float critDamage = 2;
    public float blockChance = 0;
    [Header("UIPrefabs")]
    public GameObject popup;
    public virtual void TakeDamage(int baseDamage)
    {
        currentHealth -= baseDamage;
        
        GameObject worldCanvas = GameObject.FindGameObjectWithTag("WorldCanvas");
        Debug.Log("FoundCanvas");
        Debug.Log("SPAWNED SHIT");
        GameObject instantiatedPopup = Instantiate(popup, worldCanvas.transform);
        instantiatedPopup.transform.localPosition = transform.position;
        TMP_Text popupText = instantiatedPopup.GetComponent<TMP_Text>();
        
        Debug.Log("FOUND TEXT");
        popupText.text = baseDamage.ToString();
        popupText.transform.DOScale(Vector3.one * 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);
        popupText.DOFade(0, 10f).OnComplete(() => Destroy(instantiatedPopup));
    }

    public int calculateDamage(int baseDamage)
    {
        float critRoll = UnityEngine.Random.Range(0f, 100f);
        bool isCrit = critRoll <= critChance;
        if (isCrit)
        {
            return Mathf.CeilToInt(baseDamage * critDamage);
        }
        return baseDamage;
    }
}
