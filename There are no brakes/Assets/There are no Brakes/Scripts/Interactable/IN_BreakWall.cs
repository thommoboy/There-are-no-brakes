/***********************
 * IN_BreakWall.cs
 * Originally Written by Feng
 * Modified By: Nathan Brown
 * Modificaions:
	Nathan Brown: interaction with heavy weight object
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_BreakWall : MonoBehaviour
{
	public GameObject remains;
	public GameObject sphereCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown(KeyCode.Space)) {
			GameObject.Instantiate (remains, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}*/
	}



	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Weight") {
			GameObject wall = GameObject.Instantiate(remains, this.transform.position, this.transform.rotation) as GameObject;
			wall.transform.localScale =new Vector3(this.transform.localScale.x / (float)4.5, this.transform.localScale.y / (float)3.5, this.transform.localScale.z);
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 200);
			Destroy (this.gameObject);
			other.gameObject.GetComponent<Rigidbody> ().mass = 1000;
			/*
			Rigidbody rigid = other.gameObject.GetComponent<Rigidbody> ();
			Vector3 direction = rigid.velocity;
			//print(direction);
			//direction = getBasicDirectionUnit (direction);
			print(direction);
			direction.z = Mathf.Abs (direction.z);
			print (other.gameObject.name);

			GameObject wallSphereCollider = GameObject.Instantiate (sphereCollider, other.transform.position + direction * (float)7
				, other.transform.rotation) as GameObject;
			*/
			//float size = 3f;
			//wallSphereCollider.transform.localScale.Set (wallSphereCollider.transform.localScale.x*size, wallSphereCollider.transform.localScale.y*size, wallSphereCollider.transform.localScale.z);

			Destroy (wall, (float)4);
			//Destroy (wallSphereCollider, (float)4);

			//print ("succses");

		}
	}

	Vector3 getBasicDirectionUnit(Vector3 temp){
		if ((int)temp.x != 0) {
			temp.x = temp.x / Mathf.Abs (temp.x);
		}
		if ((int)temp.y != 0) {
			temp.y = temp.y / Mathf.Abs (temp.y);
		}
		if ((int)temp.z != 0) {
			temp.z = temp.z / Mathf.Abs (temp.z);
		}
		return temp;
	}
}
