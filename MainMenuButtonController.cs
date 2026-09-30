using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    public LevelDetail levelDetail;
    public GameObject unlockedPanel;
    public GameObject lockedPanel;
    public TextMeshProUGUI noteRecordText;
    public TextMeshProUGUI starsTonUnlockText;
    public GameObject difficultyPanel;
    public TextMeshProUGUI descriptionText;
    public GameObject[] stars;
    public TextMeshProUGUI[] notesToStarsText;
    private void Start()
    {
        if (PlayerPrefs.GetInt("TotalStars",0) >= levelDetail.starsToUnlock)
        {
        
            unlockedPanel.SetActive(true);
            lockedPanel.SetActive(false);
            int record = PlayerPrefs.GetInt(string.Format("level{0}_NoteRecord", levelDetail.levelID), 0);
            noteRecordText.text = record.ToString("N0", new CultureInfo("fr-FR"));

            //note record show
            for (int i = 0; i < 3; i++)
            {
                notesToStarsText[i].text = levelDetail.notesToGetStars[i].ToString();
            }
            //stars show
            for (int i = 0; i < PlayerPrefs.GetInt(string.Format("level{0}_StarsWin", levelDetail.levelID), 0); i++)
            {
                stars[i].GetComponent<Image>().color = new Color(1f, 0.7480871f, 0.1179245f, 1f);
            }
            //difficulty show
            Color color;
            switch (levelDetail.difficulty)
            {
                case 1: 
                    color = Color.green;
                    break;
                case 2: 
                    color = Color.yellow;
                    break;
                case 3:
                    color = new Color(0.9716981f, 0.4944758f, 0.0504183f,1f);
                    break;
                case 4:
                    color = new Color(0.9716981f, 0.4944758f, 0.0504183f, 1f);
                    break;
                case 5:
                    color = Color.red;
                    break;
                default:
                    color = Color.green;
                    break;
            }
            for (int i = 0; i < levelDetail.difficulty; i++)
            {
                difficultyPanel.transform.GetChild(i).GetComponent<Image>().color = color;
            }

            //difficultyDescription text
            descriptionText.text = "Used pawns:";
            for (int i = 0; i < levelDetail.weightedTypes.Length; i++)
            {
                descriptionText.text += "\n- " + levelDetail.weightedTypes[i].type.ToString();

            }
        


            
        }
        else 
        {
            gameObject.GetComponent<Button>().interactable = false;
            unlockedPanel.SetActive(false);
            lockedPanel.SetActive(true);
            int stars = levelDetail.starsToUnlock - PlayerPrefs.GetInt("TotalStars", 0);
            starsTonUnlockText.text = stars.ToString(); ;

        }      
        GetComponentInChildren<TextMeshProUGUI>().text = levelDetail.description;
        gameObject.GetComponent<Button>().onClick.AddListener(onClick);


        

        
    }

    public void onClick() 
    {
        
        LevelSelector.Instance.levelDetail = levelDetail;
        SceneManager.LoadScene(0);
    }
}
