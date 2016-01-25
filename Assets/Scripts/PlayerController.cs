using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public Text countText;
	public Text winText;

	private Rigidbody player;
	private int collectionCount;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
		collectionCount = 0;
		winText.text = "";
		UpdateDisplayCount ();
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
			++collectionCount;
			UpdateDisplayCount ();
		}
	}

	void UpdateDisplayCount () {
		countText.text = "Count: " + collectionCount.ToString ();
		if (collectionCount >= 12) {
			winText.text = "You Win!";
		}
	}
}
