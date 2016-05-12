using UnityEngine;
using System.Collections;

public class I_TriggerGate : MonoBehaviour
{
	public bool Triggered = false;
	public GameObject Gate;
	public float StopHeight = -2;

	void Update ()
	{
		if(Triggered)
		{
			if (Gate.transform.localPosition.y >= StopHeight)
			{
				Vector3 platpos = Gate.transform.localPosition;
				platpos.y -= 1.5f;
				Gate.transform.localPosition = Vector3.Lerp (Gate.transform.localPosition, platpos, Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Triggered = true;
		}
	}
}
