using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float elapsedTime = 3f;
    [SerializeField] private float time = 3;
    private bool readyToMove = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveCoins());
    }

    public IEnumerator MoveCoins()
    {
        yield return new WaitForSeconds(0.2f);
        readyToMove = true;
    }

    private void Update()
    {
        if (readyToMove)
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / time;
            transform.position  = Vector3.Slerp(this.transform.position, player.transform.position, percentage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().gold++;
            Destroy(this.gameObject);
        }
    }
}
