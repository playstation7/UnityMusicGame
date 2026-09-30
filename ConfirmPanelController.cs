using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelController : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button yesButton;
    public Button noButton;


    private Action<bool> callback;


    public void CreateQuestion(string message, Action<bool> onAnswered)
    {
        gameObject.SetActive(true); 
        questionText.text = message;
        callback = onAnswered;


        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }


    private void OnYesClicked()
    {
        callback?.Invoke(true);
        gameObject.SetActive(false); 
    }

    private void OnNoClicked()
    {
        callback?.Invoke(false);
        gameObject.SetActive(false);
    }
}
