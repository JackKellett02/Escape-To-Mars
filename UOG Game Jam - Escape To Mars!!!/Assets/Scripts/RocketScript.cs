using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private int numberOfThrusters = 1;

	[SerializeField]
	private float rocketMass = 10.0f;

	[SerializeField]
	private float cameraDistance = 15.0f;

	[SerializeField]
	private float maxFuelLevel = 100.0f;

	[SerializeField]
	private float powerOfThruster = 196.2f;
	#endregion

	#region Variable Declarations
	private Vector2 cameraPos;

	private GameObject cameraObject = null;
	private GameObject[] engineObjects = null;

	private bool launched = false;
	private bool hasFuel = true;
	private bool engineEffectsOn = false;

	private static float highestDistanceTravelled = 0.0f;
	private float distanceTravelled = 0.0f;
	private float velocity = 0.0f;
	private float currentFuelLevel = 0.0f;

	private float totalMass = 0.0f;
	private float rocketThrust = 0.0f;
	private float rocketFuelConsumption = 0.0f;

	//Gravity stuff.
	private float gravity = 9.81f;
	private float massOfEarth = 5.972f * (Mathf.Pow(10.0f, 24.0f));
	private float radiusAtSeaLevel = (6378.137f * 1000);
	private float gravitationalConstant = 6.67408f * (Mathf.Pow(10.0f, -11.0f));
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
		cameraPos = new Vector2(0.0f, -cameraDistance);

		ResetRocketFuel();
		CalculateGravity();

		//Add Fuel to rocket mass.
		totalMass = rocketMass + (currentFuelLevel * 0.81715f);

		CalculateFuelConsumptionRate();
		rocketThrust = powerOfThruster * numberOfThrusters;
		engineObjects = GameObject.FindGameObjectsWithTag("Engine");
		cameraObject = GameObject.FindGameObjectsWithTag("MainCamera")[0];
		UpdateCameraPosition();
	}

	// Update is called once per frame
	void Update() {
		UpdateCameraPosition();
		CalculateGravity();

		//Add Fuel to rocket mass.
		totalMass = rocketMass + (currentFuelLevel * 0.81715f);

		//Check Fuel Level.
		hasFuel = CheckIfRocketHasFuel();
		if (launched && hasFuel) {
			//Turn on engine effect.
			if (!engineEffectsOn) {
				TurnOnRocketParticleEffects();
				engineEffectsOn = true;
			}

			//Move.
			AccelerateDueToGravity();
			AccelerateDueToThrusters();
			Move();
			if (distanceTravelled > highestDistanceTravelled) {
				highestDistanceTravelled = distanceTravelled;
			}

			//Remove Fuel from Tanks.
			CalculateFuelConsumed();
		} else if (launched && !hasFuel) {
			//Turn off engine effect.
			if (engineEffectsOn) {
				TurnOffRocketParticleEffects();
				engineEffectsOn = false;
			}

			//Move
			AccelerateDueToGravity();
			Move();
			if (velocity >= 0.0f) {
				if (distanceTravelled > highestDistanceTravelled) {
					highestDistanceTravelled = distanceTravelled;
				}
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

		UpdateCameraPosition();
	}

	private void CalculateGravity() {
		gravity = (gravitationalConstant * massOfEarth) / Mathf.Pow((radiusAtSeaLevel + distanceTravelled), 2.0f);
	}

	/// <summary>
	/// Makes the camera follow the rocket.
	/// </summary>
	private void UpdateCameraPosition() {
		Vector3 rocketPosition = gameObject.transform.position;
		cameraObject.transform.position = rocketPosition;
	}

	private void TurnOnRocketParticleEffects() {
		for (int i = 0; i < engineObjects.Length; i++) {
			engineObjects[i].GetComponent<EngineEffectScript>().ActivateThrusterEffects();
		}
	}

	private void TurnOffRocketParticleEffects() {
		for (int i = 0; i < engineObjects.Length; i++) {
			engineObjects[i].GetComponent<EngineEffectScript>().DeactivateThrusterEffects();
		}
	}

	#region Rocket Fuel Functions
	/// <summary>
	/// Resets the rocket Fuel To Max.
	/// </summary>
	private void ResetRocketFuel() {
		currentFuelLevel = maxFuelLevel;
	}

	/// <summary>
	/// Calculates the fuel consumption rate based on the power and number of thrusters.
	/// </summary>
	private void CalculateFuelConsumptionRate() {
		float thrusterConsumption = 1774.890981f;
		rocketFuelConsumption = thrusterConsumption * numberOfThrusters;
	}

	private void CalculateFuelConsumed() {
		currentFuelLevel -= rocketFuelConsumption * Time.deltaTime;
		if (currentFuelLevel <= 0.0f) {
			currentFuelLevel = 0.0f;
		}
	}

	private bool CheckIfRocketHasFuel() {
		return currentFuelLevel > 0.0f;
	}
	#endregion

	#region Rocket Movement Functions
	private void AccelerateDueToGravity() {
		velocity -= gravity * Time.deltaTime;
	}
	private void AccelerateDueToThrusters() {
		velocity += (rocketThrust / totalMass) * Time.deltaTime;
	}

	private void Move() {
		Vector3 position = gameObject.transform.position;
		position.y += velocity * Time.deltaTime;
		distanceTravelled += velocity * Time.deltaTime;
		gameObject.transform.position = position;
	}
	#endregion

	#region End Game Functions

	#endregion

	#endregion

	#region Public Access Functions (Getters and Setters)
	public void SetLaunchToTrue() {
		launched = true;
	}

	public bool GetHasLaunched() {
		return launched;
	}

	public float GetFuelLevel() {
		return currentFuelLevel;
	}

	public float GetDistanceTravelled() {
		return distanceTravelled;
	}

	public float GetCurrentVelocity() {
		return velocity;
	}

	public float GetHighestDistance() {
		return highestDistanceTravelled;
	}
	#endregion
}
