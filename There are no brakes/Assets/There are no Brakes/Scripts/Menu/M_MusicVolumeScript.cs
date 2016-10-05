/***********************
 * M_ClickPlay.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M_MusicVolumeScript : MonoBehaviour {
	private Slider musicSlider;
    private Slider audioSlider;
	//private AudioSource bgm;
    //private AudioSource audio;
	// Use this for initialization
	void Start () {
        if (!GameObject.Find("MusicSlider"))
        {
            Debug.Log("music slider is not exist");
        }
        if (!GameObject.Find("SoundSlider"))
        {
            Debug.Log("Sound slider is not exist");
        }
		
        //bgm = GameObject.Find("MusicFX").GetComponent<AudioSource>();
        //audio = GameObject.Find("SoundFX").GetComponent<AudioSource>();
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        audioSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();

        reset();
	}

    public void reset() {
        //Debug.Log(PlayerPrefs.GetFloat("AudioVolume"));

        //bgm.volume = PlayerPrefs.GetFloat("BGMVolume");
        //GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume");
        musicSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        audioSlider.value = PlayerPrefs.GetFloat("AudioVolume");

        musicSlider.onValueChanged.AddListener(delegate {
            BGMSliderChangeCheck();
        });

        audioSlider.onValueChanged.AddListener(delegate {
            AudioSliderChangeCheck();
        });
    }

	// Update is called once per frame
	public void BGMSliderChangeCheck () {
		//bgm.volume = musicSlider.value;
        float value = musicSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void AudioSliderChangeCheck()
    {
        //GetComponent<AudioSource>().volume = audioSlider.value;
        float value = audioSlider.value;
        PlayerPrefs.SetFloat("AudioVolume", value);
        //Debug.Log(PlayerPrefs.GetFloat("AudioVolume"));
    }

    public void changeVoiceValue(string sliderName, float value) {
        float temp = 0;

        if (sliderName == "MusicSlider")
            temp = PlayerPrefs.GetFloat("BGMVolume");
        else if (sliderName == "SoundSlider")
            temp = PlayerPrefs.GetFloat("AudioVolume");

        if (value > 0)
        {
            temp = Mathf.Min(1.0f , temp + value);
        }
        else if (value < 0) {
            temp = Mathf.Max(0.0f, temp + value);
        }

        if (sliderName == "MusicSlider")
            PlayerPrefs.SetFloat("BGMVolume",temp);
        else if (sliderName == "SoundSlider")
            PlayerPrefs.SetFloat("AudioVolume", temp);

        musicSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        audioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
    }
}
