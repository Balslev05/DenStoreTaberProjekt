using UnityEngine;
using DG.Tweening;
public class ItemAnimation : MonoBehaviour
{
    public float Roratespeed;
    public float UpAndDownSpeed;
    private Transform t;
    private GameObject ObjectToANimate;
    void Start()
    {
        t = GetComponent<Transform>();
        Animation();
    }
    public void Animation()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), Roratespeed, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        //transform.DOLocalMove(new Vector3(t.position.x, t.position.y,t.transform.position.z), UpAndDownSpeed);
        transform.DOLocalMove(new Vector3(t.position.x, t.position.y+0.5f, t.transform.position.z), UpAndDownSpeed).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
