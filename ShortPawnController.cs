using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShortPawnController : PawnController
{


    int valuePoint;
    private void OnEnable()
    {
        GetComponent<Image>().color = Color.white;
        valuePoint = GameManager.instance.ShortPawnValue;

    }



    public override void Activate()
    {
        if (activated) return;
        activated = true;
        GetComponent<ParticleSystem>().Play();
        Ease ease = Ease.InFlash;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(GetComponent<RectTransform>().DOScale(0.8f, 0.1f).SetEase(ease))
            .Append(GetComponent<RectTransform>().DOScale(1.1f, 0.1f).SetEase(ease))
            .Append(GetComponent<RectTransform>().DOScale(0.9f, 0.1f).SetEase(ease))
            .Append(GetComponent<RectTransform>().DOScale(1.1f, 0.1f).SetEase(ease))
            .Append(GetComponent<RectTransform>().DOScale(1f, 0.1f).SetEase(ease)).SetLink(gameObject);
        sequence.Play();
        DOTween.Sequence().Append(GetComponent<Image>().DOFade(0f, 1.5f).SetEase(Ease.Flash)).SetLink(gameObject).Play();
        //Debug.Log(GetComponent<RectTransform>().anchoredPosition.x);
        concertManager.AddPoint(3f);
        concertManager.AddNotePoint(valuePoint);
        //CameraSkaher.size = 4.8f;


    }

    public override void Missed()
    {
        GetComponent<Image>().color = Color.red;
        CenterController.centerCheckLose.Invoke();
        concertManager.AddPoint(-5f);
    }



  
}
