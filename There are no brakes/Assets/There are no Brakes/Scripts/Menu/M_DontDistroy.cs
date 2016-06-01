/***********************
 * M_DontDistroy.cs
 * Originally Written by 
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
