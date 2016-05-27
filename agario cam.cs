using UnityEngine;
using System.Collections;
 
public class Eat : MonoBehaviour
{
    public string Tag;
    public float Increase;
    public Camera playerCam;
    float size;
    public float distance = 10;
 
    void Update(){
      size = transform.localScale.y;
      playerCam.transform.position.y = size + distance;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tag)
        {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);
        }
    }
}
