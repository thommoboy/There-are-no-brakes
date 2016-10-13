using UnityEngine;
using UnityEngine.SceneManagement;
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
			SceneManager.LoadScene ("Tutorial Level");
			return "loading " + levelname;
		}

		if(levelname == "Adventurer")
		{
			GConsole.Print ("loading " + levelname);
			SceneManager.LoadScene ("Adventurer Level");
			return "loading " + levelname;
		}

		if(levelname == "Industrial")
		{
			GConsole.Print ("loading " + levelname);
			SceneManager.LoadScene ("Industrial Level");
			return "loading " + levelname;
		}

		if(levelname == "Pyramid")
		{
			GConsole.Print ("loading " + levelname);
			SceneManager.LoadScene ("Pyramid Level");
			return "loading " + levelname;
		}

        return "Didn't understand your input, please enter a valid level name";
    }
}
