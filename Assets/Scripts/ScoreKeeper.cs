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
		scoreText = GetComponent<Text>();
		scoreAmount = 0;
		scoreMultiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = scoreAmount.ToString();
	}

	public void UpdateScore(){
		// increase scoreAmount by 1 everytime a Steamer lands successfully
		// polish: increase scoreAmount by (1 * scoreMultiplier)  
		scoreAmount++;
	}
}
