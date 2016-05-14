using UnityEngine;
using System.Collections;

public class P_GShot : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1.0f;
	private float nextFire = 0.0f;

	public GameObject Player1;
	public GameObject Player2;

	public Transform P1_Point;
	public Transform P2_Point;
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.S) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, P2_Point.position, P2_Point.rotation);
		}

		if(Input.GetKeyDown(KeyCode.DownArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, P1_Point.position, P1_Point.rotation);
		}
	}
}
