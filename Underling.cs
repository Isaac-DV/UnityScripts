using UnityEngine;
using System.Collections;

public class Underling : MonoBehaviour {
  float min = 2f;
	float max = 3f;
  float distance = 25;
  public float time;
	public float speed = 10;
	public float currentHealth;
	public float startingHealth = 2;
	public float bulletDamage = 1;
	public float boostedBulletDamage = 2;
	private BossController script;
	// Use this for initialization
	void Start () {
		min = transform.position.x;
		max = transform.position.x + distance;
		currentHealth = startingHealth;
		script = GameObject.Find("BossDragon").GetComponent<BossController>();
		script.enemyCount ++;
		time = script.time;
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
		script.enemyCount -= 1;
	}
}
