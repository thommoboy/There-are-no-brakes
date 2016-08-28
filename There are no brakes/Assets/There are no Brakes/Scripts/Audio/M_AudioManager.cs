/***********************
 * M_AudioManager.cs
 * Originally Written by Pierce Thompson
 * Modified By:
	Nathan Brown: bugfixing
 ***********************/
using UnityEngine;
using System.Collections;

public class M_AudioManager : MonoBehaviour
{
	/// <summary>
	/// Store all the possible sounds
	/// </summary>
	public AudioClip Step;
	public AudioClip Jump;
	public AudioClip Winch;
	public AudioClip Platform;
	public AudioClip Gate;
	public AudioClip Anchor;
	public AudioClip GrappleShoot;
	public AudioClip GrappleAttach;

	public AudioClip AmbientMusic;
	/// <summary>
	/// Grab the objects that will play certain effects
	/// </summary>
	public AudioSource SoundFXOutput;
	public AudioSource MusicOutput;

	private void Start()
	{
		MusicOutput.PlayOneShot (AmbientMusic);
	}
	/// <summary>
	/// Call this function to play audio clips from the audio source
	/// for example
	/// AudioManager.PlayAudio("Step");
	/// </summary>
	public void PlayAudio(string Clip)
	{
		if (Clip == "Step") {
			SoundFXOutput.clip = Step;
		} else if (Clip == "Jump"){
			SoundFXOutput.PlayOneShot (Jump);
		} else if (Clip == "Winch"){
			SoundFXOutput.PlayOneShot (Winch);
		} else if (Clip == "Platform"){
			SoundFXOutput.PlayOneShot (Platform);
		} else if (Clip == "Gate"){
			SoundFXOutput.PlayOneShot (Gate);
		} else if (Clip == "Anchor"){
			SoundFXOutput.PlayOneShot (Anchor);
		} else if (Clip == "GrappleShoot"){
			SoundFXOutput.PlayOneShot (GrappleShoot);
		} else if (Clip == "GrappleShoot"){
			SoundFXOutput.PlayOneShot (GrappleAttach);
		} else {
			Debug.LogError ("Looks like you tried to play a sound that doesn't exist");
		}
		if(!SoundFXOutput.isPlaying){
			SoundFXOutput.Play ();
		}
	}
}