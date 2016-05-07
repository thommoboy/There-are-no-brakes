using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// Camera multitarget editor, 
/// Custom inspector for the camera multitarget component.
/// </summary>
[CustomEditor( typeof(CameraMultitarget))]
public class CameraMultitargetEditor : Editor {
	
	
	private bool positionParams = true;
	private bool movementParams = true;
	private bool rotationParams = true;
	private bool extraParams = true;
	
	/// <summary>
	/// Raises the inspector GUI Event.
	/// </summary>
    public override void OnInspectorGUI() {
		CameraMultitarget myTarget = (CameraMultitarget) target;
		
		// we edit the camera movement parameters.
       	movementParams = EditorGUILayout.Foldout(movementParams, "Movement Settings");
       	if(movementParams) {
			myTarget.minDistanceToTarget = EditorGUILayout.FloatField("Minimum Distance", myTarget.minDistanceToTarget);
			myTarget.maxDistanceToTarget = EditorGUILayout.FloatField("Maximum Distance", myTarget.maxDistanceToTarget);

       	}

		rotationParams = EditorGUILayout.Foldout(rotationParams, "Movement Settings");
		if (rotationParams)
		{
			myTarget.orbitRotation.x = EditorGUILayout.FloatField("Orbit X", myTarget.orbitRotation.x);
			myTarget.orbitRotation.y = EditorGUILayout.FloatField("Orbit Y", myTarget.orbitRotation.y);
			myTarget.orbitRotation.z = EditorGUILayout.FloatField("Orbit Z", myTarget.orbitRotation.z);
		}
		
		// we edit the advanced values for the interpolation and safe area.
		extraParams = EditorGUILayout.Foldout(extraParams, "Advanced Settup");
       	if(extraParams) {
			myTarget.targetInterpolationSpeed = EditorGUILayout.FloatField("Target Interpolation Speed", myTarget.targetInterpolationSpeed);						
			myTarget.positionInterpolationSpeed = EditorGUILayout.FloatField("Position Interpolation Speed", myTarget.positionInterpolationSpeed);						
			EditorGUILayout.PrefixLabel("Screen Safe Area");			
			myTarget.screenSafeArea = EditorGUILayout.Slider(myTarget.screenSafeArea, -100, 100);									
       	}
    }
}
