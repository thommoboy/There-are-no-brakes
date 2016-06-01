using UnityEngine;
using System.Collections;

public class M_DontDistroy : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
