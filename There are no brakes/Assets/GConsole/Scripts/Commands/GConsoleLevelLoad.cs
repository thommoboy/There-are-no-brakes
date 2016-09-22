using UnityEngine;
using System.Collections;

/// <summary>
/// Adds a level load option to the command console.
/// </summary>
public class GConsoleLevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GConsole.AddCommand("load", "Loads the specified level", 
            ChangeLevel, 
            "Usage: load [Level Name]\nExample \"load Industrial\" loads the industrialist level");
	}

	string ChangeLevel(string levelname)
    {
		if (string.IsNullOrEmpty(levelname))
        {
            return "current level: " + AudioListener.volume;
        }
			
		if(levelname == "Tutorial")
		{
			GConsole.Print ("loading " + levelname);
			Application.LoadLevel ("Tutorial Level");
			return "loading " + levelname;
		}

		if(levelname == "Adventurer")
		{
			GConsole.Print ("loading " + levelname);
			Application.LoadLevel ("Adventurer Level");
			return "loading " + levelname;
		}

		if(levelname == "Industrial")
		{
			GConsole.Print ("loading " + levelname);
			Application.LoadLevel ("Industrial Level");
			return "loading " + levelname;
		}

		if(levelname == "Pyramid")
		{
			GConsole.Print ("loading " + levelname);
			Application.LoadLevel ("Pyramid Level");
			return "loading " + levelname;
		}

        return "Didn't understand your input, please enter a valid level name";
    }
}
