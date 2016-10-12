using UnityEngine;
using System.Collections;

public class SetGraphics : MonoBehaviour
{
	//public float light = 0;
    // Use this for initialization
    void Start()
    {
        setOption();
    }

    // Update is called once per frame
    void Update()
    {
		//setLight (light);
    }

    void setLight(float value)
    {
        //GameObject.Find("Directional ight").GetComponent<Light>().intensity = value;
       // PlayerPrefs.SetFloat("Light", value);
		//PlayerPrefs.SetFloat("Light", light);
    }

//    float getLight()
//    {
//        return PlayerPrefs.GetFloat("Light");
//    }

    void setTextureQuality(int value)
    {
        QualitySettings.masterTextureLimit = 3 - (int)value;
        PlayerPrefs.SetInt("TextureQuality", value);
    }

//    int getTextureQuality()
//    {
//        return PlayerPrefs.GetInt("TextureQuality");
//    }

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

//    int getAnisotropicFiltering()
//    {
//        return PlayerPrefs.GetInt("AnisotropicFiltering");
//    }

    void setVsync(int value)
    {
        QualitySettings.vSyncCount = value;
        PlayerPrefs.SetFloat("Vsync", value);
    }

//    int getVsync()
//    {
//        return PlayerPrefs.GetInt("Vsync");
//    }


    public void setOption()
    {
        //light
        float Value;
//        if (PlayerPrefs.HasKey("Light"))
//            setLight(PlayerPrefs.GetFloat("Light"));
        //TextureQuality
        if (PlayerPrefs.HasKey("TextureQuality"))
            QualitySettings.masterTextureLimit = 3 - PlayerPrefs.GetInt("TextureQuality");
        //AnisotropicFiltering
        if (PlayerPrefs.HasKey("AnisotropicFiltering"))
        {
            Value = PlayerPrefs.GetFloat("AnisotropicFiltering");
            if ((int)Value == 1)
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
            }
            else
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            }
        }

        //Vsync
        if (PlayerPrefs.HasKey("Vsync"))
            QualitySettings.vSyncCount = (int)PlayerPrefs.GetFloat("Vsync");
    }
}
