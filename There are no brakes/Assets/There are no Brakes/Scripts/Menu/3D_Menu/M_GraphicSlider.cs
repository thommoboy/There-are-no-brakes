﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M_GraphicSlider : MonoBehaviour {
    public bool hasGraphicSlider;
    private Slider slider;
    protected Camera cam;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        if (hasGraphicSlider)
        {
            getValue(this.transform.parent.gameObject.name);
            slider = this.GetComponent<Slider>();
            slider.onValueChanged.AddListener(delegate
            {
                onValueChanged(this.transform.parent.gameObject.name);
            });
            lastChangeTime = Time.realtimeSinceStartup;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}

    void setResolution(int value) {
        switch (value) {
            case 0:
                Screen.SetResolution(1920, 1200, Screen.fullScreen);
                GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1920 X 1200";
                Debug.Log("set resolution to 1920*1200");
                break;
            case 1:
                Screen.SetResolution(1680, 1050, Screen.fullScreen);
                GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1680 X 1050";
                Debug.Log("set resolution to 1680*1050");
                break;
            case 2:
                Screen.SetResolution(1400, 900, Screen.fullScreen);
                GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1400 X 900";
                Debug.Log("set resolution to 1400*900");
                break;
            case 3:
                Screen.SetResolution(1280, 800, Screen.fullScreen);
                GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1280 X 800";
                Debug.Log("set resolution to 1280*800");
                break;
            case 4:
                Screen.SetResolution(1024, 576, Screen.fullScreen);
                GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1024 X 576";
                Debug.Log("set resolution to 1024*576");
                break;
            default:
                Debug.Log("this resolution is not in list");
                break;  
        }
        PlayerPrefs.SetFloat("Resolution", value);
    }

    Resolution[] getResolution() {
        return Screen.resolutions;
    }

    void setLight(float value) {
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = value;
        PlayerPrefs.SetFloat("Light", value);
    }

    float getLight() {
        return PlayerPrefs.GetFloat("Light");
    }

    void setTextureQuality(int value) {
        QualitySettings.masterTextureLimit = 3 - (int)value;
        PlayerPrefs.SetInt("TextureQuality", value);
    }

    int getTextureQuality() {
        return PlayerPrefs.GetInt("TextureQuality");
    }

    void setAnisotropicFiltering(int value)
    {
        if (value == 1)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }
        else
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }
        PlayerPrefs.SetInt("AnisotropicFiltering", value);
    }

    int getAnisotropicFiltering()
    {
        return PlayerPrefs.GetInt("AnisotropicFiltering");
    }

    void setVsync(int value)
    {
        QualitySettings.vSyncCount = value;
        PlayerPrefs.SetFloat("Vsync", value);
    }

    int getVsync()
    {
        return PlayerPrefs.GetInt("Vsync");
    }

    int getFullScreen() {
        if (Screen.fullScreen)
            return 1;
        else
            return 0;
    }

    void setFullScrren(bool value) {
        Screen.fullScreen = true;
    }


    private void onValueChanged(string optionName) {
        float Value = this.GetComponent<Slider>().value;
        switch (optionName)
        {
            case "Resolution":
                setResolution((int)Value);
                break;
            case "FullScreen":
                //cam.fieldOfView = Value * 100;
                setFullScrren((int)Value == 1);
                break;
            case "TextureQuality":
                setTextureQuality((int)Value);
                break;
            case "AnisotropicFiltering":
                setAnisotropicFiltering((int)Value);
                break;
            case "Vsync":
                setVsync((int)Value);
                break;
            default:
                break;
        }
    }

    private float lastChangeTime;
    private float gap = 0.5f;
    public void changeValue(string sliderName, float value) {
        if (slider.wholeNumbers) {
            if (value > 0)
                value = 1;
            else
                value = -1;

            if (Time.realtimeSinceStartup < (lastChangeTime + gap))
            {
                value = 0;
            }
            else {
                lastChangeTime = Time.realtimeSinceStartup;
            }

        }

        float temp = this.GetComponent<Slider>().value;

        if (value > 0)
        {
            temp = Mathf.Min(slider.maxValue, temp + value);
        }
        else if (value < 0)
        {
            temp = Mathf.Max(slider.minValue, temp + value);
        }

        this.GetComponent<Slider>().value = temp;

    }

    private void getValue(string optionName) {
        switch (optionName)
        {
            case "Resolution":
                if (Screen.resolutions[0].width != 1920 && Screen.resolutions[0].height != 1200) {
                    Screen.SetResolution(1920, 1200, Screen.fullScreen);
                    GameObject.Find("ResolutionText").GetComponent<TextMesh>().text = "1920 X 1200";
                }
                    
                break;
            case "FullScreen":
                if (PlayerPrefs.HasKey("FullScreen"))
                    this.GetComponent<Slider>().value = getFullScreen();
                else
                {
                    if (Screen.fullScreen)
                        this.GetComponent<Slider>().value = 1;
                    else
                        this.GetComponent<Slider>().value = 0;
                }
                break;
         
            case "TextureQuality":
                if (PlayerPrefs.HasKey("TextureQuality"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetInt("TextureQuality");
                else
                    this.GetComponent<Slider>().value = 3 - QualitySettings.masterTextureLimit;
                break;
            case "AnisotropicFiltering":
                if (PlayerPrefs.HasKey("AnisotropicFiltering"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("AnisotropicFiltering");
                else {
                    if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.ForceEnable)
                        this.GetComponent<Slider>().value = 1;
                    else
                        this.GetComponent<Slider>().value = 0;
                }
                break;
            case "Vsync":
                if (PlayerPrefs.HasKey("Vsync"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Vsync");
                else
                    this.GetComponent<Slider>().value = QualitySettings.vSyncCount;
                break;
            default:
                break;   
        }
    

    }
}
