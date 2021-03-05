using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketStatisitcsScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private Text fuelTextObject = null;

	[SerializeField]
	private Text thrustTextObject = null;

	[SerializeField]
	private Text distanceTextObject = null;

	[SerializeField]
	private Text velocityTextObject = null;

	[SerializeField]
	private Text highestDistanceTextObject = null;
	#endregion

	#region Variable Declarations
	private RocketScript rocket = null;

	private string fuelText = "Fuel: ";
	private string thrustText = "Thrust: ";
	private string distanceText = "Height: ";
	private string velocityText = "Velocity: ";
	private string highestDistanceText = "Highest: ";
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
		rocket = GameObject.FindGameObjectsWithTag("Rocket")[0].GetComponent<RocketScript>();
	}

	// Update is called once per frame
	void Update() {
		fuelTextObject.text = fuelText + rocket.GetFuelLevel() + " litres";
		thrustTextObject.text = thrustText + rocket.GetThrust() + " N";
		distanceTextObject.text = distanceText + rocket.GetDistanceTravelled() + " m";
		velocityTextObject.text = velocityText + rocket.GetCurrentVelocity() + " m/s";
		highestDistanceTextObject.text = highestDistanceText + rocket.GetHighestDistance() + " m";
	}
	#endregion

	#region Public Access Functions

	#endregion
}
