using UnityEditor;
using UnityEngine;

public class Import : EditorWindow
{
	private Mesh SourceObject;
	private Texture2D SourceTexture;

	private bool AddRigidbody = false;
	private bool NameExists = false;
	private bool MeshExists = false;
	private bool TextureExists = false;

	private string PrefabName = string.Empty;

	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(Import), false, "TANB Importer");
	}

	void OnGUI()
	{
		GUILayout.Label ("Mesh:", EditorStyles.boldLabel);

		SourceObject = EditorGUI.ObjectField (new Rect (3, 20, 100, 17), SourceObject, typeof(Mesh)) as Mesh;

		GUI.Label (new Rect (3, 138, 100, 17), "Texture:", EditorStyles.boldLabel);

		SourceTexture = EditorGUI.ObjectField (new Rect (3, 156, 82, 82), SourceTexture, typeof(Texture2D)) as Texture2D;

		EditorGUI.DrawRect(new Rect (105, 0, 5, 1000), Color.black);

		if(SourceObject != null)
			EditorGUI.DrawPreviewTexture (new Rect (3, 45, 82, 82), AssetPreview.GetAssetPreview(SourceObject));

		//Prefab Creation

		GUI.Label (new Rect (115, 4, 100, 17), "Texture:", EditorStyles.boldLabel);

		PrefabName = GUI.TextField(new Rect(115, 20, 100, 20), PrefabName);

		if(GUI.Button(new Rect(115, 42, 100, 20), "Create Prefab"))
		{
			if (PrefabName != "")
				NameExists = true;
			else
			{
				NameExists = false;
				Debug.LogError("No prefab name entered");
			}
			if (SourceObject != null)
				MeshExists = true;
			else
			{
				MeshExists = false;
				Debug.LogError("No Mesh entered");
			}
			if (SourceTexture != null)
				TextureExists = true;
			else
			{
				TextureExists = false;
				Debug.LogError("No Texture entered");
			}

			if(NameExists && MeshExists && TextureExists)
				CreatePrefab();
		}

		AddRigidbody = GUI.Toggle (new Rect (115, 62, 100, 20), AddRigidbody, "Add Rigidbody");
	}

	public void CreatePrefab()
	{
		GameObject go = new GameObject ("Test Prefab");
		go.AddComponent (typeof(MeshFilter));
		go.GetComponent<MeshFilter> ().mesh = SourceObject;
		go.AddComponent (typeof(MeshRenderer));
		//Test
		if(AddRigidbody)
			go.AddComponent(typeof(Rigidbody));
		Material material = new Material (Shader.Find("Specular"));
		material.mainTexture = SourceTexture;
		AssetDatabase.CreateAsset(material, "Assets/Materials/" + PrefabName + ".mat");
		go.GetComponent<MeshRenderer>().sharedMaterial = material;
		PrefabUtility.CreatePrefab("Assets/Prefabs/" + PrefabName + ".prefab", go);
		GameObject.DestroyImmediate(go);
		Debug.Log("Created Prefab");
	}
}