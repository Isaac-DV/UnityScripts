using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float min = 2f;
	public float max = 3f;
	public float distance = 25;
	public float speed = 10;
	public float time = 100;
	public float currentHealth;
	public float startingHealth = 2;
	public float bulletDamage = 1;
	public float boostedBulletDamage = 2;
	// Use this for initialization
	void Start () {
		min = transform.position.x;
		max = transform.position.x + distance;
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.PingPong (Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
		time -= Time.deltaTime;
		if (time <= 0) 
		{
			currentHealth = 0;
		}
		if(currentHealth <= 0)
		{
			destroyEnemy();
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Projectile")
		{
			currenthealth -= bulletDamage;
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "BoostProjectile")
		{
			currentHealth -= boostedBulletDamage;
			Destroy(collision.gameObject);
		}
	}
	void destroyEnemy()
	{
		Destroy(gameObject);
	}
}
