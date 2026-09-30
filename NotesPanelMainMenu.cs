using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesPanelMainMenu : MonoBehaviour
{
    public TextMeshProUGUI notesPanelText;
    void Start()
    {
        GameManager.instance.notesChanged.AddListener(RefreshNote);
        RefreshNote();
        
    }

    private void RefreshNote()
    {
        notesPanelText.text = PlayerPrefs.GetInt("TotalNotes", 0).ToString();
    }
}
