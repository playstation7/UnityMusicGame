using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public UpgradePawn upgradePawn;
    public GameObject button;
    public TextMeshProUGUI namePawn;
    public TextMeshProUGUI value;
    public GameObject attentionPanel;
    public ConfirmPanelController confirmPanel;
    int curLevel;
    int curPrice;
    int curValue;

    private void Awake()
    {
        RefreshInfo();
        
    }

    private void RefreshInfo()
    {
        namePawn.text = upgradePawn.UpgradeName;
        curLevel = PlayerPrefs.GetInt(upgradePawn.upgradeType.ToString() + "Level", 0);

        if (curLevel == (upgradePawn.prices.Length - 1))
        {
            value.text = "";
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Max";
            return;
        }

        curPrice = upgradePawn.prices[curLevel];
        curValue = upgradePawn.values[curLevel];
        button.GetComponent<Button>().onClick.AddListener(Upgrade);
        button.GetComponentInChildren<TextMeshProUGUI>().text = curPrice.ToString();
        value.text = curValue.ToString() + "-->" + upgradePawn.values[curLevel + 1];
    }

    private void Upgrade()
    {
        confirmPanel.CreateQuestion("Upgrade item?", onAnswered);
        
        
    }

    private void onAnswered(bool ans)
    {
        if (!ans)
            return;
        
        if (GameManager.instance.TotalNotes > curPrice)
        {
            curLevel++;
            PlayerPrefs.SetInt(upgradePawn.upgradeType.ToString() + "Level", curLevel);
            GameManager.instance.TotalNotes -= curPrice;
            GameManager.instance.SetPawnValues(upgradePawn.upgradeType, upgradePawn.values[curLevel]);
            RefreshInfo();
        }
        else
        {
            attentionPanel.GetComponent<BigUIPanel>().ShowAttention("Недостаточно средств!");
        }
    }
}
