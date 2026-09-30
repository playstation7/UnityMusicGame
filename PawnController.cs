
using UnityEngine;
using DG;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public abstract class PawnController : MonoBehaviour
{
    RectTransform rTransform;
    public Vector3 startPos;
    public Vector3 targetPos;
    float t = 0f;
    protected bool activated = false;
    protected ConcertManager concertManager;


    public GameObject nextPawn;

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
        concertManager = GameObject.FindObjectOfType<ConcertManager>();
        //startPos = new Vector3(1100f, rTransform.anchoredPosition.y, 0f);
        //targetPos = new Vector3(-150f, rTransform.anchoredPosition.y, 0f);

        //DOTween.Sequence().AppendInterval(1f).Append(GetComponent<Image>().DOFade(1f, 1.8f)).SetLink(gameObject);

    }


    private void Update()
    {
        

        t += Time.deltaTime * GameSettings.pawnSpeed;
        rTransform.anchoredPosition = Vector3.Lerp(startPos, targetPos, t);
        if (rTransform.anchoredPosition == (Vector2)targetPos) gameObject.SetActive(false);
        if (rTransform.anchoredPosition.x + rTransform.rect.width  < 0f) 
        {
            if (!activated) 
            {
                Missed();
                activated = true;
            }
            t += Time.deltaTime * GameSettings.pawnSpeed;
        }







        
    }

    public abstract void Activate();
    public abstract void Missed();


 






}
