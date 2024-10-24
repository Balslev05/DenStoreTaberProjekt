using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Descreption;
    public TMP_Text text;

    public void Start()
    {
        FindTextfiled();
    }
    
    public void FindTextfiled()
    {
        text = GameObject.Find("DescreptionText").GetComponent<TMP_Text>(); 
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        text.text = Descreption;
    }
    
    public void OnPointerExit(PointerEventData pointerEventData)
    {
       text.text = "Hover over a item to see its effects";
    }
}
