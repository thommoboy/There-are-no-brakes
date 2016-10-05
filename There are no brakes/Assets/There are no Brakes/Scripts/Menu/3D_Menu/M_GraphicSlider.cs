using UnityEngine;
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
        else {
            setOption();
        }
        
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void onValueChanged(string optionName) {
        saveValue(optionName);
        float Value = this.GetComponent<Slider>().value;
        switch (optionName)
        {
            case "FieldOfView":
                cam.fieldOfView = Value * 100;
                break;
            case "TextureQuality":
                QualitySettings.masterTextureLimit = 3 - (int)Value;
                break;
            case "AnisotropicFiltering":
                if ((int)Value == 1)
                {
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                }
                else
                {
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                }
                break;
            case "Vsync":
                QualitySettings.vSyncCount = (int)Value;
                break;
            case "ShadowDistance":
                QualitySettings.shadowDistance = (int)(Value * 100);
                break;
            default:
                break;
        }
    }

    private void setOption() {
        float Value = PlayerPrefs.GetFloat("FieldOfView");
        cam.fieldOfView = Value * 100;

        Value  = PlayerPrefs.GetFloat("TextureQuality");
        QualitySettings.masterTextureLimit = 3 - (int)Value;

        Value = PlayerPrefs.GetFloat("AnisotropicFiltering");
        if ((int)Value == 1)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }
        else
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        Value = PlayerPrefs.GetFloat("Vsync");
        QualitySettings.vSyncCount = (int)Value;

        Value = PlayerPrefs.GetFloat("ShadowDistance");
        QualitySettings.shadowDistance = (int)(Value * 100);
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

    private void saveValue(string optionName) {
        switch (optionName)
        {
            case "FieldOfView":
                PlayerPrefs.SetFloat("FieldOfView", this.GetComponent<Slider>().value);
                break;
            case "TextureQuality":
                PlayerPrefs.SetFloat("TextureQuality", this.GetComponent<Slider>().value);
                break;
            case "AnisotropicFiltering":
                PlayerPrefs.SetFloat("AnisotropicFiltering", this.GetComponent<Slider>().value);
                break;
            case "Vsync":
                PlayerPrefs.SetFloat("Vsync", this.GetComponent<Slider>().value);
                break;
            case "ShadowDistance":
                PlayerPrefs.SetFloat("ShadowDistance", this.GetComponent<Slider>().value);
                break;
            default:
                break;
        }
    }

    private void getValue(string optionName) {
        switch (optionName)
        {
            case "FieldOfView":
                if (PlayerPrefs.HasKey("FieldOfView"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FieldOfView");
                else
                    this.GetComponent<Slider>().value = cam.fieldOfView / 100f;
                break;
            case "TextureQuality":
                if (PlayerPrefs.HasKey("TextureQuality"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("TextureQuality");
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
            case "ShadowDistance":
                if (PlayerPrefs.HasKey("ShadowDistance"))
                    this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ShadowDistance");
                else
                    this.GetComponent<Slider>().value = QualitySettings.shadowDistance / 100f;
                break;
            default:
                break;   
        }
    

    }
}
