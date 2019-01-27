using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject dumpling;
	public GameObject spawnPoint;
	public Canvas canvas;

	private float floor = 0;

	// Use this for initialization
	void Start () {
		Vector2 point = spawnPoint.transform.position;
		Instantiate(dumpling, point, transform.rotation, canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector2 point = spawnPoint.transform.position;
			Instantiate(dumpling, point, transform.rotation, canvas.transform);
		}
	}
}
