using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	Vector3 camPos1;
	Vector3 camPos2;
	bool isPos1 = true;
	bool isPos2 = false;
	public float distanceBetweenPos;

	void Start(){
		camPos1 = transform.position;
		camPos2 = (transform.position.x, transform.position.y, transform.position.z - distanceBetweenPos);
	}
	void Update(){
		if(Input.GetKeyDown("w") || Input.GetKeyDown("s"))
		{
			if(isPos1 == true)
			{
				transform.position = camPos2;
				isPos1 = false;
				isPos2 = true;
			}
			else if(isPos2 == true)
			{
				transform.position = camPos1;
				isPos2 = false;
				isPos1 = true;
			}
		}
	}


}
