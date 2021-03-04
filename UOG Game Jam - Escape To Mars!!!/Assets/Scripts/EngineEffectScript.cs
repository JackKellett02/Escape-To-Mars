using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEffectScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private GameObject particleEffectObject = null;

	[SerializeField]
	private GameObject audioObject = null;
	#endregion

	#region Public Access Functions (Getters and setters)
	public void ActivateThrusterEffects() {
		particleEffectObject.SetActive(true);
		audioObject.SetActive(true);
	}

	public void DeactivateThrusterEffects() {
		particleEffectObject.SetActive(false);
		audioObject.SetActive(false);
	}
	#endregion
}
