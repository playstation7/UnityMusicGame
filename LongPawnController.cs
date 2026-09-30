using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LongPawnController : PawnController
{
    float coef;
    private float _float = 0.7f;
    public GameObject effect;
    public AudioClip flashDesappear;
    int valuePoint;
    private void OnEnable()
    {
        _float = 0.7f;
        GetComponent<Image>().material = new Material(GetComponent<Image>().material);
        GetComponent<Image>().material.SetColor("_Color", Color.white);
        GetComponent<Image>().material.SetFloat("_Float",_float);
        coef = GameSettings.longPawnActivateTime / _float;
        valuePoint = GameManager.instance.LongPawnValue;
        gameObject.GetComponent<Image>().raycastTarget = true;
        effect.SetActive(false);
    }
    public override void Activate()
    {
        if (activated) return;


        if (_float == 0.7f) 
        {
            GetComponent<RectTransform>().GetChild(0).gameObject.SetActive(false);

            //CameraSkaher.size = 4.8f;
        }

        _float -= Time.deltaTime / coef;
        if (_float < 0.1f) 
        { 
            activated = true;
            concertManager.AddNotePoint(20);


            effect.SetActive(true);
            AudioSource.PlayClipAtPoint(flashDesappear, Camera.main.transform.position);
            gameObject.GetComponent<Image>().raycastTarget = false;
        }
        //transform.Find("Filled").GetComponent<Image>().fillAmount = progress;
        GetComponent<Image>().material.SetFloat("_Float", _float);
        concertManager.AddPoint(Time.deltaTime * 20);

    }

    public override void Missed()
    {
        GetComponent<Image>().material.SetColor("_Color", Color.red); 
        CenterController.centerCheckLose.Invoke();
        concertManager.AddPoint(-10f);
    }

 


}
