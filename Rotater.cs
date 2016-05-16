using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour 
{
	// Declare variables to make script have multiple applications
	public int xRotation;
	public int yRotation;
	public int zRotation;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (xRotation, yRotation, zRotation) * Time.deltaTime);
	}
}
