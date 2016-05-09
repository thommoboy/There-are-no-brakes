using UnityEngine;
using System.Collections;

public class P_GShot : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1.0f;
	private float nextFire = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
