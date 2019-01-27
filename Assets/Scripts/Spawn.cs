using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject dumpling;
	public GameObject spawnPoint;
	public Canvas canvas;
	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		// spawn top steamer for the first time
		Vector2 point = spawnPoint.transform.position;
		Instantiate(dumpling, point, transform.rotation, canvas.transform);
		
		// initialize scoreKeeper

	}

	// Spawn steamer when the previous steamer hits another steamer, increase scoreAmount 
/* 	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "TopSteamer" || coll.gameObject.name == "BottomBorder") {
 			Vector2 point = spawnPoint.transform.position;
			Instantiate(dumpling, point, transform.rotation, canvas.transform); 
		}  
	} */


	// Update is called once per frame
	void Update () {
  		if (Input.GetMouseButtonDown(0)) {
			Vector2 point = spawnPoint.transform.position;
			Instantiate(dumpling, point, transform.rotation, canvas.transform);
		} 
	}
}
