using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTextScript : MonoBehaviour {
	private void Awake() {
		StartCoroutine("ControlsTextTimer");
	}

	private IEnumerator ControlsTextTimer() {
		yield return new WaitForSeconds(4.0f);
		gameObject.SetActive(false);
	}
}
