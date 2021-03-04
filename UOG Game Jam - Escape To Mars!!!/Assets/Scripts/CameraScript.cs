using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private float rotationAmount = 5.0f;

	[SerializeField]
	private float zoomAmount = 5.0f;

	[SerializeField]
	private float cameraDistance = 24.0f;

	[SerializeField]
	private GameObject cameraObject = null;
	#endregion

	#region Variable Declarations
	private GameObject rocketObject = null;

	private Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	private Vector3 cameraPos;
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
		rocketObject = GameObject.FindGameObjectsWithTag("Rocket")[0];
		cameraPos = new Vector3(0.0f, 0.0f, -cameraDistance);
		UpdateTransforms();
	}

	// Update is called once per frame
	void Update() {
		if (rocketObject.GetComponent<RocketScript>().GetHasLaunched()) {
			//Take input if the rocket has launched.
			HandlePlayerInput();
		}
		UpdateTransforms();
	}

	private void UpdateTransforms() {
		cameraObject.GetComponent<MainCameraScript>().UpdateTransformPosition(cameraPos);
		gameObject.transform.rotation = rotation;
	}

	private void HandlePlayerInput() {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			rotation.y -= rotationAmount * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			rotation.y += rotationAmount * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			cameraPos.z += zoomAmount * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			cameraPos.z -= zoomAmount * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			cameraPos.z = -cameraDistance;
			rotation.y = 0.0f;
		}
		cameraPos.z = Mathf.Clamp(cameraPos.z, -50.0f, -10.0f);
	}
	#endregion

	#region Public Access Functions (Getters and setters)

	#endregion
}
