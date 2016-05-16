using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public GameObject startingPoint1;
	public GameObject telePoint1;
	public GameObject startingPoint2;
	public GameObject telePoint2;
	public GameObject startingPoint3;
	public GameObject telePoint3;
	public GameObject startingPoint4;
	public GameObject telePoint4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		// Determine if a collision between Player and Pick Up object has occured
		if (other.gameObject == startingPoint1)
		{
			transform.position = telePoint1.transform.position;
		}
		if (other.gameObject == startingPoint2) 
		{
			transform.position = telePoint2.transform.position;
		}
		if (other.gameObject == startingPoint3) 
		{
			transform.position = telePoint3.transform.position;
		}
	}
}
