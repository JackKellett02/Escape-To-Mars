using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
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
	public void UpdateTransformPosition(Vector3 cameraPos) {
		gameObject.transform.localPosition = cameraPos;
	}
	#endregion
}
