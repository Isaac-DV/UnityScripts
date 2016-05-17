using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
public float time = 100;
public float startingHealth = 10;
public float currentHealth;
public float bulletDamage = 1;
public float boostedBulletDamage = 2;
int isNinety = 0;
int isSeventyFive = 0;
	// Use this for initialization
	void Start () {
	currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
	time -= Time.deltaTime;
	if(Mathf.Round(time) == 90 && isNinety == 0)
	{
		isNinety = 1;
	}
	if(Mathf.Round(time) == 75 && isSeventyFive == 0)
	{
		isSeventyFive == 1;
	}
	}
	
	void OnTriggerEnter(Collider collision)
	{
		switch(collision.gameObject.tag)
		{
			case "Projectile":
			currentHealth -= bulletDamage;
			break;
			case "BoostProjectile":
			currentHealth -= boostedBulletDamage;
			break;
		}
	}
}
