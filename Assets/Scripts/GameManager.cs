using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] 
	private DummySteamer steamer;
	[SerializeField]
	private DummySteamer baseSteamer;
	[SerializeField] 
	private Windbox windbox;
	[SerializeField]
	private Camera mainCamera;
	[SerializeField]
	private float offsetValue;
	[SerializeField]
	private GameObject spawnPoint;

	public float maxDistance;
	public float speed;
	
	
	private Vector2 startPosition;
	private Vector2 newPosition;
	private DummySteamer steamerDropped;
	private DummySteamer previouslyQueued;

	private Queue stackedQueue = new Queue();
	
	void Awake()
	{
		startPosition = spawnPoint.transform.position;
		newPosition = spawnPoint.transform.position;
		steamerDropped = Instantiate(steamer, startPosition, Quaternion.identity);
		steamerDropped.onSteamerDropCompleted += SpawnSteamer;
		previouslyQueued = baseSteamer;
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
	}

	private void SpawnSteamer()
	{
		steamerDropped.onSteamerDropCompleted -= SpawnSteamer;

		AddToQueue(steamerDropped);
		
		steamerDropped = Instantiate(steamer, spawnPoint.transform.position, Quaternion.identity);
		steamerDropped.onSteamerDropCompleted += SpawnSteamer;
		steamerDropped.speed = speed;
	}

	private void AddToQueue(DummySteamer steamer)
	{
		if (stackedQueue.Count > 5)
		{
			DummySteamer dequeued = (DummySteamer) stackedQueue.Dequeue();
			dequeued.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		}
		stackedQueue.Enqueue(steamer);

		BoxCollider2D currentCollider = steamer.GetComponent<BoxCollider2D>();
		
		float prevMinColliderBound = previouslyQueued.GetComponent<BoxCollider2D>().bounds.min.x;
		float currMinColliderBound = currentCollider.bounds.min.x;
		
		Debug.Log("Prev bound: " + prevMinColliderBound);
		Debug.Log("Curr bound:" + currMinColliderBound);

		float tmp = prevMinColliderBound - currMinColliderBound;
		
		float distance = Mathf.Sqrt(tmp * tmp);
		
//		return Mathf.Sqrt((float) ((double) this.x * (double) this.x + (double) this.y * (double) this.y));
		
		if (distance <= 0.15f)
		{
			steamer.transform.position = new Vector2(previouslyQueued.transform.position.x, steamer.transform.position.y);
		}
		else if (distance <= 0.3f)
		{
			windbox.magnitude = windbox.magnitude * 1.1f;
		}
		else
		{
			windbox.magnitude = windbox.magnitude * 1.5f;
		}
		
		
		previouslyQueued = steamer;
		
		speed = Mathf.Clamp(speed * 1.1f, 0, 4);
	}
}
