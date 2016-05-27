using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M_ClickPlay : MonoBehaviour {
	public Slider loadingBar;
	public  GameObject loadingImage;
	private int level;
	private AsyncOperation async;

	public void ClickAsync(int level){
		this.level = level;
		GameObject.Find ("MenuButtonManager").GetComponent<M_3DMenuButton> ().started = true;
		StartCoroutine ("delayExecute");

	}

	IEnumerator LoadLevel(int level)
	{
		async = Application.LoadLevelAsync (level);
		while (!async.isDone) {
			loadingBar.value = async.progress;
			yield return null;
		}

	}

	IEnumerator delayExecute(){
		//print (Time.time);
		yield return new WaitForSeconds (5);
		loadingImage.SetActive (true);
		StartCoroutine (LoadLevel (level));

		//print (Time.time);
	}

}
