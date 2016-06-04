using UnityEngine;
using System.Collections;

public class CrushReset : MonoBehaviour {
	//Put this scrpit on the actual platform that is falling
	private Vector3 tr;
	// Use this for initialization
	void Start () {
		tr = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPosition(){
		transform.position = tr;
	}
}

