using UnityEngine;
using System.Collections;

public class CrushingPlatform : MonoBehaviour {
  //Put this script on the object(plane) that the player
  //steps on to activate the crushing platform, not on the crushing platform itself.
  public float speed;
  public GameObject crushingPlatform;
  bool isFalling = 0;
  private float pos;
  
  void Start(){
    pos = transform.position.y;
  }
  void Update(){
    if(isFalling == 1)
    {
      crushingPlatform.transform.Translate(0, -time.DeltaTime*speed, 0);
    }
  }
  void OnTriggerEnter(Collider other)
  {
    switch(other.gameObject.tag)
    {
      case "Player":
      isFalling = 1;
      break;
      case "Crush":
      isFalling = 0;
      break;
    }
  }
  void ResetPosition()
  {
		transform.position.y = pos;
  }
}
