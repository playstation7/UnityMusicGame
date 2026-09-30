using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSkaher : MonoBehaviour
{

    static float shakeTime = 0f;
    Vector3 startPos;
    public static float size = 5f;
    private void Start()
    {
        //CenterController.centerCheckLose.AddListener(shake);
        startPos = transform.position;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            transform.position = startPos + (Vector3)Random.insideUnitCircle / 100f;
            shakeTime -= Time.deltaTime;
        }
        else 
        {
            transform.position = startPos;
        }

        Camera.main.orthographicSize = size;
        size = Mathf.Clamp(size + Time.deltaTime, 4f, 5f);


        
        
    }

    public static void shake()
    {
        size = 4.9f;
        shakeTime = 0.1f;
        
    }
}
