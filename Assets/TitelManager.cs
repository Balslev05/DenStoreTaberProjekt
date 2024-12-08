using System.Collections;
using UnityEngine;
using DG.Tweening;
public class TitelManager : MonoBehaviour
{
    public RectTransform TitelCard;
    public RectTransform GearUp;
    public RectTransform RunAway;
    void Start()
    {
        TitelCard.DOAnchorPos(new Vector3(0, 500, 0),0);
        GearUp.DOAnchorPos(new Vector3(0, 700, 0),0);
        RunAway.DOAnchorPos(new Vector3(0, 700, 0),0);
        StartCoroutine(IntroAnimation());
    }

    public IEnumerator IntroAnimation()
    {
        yield return new WaitForSeconds(1f);
        TitelCard.DOAnchorPos(new Vector2(0,0), 0.2f).SetEase(Ease.InExpo).OnComplete(() => CameraShake.Shake(1,1));
        yield return new WaitForSeconds(0.1f);
        TitelCard.DOPunchRotation(new Vector3(10, 10, 10),0.5f,1,2);
        yield return new WaitForSeconds(0.5f);
        TitelCard.DOPunchRotation(new Vector3(0, 0, 0),0.5f,1,2);
        yield return new WaitForSeconds(1.5f);
        GearUp.DOAnchorPos(new Vector2(210,-60), 0.3f).SetEase(Ease.InExpo);
        yield return new WaitForSeconds(0.3f);
        CameraShake.Shake(0.2f,0.2f);
        RunAway.DOAnchorPos(new Vector2(190,-265), 0.3f).SetEase(Ease.InExpo);
        yield return new WaitForSeconds(0.3f);
        CameraShake.Shake(0.2f,0.2f);
       // StartCoroutine(IdleAnimation());

    }
    
    
    private IEnumerator IdleAnimation()
    {
        while (true) // Loop indefinitely for continuous animation
        {
            // Move TitelCard up
            TitelCard.DOAnchorPos(TitelCard.anchoredPosition + new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            // Move GearUp up
            GearUp.DOAnchorPos(GearUp.anchoredPosition + new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            // Move RunAway up
            RunAway.DOAnchorPos(RunAway.anchoredPosition + new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
            // Move TitelCard down
            TitelCard.DOAnchorPos(TitelCard.anchoredPosition - new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            // Move GearUp down
            GearUp.DOAnchorPos(GearUp.anchoredPosition - new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            // Move RunAway down
            RunAway.DOAnchorPos(RunAway.anchoredPosition - new Vector2(0, 5), 1f).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
        }
    }

}
