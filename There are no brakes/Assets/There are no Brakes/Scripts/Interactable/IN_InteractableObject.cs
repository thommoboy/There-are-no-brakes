/***********************
 * IN_InteractableObject.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_InteractableObject : MonoBehaviour
{
	public enum InteractableTypes
	{
		Winch = 1,
		BreakableWall = 2,
		WeightedObject = 3,
		TetherPoint = 4,
		SeeSaw = 5
	}

	public InteractableTypes IT = InteractableTypes.Winch;
}