using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField] private GameObject go;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private float offsetValue;
	
	private Vector3 offset;
	void Awake()
	{
		offset = new Vector3(0, offsetValue, 0);	
	}
	
	void Update ()
	{
		Vector2 spawnPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
//		Vector2 spawnPos = Input.mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			GameObject block = Instantiate(go, spawnPos, Quaternion.identity);
		}
//		MoveCamera();
	}

	private void MoveCamera()
	{
		mainCamera.transform.position = mainCamera.transform.position + offset;
	}
}
