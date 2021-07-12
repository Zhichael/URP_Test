using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickALight : MonoBehaviour
{
    public GameObject lightBtnHolder;
    public GameObject[] lights;
    public Image showHideBtnImage;
    public Sprite[] lightSprites;

    private int selectNum = -1;
    private bool lightOn = false;
    private bool isShowing = true;

    // Update is called once per frame
    void Update()
    {
        if(lightOn)
        {
            SwitchToLight();
        }
    }

    public void WhichLight(int light)
    {
        selectNum = light;
        lightOn = true;
    }
    public void ShowHideLightOptions()
    {
        if(isShowing)
        {
            lightBtnHolder.SetActive(true);
            showHideBtnImage.sprite = lightSprites[0];
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
            }
            lightOn = false;
            isShowing = false;
        }
        else
        {
            lightBtnHolder.SetActive(false);
            showHideBtnImage.sprite = lightSprites[1];
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
            }
            lightOn = false;
            isShowing = true;
        }
    }

    private void SwitchToLight()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            if(i == selectNum)
            {
                lights[i].SetActive(true);
            }
            else
            {
                lights[i].SetActive(false);
            }
        }
    }
}
