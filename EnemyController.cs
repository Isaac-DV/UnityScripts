using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float min = 2f;
	public float max = 3f;
	public float distance = 25;
	public float speed = 10;
	public float time = 100;
	// Use this for initialization
	void Start () {
		min = transform.position.x;
		max = transform.position.x + distance;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.PingPong (Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
		time -= Time.deltaTime;
		if (time <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
