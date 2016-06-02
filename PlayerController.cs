using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {
	public float movementSpeed;
	public float verticalVelocity;
	public float jumpSpeed = 20.0f;
	public float platformJumpSpeed = 50.0f;
	public float startingHealth = 10.0f;
	public Text timer;
	float time;
	public float StartingTime = 100;
	public float timeUntilTele = -1;
	float currentHealth;
	public int pickupCount;
	public Text counter;
	public Text healthDisplay;
	public Text winLoseText;
	public Text lifeCountText;
	public Text messageText;
	public GameObject Boss;
	public int lifeCount = 3;
	bool teleToHub = false;
	
	public float shotSpawnMove;

	int isShield = 5000;
	float shieldBreak;
	int isGunBoost = 0;
	float gunBoostEnd;
	int isPlatform;
	int isNotDead = 1;
	bool facingRight = true;
	bool facingLeft = false;

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

	public int boss1UnlockPoints;
	public int boss2UnlockPoints;

	public GameObject player;
	CharacterController characterController;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		currentHealth = startingHealth;
		time = StartingTime;
		counter.text = "Points: 0";
		healthDisplay.text = "Health: " + startingHealth.ToString ();
		winLoseText.text = "";
		lifeCountText.text = "Lives: " + lifeCount.ToString ();
		messageText.text = "";
	}

	// Update is called once per frame
	void Update () {

		if (isNotDead == 1) {
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
			Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, 0);

			if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
				verticalVelocity = jumpSpeed;
			}

			if (isPlatform == 1) {
				verticalVelocity = platformJumpSpeed;
				isPlatform = 0;
			}
			characterController.Move (speed * Time.deltaTime);
		}

		time -= Time.deltaTime;
		timeUntilTele -=Time.deltaTime;
		timer.text = "Time: " + Mathf.Round(time);
		if(time <= gunBoostEnd && isGunBoost == 1)
		{
			isGunBoost = 0;
			messageText.text = "";
		}
		if(time <= shieldBreak && isShield == 1)
		{
			isShield = 0;
			messageText.text = "";
		}

		if(Input.GetKeyDown("d") && facingRight == false)
		{
			player.transform.Rotate (0, 0, 180);
			facingRight = true;
			facingLeft = false;
			shotSpawn.transform.Rotate(0, 180, 0);
			shotSpawn.tranform.Translate(shotSpawnMove, 0, 0);
		}
		if(Input.GetKeyDown("a") && facingLeft == false)
		{
			player.transform.Rotate (0, 0, 180);
			facingLeft = true;
			facingRight = false;
			shotSpawn.transform.Rotate(0, 180, 0);
			shotSpawn.transform.Translate(-shotSpawnMove, 0, 0);
		}
		if (Input.GetButtonDown ("Fire1"))
		{
			if(isGunBoost == 0)
			{
				GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, bulletPrefab.transform.rotation);
				theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
			}
			if(isGunBoost == 1)
			{
				GameObject theBullet = (GameObject)Instantiate(boostedBulletPrefab, shotSpawn.transform.position, boostedBulletPrefab.transform.rotation);
				theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
			}
		}
		if (time <= 0) 
		{
			currentHealth = 0.0f;
		}

		if(Mathf.Round(timeUntilTele) == 0)
		{
			if(teleToHub == false)
			{
				teleToHub = true;
				transform.position = hub.transform.position;
				time = 5000;
				isNotDead = 1;
				currentHealth = startingHealth;
				healthDisplay.text = "Health: " + currentHealth.ToString ();
				player.gameObject.SetActive(true);
				lifeCount -= 1;
				currentHealth = startingHealth;
				lifeCountText.text = "Lives: " + lifeCount.ToString ();
				winLoseText.text = "";
			}
		}
		if (currentHealth <= 0) 
		{
			if (lifeCount > 1) {
				if (!(0.0f < Mathf.Round (timeUntilTele) && Mathf.Round (timeUntilTele) <= 3f)) {
					timeUntilTele = 3.499f;
					player.gameObject.SetActive (false);
					isNotDead = 0;
				}
				winLoseText.text = "You lost a life! Teleporting in " + Mathf.Round (timeUntilTele);
			} else {
				winLoseText.text = "Game Over! Restart to play again.";
				lifeCount = 0;
				isNotDead = 0;
				lifeCountText.text = "Lives: " + lifeCount.ToString();
			}
		}
		if(Mathf.Round(timeUntilTele) < 0)
		{
			teleToHub = false;
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

			} else {
				currentHealth -= 10;
				healthDisplay.text = "Health: " + currentHealth.ToString ();
			}
			break;

		case "Pit":
			currentHealth = 0.0f;
			break;

		case "Shield":
			other.gameObject.SetActive (false);
			isShield = 1;
			shieldBreak = time - 10;
			messageText.text = "Shield Powerup Collected!";
			break;

		case "GunBoost":
			other.gameObject.SetActive (false);
			isGunBoost = 1;
			gunBoostEnd = time - 10;
			messageText.text = "Gun Boost Powerup Collected!";
			break;

		case "Platform":
			isPlatform = 1;
			break;

		case "BossTrigger":
			Boss.gameObject.SetActive (true);
			time = 180;
			break;
		}

		if (other.gameObject == level1Hub) 
		{
			transform.position = level1Start.transform.position;
			time = StartingTime;
		}
		if (other.gameObject == level2Hub) 
		{
			transform.position = level2Start.transform.position;
			time = StartingTime;
		}
		if (other.gameObject == level3Hub) 
		{
			transform.position = level3Start.transform.position;
			time = StartingTime;
		}
		if (other.gameObject == level4Hub) 
		{
			transform.position = level4Start.transform.position;
			time = StartingTime;
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
			level2Hub.gameObject.SetActive(true);
			if(pickupCount >= boss1UnlockPoints)
			{
				level3Hub.gameObject.SetActive (true);
			}
			if(pickupCount >= boss2UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
		}
		if (other.gameObject == level2End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
			level3Hub.gameObject.SetActive(true);
			if(pickupCount >= boss1UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
			if(pickupCount >= boss2UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
		}
		if (other.gameObject == level3End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
			level4Hub.gameObject.SetActive(true);
			if(pickupCount >= boss2UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
		}
		if (other.gameObject == level4End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
			level5Hub.gameObject.SetActive(true);
			if(pickupCount >= boss2UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
		}
		if (other.gameObject == level5End) 
		{
			transform.position = hub.transform.position;
			time = 5000;
			level6Hub.gameObject.SetActive(true);
			if(pickupCount >= boss2UnlockPoints)
			{
				level3Hub.gameObject.SetActive(true);
			}
		}
		if (other.gameObject == level6End) 
		{
			transform.position = hub.transform.position;
			time = 5000;

		}
	}
}
