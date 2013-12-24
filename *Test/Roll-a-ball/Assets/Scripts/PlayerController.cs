using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	
	void Start() {
		setCountText(count = 0);
		winText.text = "";
	}
		
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			setCountText(count);
		}
	}
	
	void setCountText(int count) {
		countText.text = "Count: " + count;
		if (count >= 4) {
			winText.text = "Winner!";
			this.gameObject.SetActive(false);
		}
	}

}