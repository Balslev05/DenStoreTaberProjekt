using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;
using TMPro;

public abstract class HealthSystem : MonoBehaviour
{
    [Header("Stats")] public int maxHealth = 100;
    public float currentHealth;
    public float attackSpeed = 3;
    public float moveSpeed = 5;
    public float DamageMultiplayer = 1;
    public float critChance = 10;
    public float CritMultiplayer = 2;
    public bool readyToGetHit = true;
    public int dashes;
    [Header("UIPrefabs")]
    public GameObject popup;
    public virtual IEnumerator TakeDamage(float baseDamage,bool isCritical)
    {
        Debug.Log(isCritical);
        currentHealth -= baseDamage;
        GameObject text = Instantiate(popup, transform.position, Quaternion.identity);
        text.transform.localScale = Vector3.zero;
        text.transform.rotation = Quaternion.Euler(0, 45, 0);
        TextMesh t = text.GetComponent<TextMesh>();
        if (isCritical)
        {
            t.color = Color.red;
        }
        if (!isCritical)
        {
            t.color = Color.white;
        }
        t.text = baseDamage.ToString();
        t.transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f,2,1);
        t.transform.DOPunchPosition(new Vector3(2,2,2),2,1, 0.5f);
        Destroy(t,4);
       // t.transform.DOLocalMoveY(2, 0.5f);
        yield return new WaitForSeconds(1f);
        t.transform.DOScale(new Vector3(0,0,0),0.5f);
        Destroy(t,0.5f);
    }
    
    public virtual IEnumerator TakeDamagePlayer(float baseDamage)
    {
        if (readyToGetHit)
        {
            currentHealth -= baseDamage;
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    

    public float calculateDamage(float baseDamage)
    {
        baseDamage *= DamageMultiplayer;
        float critRoll = UnityEngine.Random.Range(0f, 100f);
        bool isCrit = critRoll <= critChance;
        if (isCrit)
        {
            baseDamage = baseDamage * CritMultiplayer;
        }
        return baseDamage;
    }
}
