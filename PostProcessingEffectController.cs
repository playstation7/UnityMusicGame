using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingEffectController : MonoBehaviour
{

    public Volume volume;
    Vignette vignette;
    private float vignetteActiveTime;
    ClampedFloatParameter floatParameter;
    private void Awake()
    {
        CenterController.centerCheckLose.AddListener(vignetteActivate);
        floatParameter = new ClampedFloatParameter(0f, 0f, 1f);
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        vignette.intensity.SetValue(floatParameter);
    }

    private void Update()
    {
        if (vignetteActiveTime > 0f)
        {
            vignetteActiveTime -= Time.deltaTime;
            vignetteActiveTime = Mathf.Clamp(vignetteActiveTime,0f,float.MaxValue);
        }
        else 
        {
            floatParameter.value -= Time.deltaTime;
            floatParameter.value = Mathf.Clamp(floatParameter.value, 0f, float.MaxValue);

        }
        if (vignette != null)
        {
            vignette.intensity.SetValue(floatParameter);
        }


    }
    public void vignetteActivate() 
    {
        floatParameter.value = 0.3f;
        vignetteActiveTime = 0.5f;
    }
}
