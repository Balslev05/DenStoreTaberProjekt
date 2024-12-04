using System;
using System.Collections;
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
    public virtual IEnumerator TakeDamage(int baseDamage,bool isCritical)
    {
        currentHealth -= baseDamage;
        GameObject text = Instantiate(popup, transform.position, Quaternion.identity);
        text.transform.localScale = Vector3.zero;
        text.transform.rotation = Quaternion.Euler(0, 45, 0);
        TextMesh t = text.GetComponent<TextMesh>();
        t.text = baseDamage.ToString();
        t.transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f,2,1);
        t.transform.DOPunchPosition(new Vector3(2,2,2),2,1, 0.5f);
        if (isCritical)
        {
            t.color = Color.red;
        }
        else if (isCritical)
        {
            t.color = Color.white;
        }
       // t.transform.DOLocalMoveY(2, 0.5f);
        yield return new WaitForSeconds(1f);
        t.transform.DOScale(new Vector3(0,0,0),0.5f);
        Destroy(t,0.5f);
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
