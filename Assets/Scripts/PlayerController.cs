using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody player;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		float xMove = Input.GetAxis ("Horizontal");
		float zMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (xMove, 0.0f, zMove);

		player.AddForce (movement * moveSpeed);
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.CompareTag("Collectable")){
			other.gameObject.SetActive (false);
		}
	}
}
