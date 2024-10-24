using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class constRotation : MonoBehaviour
{
    public Vector3 rotation;
    void Start()
    {
        StartRotate();
    }

    public void StartRotate()
    {
      transform.DORotate(rotation, 1f).SetEase(Ease.Linear);
    }
    void Update()
    {
        
    }
}
