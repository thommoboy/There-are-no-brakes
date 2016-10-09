using UnityEngine;
using System.Reflection;

[assembly:AssemblyVersion ("0.1.*")]
public class VersionNumber : MonoBehaviour{
    private bool ShowVersionInformation = false;

    Rect position = new Rect (0, 0, 150, 30);
    
    private string version;
    public string Version {
        get {
            if (version == null) {
                version = Assembly.GetExecutingAssembly ().GetName ().Version.ToString ();
            }
            return version;
        }
    }

    void Start (){
        DontDestroyOnLoad (this);
	    // Log current version in log file
        Debug.Log (string.Format ("Currently running version is {0}", Version));
	    position.y = 1f;
        position.x = Screen.width - position.width - 10f;

    }
	
	void Update(){
	// reveal version number if F2 is pressed
		if(Input.GetKeyDown(KeyCode.F2)){
			ShowVersionInformation = !ShowVersionInformation;
		}
	}

    void OnGUI (){
        if (!ShowVersionInformation) return;
    
        GUI.contentColor = Color.white;
        GUI.Box (position, string.Format ("v {0}", Version));
    }
}