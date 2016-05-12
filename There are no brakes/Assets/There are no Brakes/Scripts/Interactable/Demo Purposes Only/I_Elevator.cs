using UnityEngine;
using System.Collections;

public class I_Elevator : MonoBehaviour
{
	public bool Raise = false;
	public GameObject Elevator;
	public float StopHeight = 5;

	void Update()
	{
		if(Raise)
		{
			if(Elevator.transform.localPosition.y <= StopHeight)
			{
				RaiseElevator();
			}
		}
	}

	private void RaiseElevator()
	{
		Vector3 platpos = Elevator.transform.localPosition;
		platpos.y += 1.5f;
		Elevator.transform.localPosition = Vector3.Lerp(Elevator.transform.localPosition, platpos, Time.deltaTime);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			Raise = true;
		}
	}
}