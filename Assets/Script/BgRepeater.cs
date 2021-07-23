using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRepeater : MonoBehaviour {
	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private float width;
	private float speed = -3f;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		width = boxCollider.size.x;
		rigidBody.velocity = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -width) {
			onBgRepeater ();
		}
	}

	private void onBgRepeater() {
		Vector2 vector = new Vector2 (width * 2, 0);
		transform.position = (Vector2)transform.position + vector;
	}
}
