using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BigUIPanel : MonoBehaviour
{
    //public static UnityEvent<GameObject> openBigUIPanel = new UnityEvent<GameObject>();
    Sequence sequence;
    public bool leftSide;
    float y;
    private void Awake()
    {
        y = leftSide ? -160f : 160f;
        Vector3 v3 = GetComponent<RectTransform>().anchoredPosition;
        GetComponent<RectTransform>().anchoredPosition = new Vector3(y, v3.y, v3.z);
        //openBigUIPanel.AddListener(openBigPanel);
    }


    //private void OnEnable()
    //{
    //    showPanel();
    //}
    private void OnDisable()
    {
        Vector3 v3 = GetComponent<RectTransform>().anchoredPosition;
        GetComponent<RectTransform>().anchoredPosition = new Vector3(y,v3.y,v3.z);
    }

    public void ShowAttention(string message) 
    {
        GetComponentInChildren<TextMeshProUGUI>().text = message;
        GetComponent<RectTransform>().anchoredPosition = new Vector3(y, 80f, 0f);
        sequence.Kill();
        sequence = DOTween.Sequence().Append(GetComponent<RectTransform>().DOAnchorPos3DX(-y, 0.3f))
            .AppendInterval(2f)
            .Append(GetComponent<RectTransform>().DOAnchorPos3DX(y, 0.3f)).SetLink(gameObject).Play();
    }


    //void Update()
    //{
    //    // Проверяем, был ли клик мыши
    //    if (Input.GetMouseButtonDown(0)) // 0 - левая кнопка мыши
    //    {
    //        // Проверяем, находится ли указатель над UI элементом
    //        if (!EventSystem.current.IsPointerOverGameObject())
    //        {
    //            // Здесь обрабатываем клик вне UI элементов
    //            hidePanel();
    //        }
    //    }
    //}
    //private void openBigPanel(GameObject arg)
    //{
    //    if (arg != gameObject) hidePanel();
    //}

    public void showPanel() {
        //openBigUIPanel.Invoke(gameObject);
        GetComponent<RectTransform>().DOAnchorPos3DX(-y, 0.3f).SetLink(gameObject); 
    }
    public void hidePanel() { GetComponent<RectTransform>().DOAnchorPos3DX(y, 0.3f).SetLink(gameObject); }
}