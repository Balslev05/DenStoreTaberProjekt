using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using DG.Tweening.Core.Easing;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_interactive : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler,IPointerClickHandler
{
    
    [Header("OnPointerEnter")]
    public Vector2 Size_Enter;
    public Vector2 MoveTO_Enter;
    public float AnimDuration_Enter;
    public EaseCurve Curve_Enter;

    [Header("OnPointerExit")]
    public Vector2 Size_Exit;
    public Vector2 MoveTO_Exit;
    public float AnimDuration_Exit;
    public EaseCurve Curve_Exit;
    
    public bool IsQuit;
    public bool IsMovingOn;
    public UnityEvent Trans;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Size_Enter, AnimDuration_Enter).SetEase(Ease.InOutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Size_Exit, AnimDuration_Exit).SetEase(Ease.InOutQuad);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsQuit)
        {
            Application.Quit();
        }

        if (IsMovingOn)
        {
            Trans.Invoke();
        }
    }
}