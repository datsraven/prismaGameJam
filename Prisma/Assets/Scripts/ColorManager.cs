using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public Material generalMaterial;

    private bool RedColor;
    private bool GreenColor;
    private bool BlueColor;

    public float currentIntensity = 1.0f;
    private float redIntensity = 1.0f;
    private float greenIntensity = 1.0f;
    private float blueIntensity = 1.0f;

    // Update is called once per frame

    private void Start()
    {
        generalMaterial.SetFloat("_RedScaleFactor", 1.0f);
        generalMaterial.SetFloat("_GreenScaleFactor", 1.0f);
        generalMaterial.SetFloat("_BlueScaleFactor", 1.0f);
    }

    void Update()
    {
        float intensity = 0.0f;
        if (RedColor) intensity += 1.0f;
        if (GreenColor) intensity += 1.0f;
        if (BlueColor) intensity += 1.0f;

        if (intensity == 1.0f) intensity = 0.7f;
        else if (intensity == 2.0f) intensity = 0.4f;
        else if (intensity == 3.0f) intensity = 0.0f;
        else intensity = 1.0f;

        float LerpFactor = Mathf.Clamp01(1.0f * Time.deltaTime);
        if (Mathf.Abs(currentIntensity - intensity) > 0.02f)
            currentIntensity = Mathf.Lerp(currentIntensity, intensity, LerpFactor);
        else
            currentIntensity = intensity;

        if (RedColor)
        {
            redIntensity = Mathf.Lerp(redIntensity, currentIntensity, LerpFactor);
            generalMaterial.SetFloat("_RedScaleFactor", redIntensity);
        }
        
        if (GreenColor)
        {
            greenIntensity = Mathf.Lerp(greenIntensity, currentIntensity, LerpFactor);
            generalMaterial.SetFloat("_GreenScaleFactor", greenIntensity);
        }
            
        
        if (BlueColor)
        {
            blueIntensity = Mathf.Lerp(blueIntensity, currentIntensity, LerpFactor);
            generalMaterial.SetFloat("_BlueScaleFactor", blueIntensity );
        }
            

        //generalMaterial.SetFloat("_RedScaleFactor", 0.1f);
        //generalMaterial.SetFloat("_GreenScaleFactor", 0.1f);
        //generalMaterial.SetFloat("_BlueScaleFactor", 0.1f);
    }

    public void EnableRed()     { RedColor = true; }
    public void EnableGreen()   { GreenColor = true; }
    public void EnableBlue()    { BlueColor = true; }
}
