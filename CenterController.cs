
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CenterController : MonoBehaviour, ICheckable
{
    public static UnityEvent centerCheckLose = new UnityEvent(); //red vinquete && camarashaker
    RectTransform rectTransform;    
    //public Queue<GameObject> pawns = new Queue<GameObject>();
    float targetScale = 1f;
    Color startColor;
    private bool activateSucces;
    public AudioClip kickClip;
    ConcertManager concertManager;
    private void Start()
    {
        concertManager = GameObject.FindObjectOfType<ConcertManager>();
        rectTransform = GetComponent<RectTransform>();
        startColor = GetComponent<Image>().color;
    }


    public void CenterCheck()
    {
        if (!activateSucces) return;
        targetScale = 0.92f;
        List<RaycastResult> results = getRayCustResult();
        if (results.Count > 0)
        {
            results[0].gameObject.GetComponent<PawnController>().Activate();
        }
        else 
        {
            activateSucces = false;
            
        }



    }
    public void CenterDown()
    {
        List<RaycastResult> results = getRayCustResult();
        if (results.Count > 0) 
        {
            activateSucces = true;
        }
        else {centerCheckLose.Invoke(); CameraSkaher.shake(); activateSucces = false; concertManager.AddPoint(-5f); }
        GetComponent<Image>().color = GetComponent<Image>().color * Color.gray;
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
    }

    public void CenterUP()
    {
        activateSucces = false;
        targetScale = 1f;
        GetComponent<Image>().color = startColor;
    }

    List<RaycastResult> getRayCustResult() 
    {
        List<RaycastResult> results = RaycasterController.GetRaycastResults(rectTransform.position);

        PawnController pawnController = null;
        results = results.Where(x => x.gameObject.TryGetComponent<PawnController>(out pawnController) == true).ToList();
        return results;

    }




    private void Update()
    {
        GetComponent<RectTransform>().localScale = 
            Vector3.MoveTowards(GetComponent<RectTransform>().localScale,Vector3.one * targetScale,Time.deltaTime * 20f);
        
    }

}
