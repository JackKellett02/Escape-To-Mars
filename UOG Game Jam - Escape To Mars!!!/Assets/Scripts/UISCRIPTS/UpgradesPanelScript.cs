using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesPanelScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private Text coinsTextObject = null;
	#endregion

	#region Variable Declarations
	private string coinsText = "Coins: ";
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		coinsTextObject.text = coinsText + RocketScript.GetCoins();
	}
	#endregion

	#region Public Access Functions

	#endregion
}
