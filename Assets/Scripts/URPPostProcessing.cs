using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Globalization;

public class URPPostProcessing : MonoBehaviour
{
    public Volume globalVolume;

    [Header("Bloom Effect")]
    public Toggle isBloom;
    public TMP_InputField bloomThreshold;
    public TMP_InputField bloomIntensity;
    public Slider bloomScatter;
    public Slider[] bloomColors;
    public TMP_InputField bloomClamp;
    public Slider bloomSkipInterations;
    public TMP_InputField bloomDirtIntensity;
    public GameObject bloomDirtIntensityObj;

    [Header("Chromatic Aberration")]
    public Toggle isChromatic;
    public Slider chromaticIntensity;

    [Header("Color Adjustments")]
    public Toggle isColorAdjust;
    public TMP_InputField caPostExposure;
    public Slider caConstast;
    public Slider[] caColorFilter;
    public Slider caHueShift;
    public Slider caSaturation;

    [Header("Lens Distortion")]
    public Toggle isLensDistortion;
    public Slider ldIntensity;
    public Slider ldXMultiplier;
    public Slider ldYMultiplier;
    public TMP_InputField ldCenterX;
    public TMP_InputField ldCenterY;
    public Slider ldScale;

    [Header("Vignette")]
    public Toggle isVignette;
    public Slider[] vigColor;
    public TMP_InputField vigCenterX;
    public TMP_InputField vigCenterY;
    public Slider vigIntensity;
    public Slider vigSmoothness;
    public Toggle vigRounded;

    private void Start()
    {
        if (globalVolume.profile.TryGet<Bloom>(out var bloom))
        {
            bloomThreshold.text = bloom.threshold.value.ToString();
            bloomIntensity.text = bloom.intensity.value.ToString();
            bloomClamp.text = bloom.clamp.value.ToString();
            if (bloom.dirtTexture.value != null)
            {
                bloomDirtIntensityObj.SetActive(true);
                bloomDirtIntensity.text = bloom.dirtIntensity.value.ToString();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        EditBloom();
        /*
        if(isChromatic.isOn)
        {
            EditChromatic();
        }
        if(isColorAdjust.isOn)
        {
            EditColorAdjustment();
        }
        if(isLensDistortion.isOn)
        {
            EditLensDistortion();
        }
        if(isVignette.isOn)
        {
            EditVignette();
        }*/
    }

    public void EditBloom()
    {
        if(globalVolume.profile.TryGet<Bloom>(out var bloom))
        {
            bloom.SetAllOverridesTo(isBloom.isOn);

            if(isBloom.isOn)
            {

                bloom.threshold.value = float.Parse(bloomThreshold.text);
                bloom.intensity.value = float.Parse(bloomIntensity.text);
                bloom.scatter.value = bloomScatter.value;

                byte rSlider = (byte)bloomColors[0].value;
                byte gSlider = (byte)bloomColors[1].value;
                byte bSlider = (byte)bloomColors[2].value;
                byte alpha = 255;
                Color32 rgb = new Color32(rSlider, gSlider, bSlider, alpha);
                bloom.tint.value = rgb;

                bloom.clamp.value = int.Parse(bloomClamp.text);
                bloom.skipIterations.value = (int)bloomSkipInterations.value;

                if(bloom.dirtTexture.value != null)
                {
                    bloom.dirtIntensity.value = float.Parse(bloomDirtIntensity.text);
                }
            }
        }
    }

    public void EditChromatic()
    {
        if(globalVolume.profile.TryGet<ChromaticAberration>(out var chromatic))
        {
            chromatic.SetAllOverridesTo(isChromatic.isOn);

            if(isChromatic.isOn)
            {
                chromatic.intensity.value = chromaticIntensity.value;
            }
        }
    }

    public void EditColorAdjustment()
    {
        if(globalVolume.profile.TryGet<ColorAdjustments>(out var colorAdjust))
        {
            colorAdjust.SetAllOverridesTo(isColorAdjust.isOn);

            if(isColorAdjust.isOn)
            {
                colorAdjust.postExposure.value = float.Parse(caPostExposure.text);
                colorAdjust.contrast.value = caConstast.value;

                byte rSlider = (byte)caColorFilter[0].value;
                byte gSlider = (byte)caColorFilter[1].value;
                byte bSlider = (byte)caColorFilter[2].value;
                byte alpha = 255;
                Color32 rgb = new Color32(rSlider, gSlider, bSlider, alpha);
                colorAdjust.colorFilter.value = rgb;

                colorAdjust.hueShift.value = caHueShift.value;
                colorAdjust.saturation.value = caSaturation.value;
            }
        }
    }

    public void EditLensDistortion()
    {
        if(globalVolume.profile.TryGet<LensDistortion>(out var lensDis))
        {
            lensDis.SetAllOverridesTo(isLensDistortion.isOn);

            if(isLensDistortion.isOn)
            {
                lensDis.intensity.value = ldIntensity.value;
                lensDis.xMultiplier.value = ldXMultiplier.value;
                lensDis.xMultiplier.value = ldYMultiplier.value;

                float xCenter = float.Parse(ldCenterX.text);
                float yCenter = float.Parse(ldCenterY.text);
                lensDis.center.value = new Vector2(xCenter, yCenter);

                lensDis.scale.value = ldScale.value;
            }
        }
    }

    public void EditVignette()
    {
        if(globalVolume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.SetAllOverridesTo(isVignette.isOn);

            if(isVignette.isOn)
            {
                byte rSlider = (byte)vigColor[0].value;
                byte gSlider = (byte)vigColor[1].value;
                byte bSlider = (byte)vigColor[2].value;
                byte alpha = 255;
                Color32 rgb = new Color32(rSlider, gSlider, bSlider, alpha);
                vignette.color.value = rgb;

                float xCenter = float.Parse(ldCenterX.text);
                float yCenter = float.Parse(ldCenterY.text);
                vignette.center.value = new Vector2(xCenter, yCenter);

                vignette.intensity.value = vigIntensity.value;
                vignette.smoothness.value = vigSmoothness.value;
                vignette.rounded.value = vigRounded.isOn;
            }
        }
    }
}
