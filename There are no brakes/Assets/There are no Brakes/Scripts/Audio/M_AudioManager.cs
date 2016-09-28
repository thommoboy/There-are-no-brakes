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

	public AudioClip Ambience;
	public AudioClip MusicIntro;
	public AudioClip MusicNormalLoop;
	public AudioClip MusicUrgentLoop;
	
	public bool isTutorial = false;
	public bool isMenu = false;
	private bool musicIntroDone = false;
	/// <summary>
	/// Grab the objects that will play certain effects
	/// </summary>
	public AudioSource MusicOutput;
	public AudioSource MusicOutput2;
	
	private GameObject HUDscript;

	private void Start()
	{
		MusicOutput.PlayOneShot (MusicIntro);
		HUDscript = GameObject.Find("HUDmanager");
		MusicOutput.volume = 1;
		MusicOutput2.volume = 0;
		MusicOutput2.clip = MusicUrgentLoop;
		MusicOutput2.Stop ();
	}

	private void Update(){
		// play intro then go into the loops
		if(!isTutorial && !MusicOutput.isPlaying && !musicIntroDone){
			MusicOutput.loop = true;
			MusicOutput2.loop = true;
			MusicOutput.clip = MusicNormalLoop;
			MusicOutput.Play();
			MusicOutput2.Play();
			musicIntroDone = true;
		}
		// if running out of time music becomes more urgent, time remaining as a precentage of the HUD bar
		if(!isTutorial && musicIntroDone && HUDscript.GetComponent<P_HUD> ().barDisplay2 < 0.35f){
			if(MusicOutput2.volume < 1){
				MusicOutput.volume -= 0.1f * Time.deltaTime;
				MusicOutput2.volume += 0.1f * Time.deltaTime;
			}
		}
	}

	/*
	/// <summary>
	/// Call this function to play audio clips from the audio source
	/// for example
	/// AudioManager.PlayAudio("Step");
	/// </summary>
	public void PlayAudio(string Clip)
	{
		if (SoundFXOutput.isPlaying) {
			return;
		}
		if (Clip == "Step" && SoundFXOutput.clip != Step) {
			//Debug.Log ("test");
            SoundFXOutput.clip = Step;
        } else if (Clip == "Jump") {
            SoundFXOutput.PlayOneShot(Jump);
        } else if (Clip == "Winch") {
            SoundFXOutput.PlayOneShot(Winch);
        } else if (Clip == "Platform") {
            SoundFXOutput.PlayOneShot(Platform);
        } else if (Clip == "Gate") {
            SoundFXOutput.PlayOneShot(Gate);
        } else if (Clip == "Anchor") {
            SoundFXOutput.PlayOneShot(Anchor);
        } else if (Clip == "GrappleShoot") {
            SoundFXOutput.PlayOneShot(GrappleShoot);
        } else if (Clip == "MenuSwitch") {
			SoundFXOutput.PlayOneShot(MenuSwitch);
            //SoundFXOutput.PlayOneShot(MenuSwitch);
        } else if (Clip == "LevelComplete")  {
            SoundFXOutput.PlayOneShot(LevelComplete);
        } else if (Clip == "GameOver")  {
			MusicOutput.Stop ();
			MusicOutput2.Stop ();
            SoundFXOutput.PlayOneShot(GameOver);
        }

        else {
			//Debug.LogError ("Looks like you tried to play a sound that doesn't exist");
		}
		if(!SoundFXOutput.isPlaying){
			SoundFXOutput.Play();
			//SoundFXOutput.PlayOneShot(SoundFXOutput.clip);
		}
	}
		
	public void stopPlaying(){
		//Debug.Log ("stop playing");
		SoundFXOutput.Stop ();
	}

	public void switchPlayerWalking(int playerIndex, bool f){
		if (playerIndex == 1)
			player1Waling = f;
		if (playerIndex == 2)
			player2Waling = f;
		if (playerIndex == 3)
			player3Waling = f;
		if (player1Waling || player2Waling || player3Waling) {
			//Debug.Log (player1Waling + " " + player2Waling + " " + player3Waling);
			PlayAudio ("Step");
		} else {
			if (SoundFXOutput.clip == Step)
				SoundFXOutput.Stop ();
		}
			
	}
	*/

	// Static calls for playing audio

	public static void PlayAudio(GameObject soundDestination, AudioClip sound)
	{
		//Create the audio source
		AudioSource SD;
		SD = soundDestination.AddComponent (typeof(AudioSource)) as AudioSource;
		//Play the audio
		SD.PlayOneShot (sound);
		//Wait for the audio to finish then destroy the audio source
		Destroy (soundDestination, sound.length);
	}

	public static void PlayAudioSelf(AudioClip sound)
	{
		//check if sound is already in use
		bool used = false;
		foreach (Transform child in GameObject.Find("AudioManager").transform)
		{
			if(sound.name == child.name){
				used = true;
			}
		}
		if(!used){
			//Create the audio source
			Transform go = new GameObject (sound.name).transform;
			go.parent = GameObject.Find("AudioManager").transform;
			AudioSource SD;
			SD = go.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
			//Play the audio
			SD.PlayOneShot (sound);
			//Wait for the audio to finish then destroy the audio source
			Destroy (go.gameObject, sound.length);
		}
	}

	public static void StopAudio(AudioClip sound)
	{
		//stop sound if already in use
		foreach (Transform child in GameObject.Find("AudioManager").transform)
		{
			if(sound.name == child.name){
				Destroy (child.gameObject, 0.001f);
			}
		}
	}
}