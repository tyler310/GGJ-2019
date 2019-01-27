using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour {
	private Button restartButton;

	// Use this for initialization
	void Start () {
		restartButton = GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		//when GameOver, 
		restartButton.onClick.AddListener(PlayAgain);
	}
	public void PlayAgain() {
		//TODO: Load a new game
	}

}
