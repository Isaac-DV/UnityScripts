using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public float time = 180;
	public float startingHealth = 10;
	public float currentHealth;
	public float bulletDamage = 1;
	public float boostedBulletDamage = 2;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;
	public GameObject enemy7;
	public GameObject enemy8;
	public GameObject enemy9;
	public GameObject enemy10;
	public GameObject enemy11;
	public GameObject enemy12;
	public GameObject enemy13;
	public GameObject enemy14;
	public GameObject enemy15;
	public GameObject enemy16;
	public GameObject enemy17;
	public GameObject enemy18;
	public GameObject enemy19;
	public GameObject enemy20;
	public GameObject enemy21;
	public GameObject enemy22;
	public GameObject enemy23;
	public GameObject enemy24;
	public GameObject enemy25;
	public GameObject enemy26;
	public GameObject enemy27;
	public GameObject enemy28;
	public GameObject enemy29;
	public GameObject enemy30;
	public GameObject win;

	public GameObject bulletPrefab;
	public GameObject shotSpawn;
	public float bulletImpulse;
	public float shootingInterval;
	public float shootingTime;

	int isOneSeventySeven = 0;
	int isSeventyFive = 0;
	int thirdSpawn = 0;
	int canHit = 1;
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
			enemy1.gameObject.SetActive (true);
			enemy2.gameObject.SetActive (true);
			enemy3.gameObject.SetActive (true);
			enemy4.gameObject.SetActive (true);
			enemy5.gameObject.SetActive (true);
			enemy6.gameObject.SetActive (true);
			enemy7.gameObject.SetActive (true);
			enemy8.gameObject.SetActive (true);
			enemy9.gameObject.SetActive (true);
			enemy10.gameObject.SetActive (true);
		}
		if(Mathf.Round(time) == 120 && isSeventyFive == 0)
		{
			isSeventyFive = 1;
			enemy11.gameObject.SetActive (true);
			enemy12.gameObject.SetActive (true);
			enemy13.gameObject.SetActive (true);
			enemy14.gameObject.SetActive (true);
			enemy15.gameObject.SetActive (true);
			enemy16.gameObject.SetActive (true);
			enemy17.gameObject.SetActive (true);
			enemy18.gameObject.SetActive (true);
			enemy19.gameObject.SetActive (true);
			enemy20.gameObject.SetActive (true);
		}
		if(Mathf.Round(time) == 60 && thirdSpawn == 0)
		{
			isSeventyFive = 1;
			enemy21.gameObject.SetActive (true);
			enemy22.gameObject.SetActive (true);
			enemy23.gameObject.SetActive (true);
			enemy24.gameObject.SetActive (true);
			enemy25.gameObject.SetActive (true);
			enemy26.gameObject.SetActive (true);
			enemy27.gameObject.SetActive (true);
			enemy28.gameObject.SetActive (true);
			enemy29.gameObject.SetActive (true);
			enemy30.gameObject.SetActive (true);
		}

		if (!enemy1.activeSelf && !enemy2.activeSelf && !enemy3.activeSelf && !enemy4.activeSelf && !enemy5.activeSelf && !enemy6.activeSelf && !enemy7.activeSelf && !enemy8.activeSelf && !enemy9.activeSelf && !enemy10.activeSelf && !enemy11.activeSelf && !enemy12.activeSelf && !enemy13.activeSelf && !enemy14.activeSelf && !enemy15.activeSelf && !enemy16.activeSelf && !enemy17.activeSelf && !enemy18.activeSelf && !enemy19.activeSelf && !enemy20.activeSelf && !enemy21.activeSelf && !enemy22.activeSelf && !enemy23.activeSelf && !enemy24.activeSelf && !enemy25.activeSelf && !enemy26.activeSelf && !enemy27.activeSelf && !enemy28.activeSelf && !enemy29.activeSelf && !enemy30.activeSelf) {
			canHit = 1;
		} else 
		{
			canHit = 0;
		}
		if (time == shootingTime) {
			GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
			theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
		}
		if (time == shootingTime - 0.2) {
			GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
			theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
		}
		if (time == shootingTime - 0.4) {
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
