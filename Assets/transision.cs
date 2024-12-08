using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transision : MonoBehaviour
{
    public Vector3 StartPos;
    public Vector3 EndPos;
    public bool OnAwake;
    public bool SwitchScene;
    public int timer;
    public int Screentimer;
    public MusicHandler music;
    void Start()
    {
        music.FadeInMusic();
        gameObject.transform.localScale = StartPos;
        if (OnAwake)
        {
            gameObject.transform.DOScale(EndPos,timer).SetEase(Ease.OutExpo);
        } 
        if (SwitchScene)
        {
            Invoke(nameof(SwitcScene),Screentimer);
        }
    }
    public void ButtonPress()
    {
        music.FadeOutMusic();
        gameObject.transform.localScale = StartPos;
        gameObject.transform.DOScale(EndPos,timer).SetEase(Ease.OutExpo);
        Invoke(nameof(SwitcScene),Screentimer);
    }
	
    public void SwitcScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}