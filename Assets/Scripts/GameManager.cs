﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] 
	private DummySteamer steamer;
	[SerializeField]
	private Camera mainCamera;
	[SerializeField]
	private float offsetValue;
	[SerializeField]
	private GameObject spawnPoint;

	public float maxDistance;
	public float speed;
	
	private Vector3 offset;
	private Vector2 startPosition;
	private Vector2 newPosition;
	private DummySteamer steamerDropped;
	private ScoreKeeper scoreKeeper;


	
	void Awake()
	{
		startPosition = spawnPoint.transform.position;
		newPosition = spawnPoint.transform.position;
		steamerDropped = Instantiate(steamer, startPosition, Quaternion.identity);
		steamerDropped.onSteamerDropCompleted += SpawnSteamer;
		
		offset = new Vector3(0, offsetValue, 0);	

		scoreKeeper = gameObject.AddComponent<ScoreKeeper>();
	}

	void FixedUpdate()
	{
		newPosition.x = (maxDistance * Mathf.Sin(Time.time * speed));
		spawnPoint.transform.position = new Vector2(newPosition.x, spawnPoint.transform.position.y);
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			steamerDropped.Drop();
//			DummySteamer steamerInstance = Instantiate(steamer, startPosition, Quaternion.identity);
//			steamerInstance.Drop();
		}

		if (steamerDropped.collisionComplete)
		{
			scoreKeeper.UpdateScore();
		}

		if (Input.GetKeyDown(KeyCode.R)){
			Debug.Log("Lorde was here");
			Scene currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}
	}

	private void SpawnSteamer()
	{
		steamerDropped.onSteamerDropCompleted -= SpawnSteamer;
		steamerDropped = Instantiate(steamer, spawnPoint.transform.position, Quaternion.identity);
		steamerDropped.onSteamerDropCompleted += SpawnSteamer;
	}
}
