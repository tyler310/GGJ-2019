using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public int scoreAmount;
	public int scoreMultiplier;
	private Text scoreText;
	
	// Use this for initialization
	void Start () {
		scoreAmount = 0;
		scoreMultiplier = 1;
		scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = scoreAmount.ToString();
		// increase scoreAmount by (1 * scoreMultiplier) everytime a Steamer lands successfully
		//OnTriggerEnter2D();
	}
}
