using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController1 : MonoBehaviour 
{
	// Declare variables
	private Rigidbody rb;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	// Start is called once during execution
	void Start()
	{
		// Get the Rigidbody component from the Player game object 
		// And set count to zero, and countText string
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// FixedUpdate is called before physics calculations
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// Determine if a collision between Player and Pick Up object has occured
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
		{
			winText.text = "You Win!!";
		}
	}
}



















