using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {
	public int speed = 1;
	[SerializeField]
	private int maxDistance = 1;
	private Vector2 startPosition;
	private Vector2 newPosition;
	private Rigidbody2D rb;
	private bool isFalling;

	// Use this for initialization
	void Start () {
		isFalling = false;
		startPosition = transform.position;
    	newPosition = transform.position;
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFalling){
			newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
			transform.position = newPosition;
		}
	}

	void OnMouseDown() {
		rb.gravityScale = 1;
		isFalling = true;
	}
}
