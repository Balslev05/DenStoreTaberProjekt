using UnityEngine;
using DG.Tweening;
public class ItemAnimation : MonoBehaviour
{
    public float Roratespeed;
    public float UpAndDownSpeed;
    private Transform t;
    [SerializeField] private GameObject ObjectToANimate;
    void Start()
    {
        t = transform.GetChild(0).GetComponent<Transform>();
        Animation();
    }
    public void Animation()
    {
        t.DOLocalRotate(new Vector3(0, 360, 0), Roratespeed, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        //transform.DOLocalMove(new Vector3(t.position.x, t.position.y,t.transform.position.z), UpAndDownSpeed);
        t.DOLocalMove(new Vector3(t.localPosition.x, t.localPosition.y+0.5f, t.transform.localPosition.z), UpAndDownSpeed).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
