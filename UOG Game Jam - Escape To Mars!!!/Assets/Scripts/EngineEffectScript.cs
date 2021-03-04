using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEffectScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private GameObject particleEffectObject = null;
	#endregion

	#region Public Access Functions (Getters and setters)
	public void ActivateParticleEffect() {
		particleEffectObject.SetActive(true);
	}

	public void DeactivateParticleEffect() {
		particleEffectObject.SetActive(false);
	}
	#endregion
}
