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
	public GameObject Boss;

	int isShield = 0;
	float shieldBreak;
	int isGunBoost = 0;
	float gunBoostEnd;
	int isPlatform;

	public GameObject bulletPrefab;
	public GameObject boostedBulletPrefab;
	public GameObject shotSpawn;
	public float bulletImpulse;

	public GameObject level1Start;
	public GameObject level2Start;
	public GameObject level3Start;
	public GameObject level4Start;
	public GameObject level5Start;
	public GameObject level6Start;
	public GameObject level1End;
	public GameObject level2End;
	public GameObject level3End;
	public GameObject level4End;
	public GameObject level5End;
	public GameObject level6End;
	public GameObject level1Hub;
	public GameObject level2Hub;
	public GameObject level3Hub;
	public GameObject level4Hub;
	public GameObject level5Hub;
	public GameObject level6Hub;
	public GameObject hub;

	int inHub = ;

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
		if(time == gunBoostEnd && isGunBoost == 1)
		{
			isGunBoost = 0;
		}
		if(time == shieldBreak && isShield == 1)
		{
			isShield = 0;
		}
		if (Input.GetButtonDown ("Fire1"))
		{
			if(isGunBoost == 0)
			{
				GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
				theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
			}
			if(isGunBoost == 1)
			{
				GameObject theBullet = (GameObject)Instantiate(boostedBulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
				theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
			}
		}
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

		case "BossTrigger":
			Boss.gameObject.SetActive(true);
			break;
		}

		if (other.gameObject == level1Hub) 
		{
			transform.position = level1Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level2Hub) 
		{
			transform.position = level2Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level3Hub) 
		{
			transform.position = level3Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level4Hub) 
		{
			transform.position = level4Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level5Hub) 
		{
			transform.position = level5Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level6Hub) 
		{
			transform.position = level6Start.transform.position;
			time = 100;
		}
		if (other.gameObject == level1End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
		if (other.gameObject == level2End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
		if (other.gameObject == level3End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
		if (other.gameObject == level4End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
		if (other.gameObject == level5End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
		if (other.gameObject == level6End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
		}
	}
}
