﻿using UnityEngine;
using System.Collections;

public class M_AudioManager : MonoBehaviour
{
	public AudioClip Step;
	public AudioClip Jump;
	public AudioClip Winch;
	public AudioClip Platform;
	public AudioClip Gate;
	public AudioClip Anchor;
	public AudioClip GrappleShoot;
	public AudioClip GrappleAttach;

	public AudioClip AmbientMusic;

	public AudioSource SoundFXOutput;
	public AudioSource MusicOutput;

	private void Start()
	{
		MusicOutput.PlayOneShot (AmbientMusic);
	}
	//Call this function to play audio clips from the audio source
	/*
	 * for example
	 * AudioManager.PlayAudio("Step");
	 * 
	 */
	public void PlayAudio(string Clip)
	{
		if (Clip == "Step") {
			SoundFXOutput.clip = Step;
			SoundFXOutput.Play ();
		}
		else if (Clip == "Jump")
			SoundFXOutput.PlayOneShot (Jump);
		else if (Clip == "Winch")
			SoundFXOutput.PlayOneShot (Winch);
		else if (Clip == "Platform")
			SoundFXOutput.PlayOneShot (Platform);
		else if (Clip == "Gate")
			SoundFXOutput.PlayOneShot (Gate);
		else if (Clip == "Anchor")
			SoundFXOutput.PlayOneShot (Anchor);
		else if (Clip == "GrappleShoot")
			SoundFXOutput.PlayOneShot (GrappleShoot);
		else if (Clip == "GrappleShoot")
			SoundFXOutput.PlayOneShot (GrappleAttach);
		else
			Debug.LogError ("You done fucked up son");
	}
}