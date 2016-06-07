using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public float time = 180;
	public float startingHealth = 10;
	public float currentHealth;
	public float bulletDamage = 1;
	public float boostedBulletDamage = 2;
	public GameObject win;
	public GameObject underlingPrefab;
	public GameObject enemySpawn1;
	public GameObject enemySpawn2;
	public GameObject enemySpawn3;
	public GameObject enemySpawn4;
	public GameObject enemySpawn5;

	public GameObject bulletPrefab;
	public GameObject shotSpawn;
	public float bulletImpulse;
	public float shootingInterval = 2;
	public float shootingTime;

	int isOneSeventySeven = 0;
	int isSeventyFive = 0;
	int thirdSpawn = 0;
	int canHit = 1;
	public int enemyCount = 0;
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		shootingTime = time - shootingInterval;
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(Mathf.Round(time) == 177 && isOneSeventySeven == 0)
		{
			isOneSeventySeven = 1;
			GameObject enemy = (GameObject)Instantiate(underlingPrefab, enemySpawn1.transform.position, enemySpawn1.transform.rotation);
			GameObject enemy2 = (GameObject)Instantiate(underlingPrefab, enemySpawn2.transform.position, enemySpawn2.transform.rotation);
			GameObject enemy3 = (GameObject)Instantiate(underlingPrefab, enemySpawn3.transform.position, enemySpawn3.transform.rotation);
			GameObject enemy4 = (GameObject)Instantiate(underlingPrefab, enemySpawn4.transform.position, enemySpawn4.transform.rotation);
			GameObject enemy5 = (GameObject)Instantiate(underlingPrefab, enemySpawn5.transform.position, enemySpawn5.transform.rotation);
		}
		if(Mathf.Round(time) == 120 && isSeventyFive == 0)
		{
			isSeventyFive = 1;
			GameObject enemy = (GameObject)Instantiate(underlingPrefab, enemySpawn1.transform.position, enemySpawn1.transform.rotation);
			GameObject enemy2 = (GameObject)Instantiate(underlingPrefab, enemySpawn2.transform.position, enemySpawn2.transform.rotation);
			GameObject enemy3 = (GameObject)Instantiate(underlingPrefab, enemySpawn3.transform.position, enemySpawn3.transform.rotation);
			GameObject enemy4 = (GameObject)Instantiate(underlingPrefab, enemySpawn4.transform.position, enemySpawn4.transform.rotation);
			GameObject enemy5 = (GameObject)Instantiate(underlingPrefab, enemySpawn5.transform.position, enemySpawn5.transform.rotation);
		}
		if(Mathf.Round(time) == 60 && thirdSpawn == 0)
		{
			isSeventyFive = 1;
			GameObject enemy = (GameObject)Instantiate(underlingPrefab, enemySpawn1.transform.position, enemySpawn1.transform.rotation);
			GameObject enemy2 = (GameObject)Instantiate(underlingPrefab, enemySpawn2.transform.position, enemySpawn2.transform.rotation);
			GameObject enemy3 = (GameObject)Instantiate(underlingPrefab, enemySpawn3.transform.position, enemySpawn3.transform.rotation);
			GameObject enemy4 = (GameObject)Instantiate(underlingPrefab, enemySpawn4.transform.position, enemySpawn4.transform.rotation);
			GameObject enemy5 = (GameObject)Instantiate(underlingPrefab, enemySpawn5.transform.position, enemySpawn5.transform.rotation);
		}
		if(enemyCount <= 0)
		{
			canHit = 1;
		}
		else
		{
			canHit = 0;
		}
		if (Mathf.Round(time) == Mathf.Round(shootingTime)) {
			GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
			theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
			shootingTime = time - shootingInterval;
		}

		if (currentHealth <= 0) {
			Destroy (gameObject);
			win.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		switch(collision.gameObject.tag)
		{
		case "Projectile":
			if (canHit == 1) {
				currentHealth -= bulletDamage;
			}
			break;
		case "BoostProjectile":
			if (canHit == 1) 
			{
				currentHealth -= boostedBulletDamage;
			}
			break;
		}
	}
}
