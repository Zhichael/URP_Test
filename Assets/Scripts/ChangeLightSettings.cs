using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeLightSettings : MonoBehaviour
{
    public bool isSpotLight = true;
    public Light currentLight;
    public TMP_Text lightName;
    public Slider[] colorsAndIntensity;

    // Start is called before the first frame update
    void Start()
    {
        lightName.text = currentLight.name;
        for(int i = 0; i < colorsAndIntensity.Length; i++)
        {
            colorsAndIntensity[i].onValueChanged.AddListener(ChangeColorAndIntensity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeColorAndIntensity(float value)
    {
        byte rSlider = (byte)colorsAndIntensity[0].value;
        byte gSlider = (byte)colorsAndIntensity[1].value;
        byte bSlider = (byte)colorsAndIntensity[2].value;
        byte alpha = 255;

        Color32 newRGBA = new Color32(rSlider, gSlider, bSlider, alpha);

        currentLight.color = newRGBA;

        currentLight.intensity = colorsAndIntensity[3].value;

        if (isSpotLight)
        {
            float outerSlider = colorsAndIntensity[4].value;
            float innerSlider = colorsAndIntensity[5].value;
            currentLight.spotAngle = outerSlider;
            currentLight.innerSpotAngle = innerSlider;
        }
    }
}
