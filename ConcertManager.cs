using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConcertManager : MonoBehaviour
{
    
    float happyPoint = 0f;
    float notePoint = 0f;
    static float scale = 1f;
    public Image image;
    public Image discoImage;
    public GameObject xBonus;
    float xBonusActivatedTime = 0f;
    public static TextMeshProUGUI textNotePoints;
    public UnityEvent gameEnd;


    //public TextMeshProUGUI moneyCount;
    public TextMeshProUGUI peopleCount;
    public UnityEvent gameStart;
    public static int money = 5;
    public static int people = 0;

    private void Awake()
    {
        if (LevelSelector.Instance.levelDetail != null)
        {
            AudioSource audioSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();
            audioSource.clip = LevelSelector.Instance.levelDetail.audioClip;
            audioSource.Play();
            GameObject.Find("BackGround").GetComponent<SpriteRenderer>().sprite = LevelSelector.Instance.levelDetail.background;
        }
    }


    private void Start()
    {
        gameEnd.AddListener(gameEnding);
        //MusicSinchronization.concertStart.AddListener(()=>happyPoint = 50f);
        happyPoint = 50f;
        textNotePoints = GameObject.Find("NoteCount").gameObject.GetComponent<TextMeshProUGUI>();
        gameStart.Invoke();
    }

    private void gameEnding()
    {
        GameManager.instance.TotalNotes += (int)notePoint;
        LevelDetail levelDetail = LevelSelector.Instance.levelDetail;
        if (notePoint > PlayerPrefs.GetInt(string.Format("level{0}_NoteRecord", levelDetail.levelID), 0))
            PlayerPrefs.SetInt(string.Format("level{0}_NoteRecord", levelDetail.levelID), (int)notePoint);

        int star = 0;
        for (int i = 0; i < levelDetail.notesToGetStars.Length; i++)
            if (notePoint > levelDetail.notesToGetStars[i]) 
            {
                star++;
            }
        if (star > PlayerPrefs.GetInt(string.Format("level{0}_StarsWin", levelDetail.levelID), 0)) 
        {
            
            PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars",0) + star - PlayerPrefs.GetInt(string.Format("level{0}_StarsWin", levelDetail.levelID), 0));
            PlayerPrefs.SetInt(string.Format("level{0}_StarsWin", levelDetail.levelID), star);
        }






        SceneManager.LoadScene(1);
    }

    public void AddNotePoint(float p)
    {
        notePoint += p;
        textNotePoints.text = ((int)notePoint).ToString();
    }
    public void AddPoint(float p)
    {
        if (xBonusActivatedTime > 0)return;

        happyPoint += p;
        scale = 1.1f;

        if (happyPoint >= 100) 
        {
            xBonusActivatedTime = 5f;
            xBonus.SetActive(true);
            discoImage.color *= new Color(0.5f,0.5f,0.5f,1f);
        }
    }
    private void Update()
    {
        peopleCount.text = $"{people}/{GameSettings.MaxPeopleCrowd}";
        if (xBonusActivatedTime > 0) { xBonusActivatedTime -= Time.deltaTime; return; }
        else { xBonus.SetActive(false); discoImage.color = Color.white; }
       
        image.fillAmount = happyPoint / 100f;
        happyPoint -= Time.deltaTime;
        scale -= Time.deltaTime;
        happyPoint = Mathf.Clamp(happyPoint, 0f, 100f);
        scale = Mathf.Clamp(scale, 1f, 1.1f);
        image.transform.localScale = new Vector3(scale,scale,1f);
        if (happyPoint < 50)
            image.color = Color.Lerp(Color.red, Color.yellow, happyPoint / 50f);
        else
            image.color = Color.Lerp(Color.yellow, Color.green, (happyPoint-50f) / 50f);
        if (happyPoint <= 0) 
        {
            gameEnd.Invoke();
        }

    }
}
