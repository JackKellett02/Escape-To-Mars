using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)

	#endregion

	#region Variable Declarations

	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region Public Access Functions (Getters and setters)
	public void Play() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit() {
		Application.Quit();
		Debug.Log("Quit Button Pressed");
	}
	#endregion
}
