using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class M_3D_OnMouseOver : MonoBehaviour {
	Vector3 ori_Scale;
	public Slider loadingBar;
	public  GameObject loadingImage;
	private AsyncOperation async;
	// Use this for initialization
	void Start () {
		ori_Scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		GameObject hitThing;
		if (Physics.Raycast (ray, out hit, 1000.00f)) {
			hitThing = hit.collider.gameObject;
			if (hitThing == this.gameObject) {
				transform.localScale = ori_Scale * 1.3f;
				if (tag == "MenuButton")
					return;
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
					//ClickAsync (1);
					StartCoroutine(delayExecute(1));
				}
			} else {
				transform.localScale = ori_Scale;
			}
		} 
	}

	public void ClickAsync(int level){
		loadingImage.SetActive (true);
		StartCoroutine (LoadLevel (level));
	}

	IEnumerator LoadLevel(int level)
	{
		async = Application.LoadLevelAsync (level);
		while (!async.isDone) {
			loadingBar.value = async.progress;
			yield return null;
		}

	}

	IEnumerator delayExecute(int level){
		//print (Time.time);
		GameObject.Find ("MenuButtonManager").GetComponent<M_3DMenuButton> ().started = true;
		yield return new WaitForSeconds (1);
		GameObject.Find("Paper_box").GetComponent<M_MenuPaperBox>().animator.enabled = true;
		yield return new WaitForSeconds (3);
		ClickAsync (level);
		//print (Time.time);
	}



}
