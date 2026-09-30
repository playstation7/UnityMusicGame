using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsPanelMainMenu : MonoBehaviour
{
    public TextMeshProUGUI starsPanelText;
    void Start()
    {
        starsPanelText.text = PlayerPrefs.GetInt("TotalStars", 0).ToString();

    }
}
