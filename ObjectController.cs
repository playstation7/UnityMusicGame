using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ObjectController : MonoBehaviour, IScalable
{
    private void OnEnable()
    {
        //PawnGenerator.scaleSeter += setScale;
    }

    private void OnDisable()
    {
        //PawnGenerator.scaleSeter -= setScale;
    }

    public void setScale(float scale)
    {
        transform.localScale = new Vector3(1f,1f,0f) * scale;
    }




}
