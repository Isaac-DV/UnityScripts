using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {
	public float movementSpeed;
	public float verticalVelocity;
	public float jumpSpeed = 20.0f;
	public float platformJumpSpeed = 50.0f;
	public float startingHealth;
	public Text timer;
	public float time = 100;
	float currentHealth;
	public int pickupCount;
	public Text counter;
	public Text healthDisplay;

	int isShield = 0;
	float shieldBreak;
	int isGunBoost = 0;
	float gunBoostEnd;
	int isPlatform;

	CharacterController characterController;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		currentHealth = startingHealth;
		counter.text = "Points: 0";
		healthDisplay.text = "Health: " + startingHealth.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, 0);

		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) 
		{
			verticalVelocity = jumpSpeed;
		}

		if (isPlatform == 1) 
		{
			verticalVelocity = platformJumpSpeed;
			isPlatform = 0;
		}

		characterController.Move (speed * Time.deltaTime);
		time -= Time.deltaTime;
		timer.text = "Time: " + Mathf.Round(time);
		if (time <= 0) 
		{
			currentHealth = 0.0f;
		}
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);

		}
	}
		
	void OnTriggerEnter(Collider other) 
	{
		// Determine if a collision between Player and Pick Up object has occured
		/*if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			pickupCount += 1;
			counter.text = "Points: " + pickupCount.ToString ();
		}
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			currentHealth -= 10;
		}
		if (other.gameObject.CompareTag ("Pit")) 
		{
			currentHealth = 0.0f;
		}*/
		switch (other.gameObject.tag) {
		case "Pickup":
			other.gameObject.SetActive(false);
			pickupCount += 1;
			counter.text = "Points: " + pickupCount.ToString ();
			break;

		case "Enemy":
			if (isShield == 1 && time > shieldBreak) {
				currentHealth -= 10;
			}
			break;

		case "Pit":
			currentHealth = 0.0f;
			break;

		case "Shield":
			other.gameObject.SetActive (false);
			isShield = 1;
			shieldBreak = time - 10;
			break;

		case "GunBoost":
			other.gameObject.SetActive (false);
			isGunBoost = 1;
			gunBoostEnd = time - 10;
			break;
		
		case "Platform":
			isPlatform = 1;
			break;
		}
	}
}
