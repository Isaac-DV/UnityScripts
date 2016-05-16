using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	//Public variables
	public GameObject bulletPrefab;
	public GameObject shotSpawn;
	public float bulletImpulse;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			GameObject theBullet = (GameObject)Instantiate(bulletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
			theBullet.GetComponent<Rigidbody>().AddForce (shotSpawn.transform.forward * bulletImpulse, ForceMode.Impulse);
		}
	}
}
