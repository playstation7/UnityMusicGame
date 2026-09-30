using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int totalNotes;
    public UnityEvent notesChanged;
    public int ShortPawnValue 
    {
        get 
        {
            return PlayerPrefs.GetInt(UpgradeType.ShortPawn.ToString(), 5);
        }
        set 
        {
            PlayerPrefs.SetInt(UpgradeType.ShortPawn.ToString(), value);
        }
    }

    public int LongPawnValue
    {
        get
        {
            return PlayerPrefs.GetInt(UpgradeType.LongPawn.ToString(), 20);
        }
        set
        {
            PlayerPrefs.SetInt(UpgradeType.LongPawn.ToString(), value);
        }
    }



    public int TotalNotes 
    {
        get { return totalNotes; }
        set { totalNotes = value; PlayerPrefs.SetInt("TotalNotes", value); notesChanged.Invoke(); }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        totalNotes = PlayerPrefs.GetInt("TotalNotes", 0);

    }

    public void SetPawnValues(UpgradeType upgradeType,int level) 
    {
        PlayerPrefs.SetInt(upgradeType.ToString(), level);
    }
}
