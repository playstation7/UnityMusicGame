using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyNotesManager : MonoBehaviour
{
    public int price;
    public int value;
    public TextMeshProUGUI text;
    public Button buyButton;
    public GameObject attentionPanel;
    public ConfirmPanelController confirmPanel;
    private void Awake()
    {
        buyButton.onClick.AddListener(createOrder);
        text.text = value.ToString();
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = price.ToString();
    }

    private void createOrder()
    {
        confirmPanel.CreateQuestion("You sure?", answerRecived);
    }

    private void answerRecived(bool ans)
    {
        if(ans == true)
            GameManager.instance.TotalNotes += value;
        
    }
}
