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
	private AudioSource bgm;
    private AudioSource audio;
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

        bgm = GameObject.Find("MusicFX").GetComponent<AudioSource>();
        audio = GameObject.Find("SoundFX").GetComponent<AudioSource>();
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        audioSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();

        reset();
	}

    public void reset() {
        //Debug.Log(PlayerPrefs.GetFloat("AudioVolume"));

        bgm.volume = PlayerPrefs.GetFloat("BGMVolume");
        audio.volume = PlayerPrefs.GetFloat("AudioVolume");
        musicSlider.value = bgm.volume;
        audioSlider.value = audio.volume;

        musicSlider.onValueChanged.AddListener(delegate {
            BGMSliderChangeCheck();
        });

        audioSlider.onValueChanged.AddListener(delegate {
            AudioSliderChangeCheck();
        });
    }

	// Update is called once per frame
	public void BGMSliderChangeCheck () {
		bgm.volume = musicSlider.value;
        float value = bgm.volume;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void AudioSliderChangeCheck()
    {
        audio.volume = audioSlider.value;
        float value = audio.volume;
        PlayerPrefs.SetFloat("AudioVolume", value);
        //Debug.Log(PlayerPrefs.GetFloat("AudioVolume"));
    }
}
