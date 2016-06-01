/***********************
 * M_MusicVolumeScript.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M_MusicVolumeScript : MonoBehaviour {
	public Slider musicSlider;
	private AudioSource bgm;
	// Use this for initialization
	void Start () {
		bgm = GetComponent<AudioSource> ();
		musicSlider.value = bgm.volume;
		musicSlider.onValueChanged.AddListener (delegate {
			SliderChangeCheck ();
		});
	}

	// Update is called once per frame
	void SliderChangeCheck () {
		bgm.volume = musicSlider.value;
	}
}
