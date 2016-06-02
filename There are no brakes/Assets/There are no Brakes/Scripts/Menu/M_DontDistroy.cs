/***********************
 * M_DontDistroy.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class M_DontDistroy : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
