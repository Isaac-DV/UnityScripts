using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
  public float camPos1;
  public float camPos2;
  bool isPos1 = true;
  bool isPos2 = false;
  
  void Start(){
    transform.position = new Vector3(transform.position.x, camPos1, transform.position.z);
  }
  void Update(){
    if(Input.GetKeyDown("w") || Input.GetButtonDown("s"))
    {
      if(isPos1 == true)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, camPos2);
        isPos1 = false;
        isPos2 = true;
      }
      else if(isPos2 = true)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, camPos1);
        isPos2 = false;
        isPos1 = true;
      }
    }
  }
  
  
}
