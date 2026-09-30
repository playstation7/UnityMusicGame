using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycasterController : MonoBehaviour
{
    static GraphicRaycaster raycaster;
    private void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }
    public static List<RaycastResult> GetRaycastResults(Vector3 pos) 
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {

            //position = Camera.main.ScreenPointToRay()
            position = Camera.main.WorldToScreenPoint(pos),
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);
        return results;


    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
    //    {
    //        PointerEventData pointerData = new PointerEventData(eventSystem)
    //        {
    //            position = Input.mousePosition // Получаем позицию курсора мыши
    //        };

    //        List<RaycastResult> results = new List<RaycastResult>();
    //        raycaster.Raycast(pointerData, results); // Выполняем Raycast

    //        if (results.Count > 0)
    //        {
    //            // Если есть результаты, значит луч попал в UI-объект
    //            foreach (var result in results)
    //            {
    //                Debug.Log("Попали в объект: " + result.gameObject.name);
    //            }
    //        }
    //    }
    //}
    
}
