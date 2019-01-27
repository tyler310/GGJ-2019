using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MaxHeightTrigger : MonoBehaviour
{
	public Camera mainCamera;
	public float offset;
	public float panTime;

	private bool isTriggered;

	void Awake()
	{
		isTriggered = false;
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Stack") && !isTriggered)
		{
			Debug.Log("Triggered");
			isTriggered = true;
			Vector3 panTo = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + offset, -1);
			mainCamera.transform.DOMove(panTo, panTime).SetEase(Ease.Linear).OnComplete(() => isTriggered = false);
		}
	}
}
