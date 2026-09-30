using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class UI : MonoBehaviour
{
    Vector3 startPos;
    private void Start()
    {
        startPos = GetComponent<RectTransform>().localPosition;
    }
    public void PanelSelect() 
    {
        GetComponent<RectTransform>().DOAnchorPos3DY(startPos.y + 20f, 0.1f).SetLink(gameObject);
    }
    public void PanelExit()
    {
        GetComponent<RectTransform>().DOAnchorPos3DY(startPos.y, 0.1f).SetLink(gameObject);
    }
    public void PanelPressed(GameObject obj)
    {
        obj.GetComponent<BigUIPanel>().showPanel();
    }

    


   


}
