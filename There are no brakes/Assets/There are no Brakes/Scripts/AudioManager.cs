using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public static void PlayAudio(GameObject soundDestination, AudioClip sound)
	{
		//Create the audio source
		AudioSource SD;
		SD = soundDestination.AddComponent (typeof(AudioSource)) as AudioSource;
		//Play the audio
		SD.PlayOneShot (sound);
		//Wait for the audio to finish then destroy the audio source
		Destroy (soundDestination.GetComponent<AudioSource> (), sound.length);
	}

	public static void PlayAudioSelf(AudioClip sound)
	{
		//Create the audio source

		Transform go = new GameObject ("sound").transform;
		go.parent = GameObject.Find("AudioManager").transform;
		AudioSource SD;
		SD = go.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
		//Play the audio
		SD.PlayOneShot (sound);
		//Wait for the audio to finish then destroy the audio source
		Destroy (go.GetComponent<AudioSource> (), sound.length);
	}
}