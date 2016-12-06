using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class match : MonoBehaviour {
	public playerController player1;
	public playerController player2;
	public Text uiTimer;
	public Text p1Health;
	public Text p2Health;
	public GameObject[] p1moves;
	public GameObject[] p2moves;
	public GameObject rockImg;
	public GameObject paperImg;
	public GameObject scissImg;
	public Slider p1healthSlider;
	public Image p1Fill;
	public Slider p2healthSlider;
	public Image p2Fill;
	//if the number of moves per round ends up changing, you will need to edit these arrays below (a1,a2)
	GameObject[] a1 = new GameObject[5];
	GameObject[] a2 = new GameObject[5];
	// Use this for initialization
	void Start () {
		InvokeRepeating ("judge", 3f, 3f);
		InvokeRepeating ("timer", 0f, 1f);
		//Object test1 = Object.Instantiate (instant,test.transform.position,Quaternion.identity);
		//Object.Destroy (test1);
		//TODO health bar!
		p1healthSlider.interactable = false;
		p1healthSlider.minValue = 0f;
		p1healthSlider.maxValue = 100f;

		p2healthSlider.interactable = false;
		p2healthSlider.minValue = 0f;
		p2healthSlider.maxValue = 100f;

	}
	
	// Update is called once per frame
	void Update () {
		p1Health.text = "Health:"+player1.health;
		p1healthSlider.value = (float)player1.health;
		if (p1healthSlider.value < (p1healthSlider.maxValue) / 3)
			p1Fill.color = Color.red;
		p2Health.text = "Health:"+player2.health;
		p2healthSlider.value = (float)player2.health;
		if (p2healthSlider.value < (p2healthSlider.maxValue) / 3)
			p2Fill.color = Color.red;

	}
	void judge(){


		for (int i=0; i<player1.moves.Length; i++) {
			GameObject.Destroy(a1[i]);
			GameObject.Destroy(a2[i]);
		}	

		for (int i=0; i<player1.moves.Length; i++) {
			if(player1.moves[i]==playerController.weapons.rock){
				a1[i] = (GameObject)GameObject.Instantiate(rockImg,p1moves[i].transform.position,Quaternion.identity);
			}else if(player1.moves[i]==playerController.weapons.paper){
				a1[i] = (GameObject)GameObject.Instantiate(paperImg,p1moves[i].transform.position,Quaternion.identity);
			}else if(player1.moves[i]==playerController.weapons.scissors){
				a1[i] = (GameObject)GameObject.Instantiate(scissImg,p1moves[i].transform.position,Quaternion.identity);
			}

			if(player2.moves[i]==playerController.weapons.rock){
				a2[i] = (GameObject)GameObject.Instantiate(rockImg,p2moves[i].transform.position,Quaternion.identity);
			}else if(player2.moves[i]==playerController.weapons.paper){
				a2[i] = (GameObject)GameObject.Instantiate(paperImg,p2moves[i].transform.position,Quaternion.identity);
			}else if(player2.moves[i]==playerController.weapons.scissors){
				a2[i] = (GameObject)GameObject.Instantiate(scissImg,p2moves[i].transform.position,Quaternion.identity);
			}
		}

		for (int i=0; i<player1.moves.Length; i++) {
			//handle if player didnt input anything
			if(player1.moves[i] == playerController.weapons.none){

			}
			if(player2.moves[i] == playerController.weapons.none){

			}
			//end handle input error

			if (player1.moves [i] == playerController.weapons.rock && player2.moves[i] == playerController.weapons.scissors) {
				player1.score+=1;
				//TODO rather than try to change the alpha of the losing choice, add a new image of the losing choice
				//destroy the old, instantiate the new and have the proper index of the array point to the newly instantiated one
				Color tmp = a2[i].renderer.material.color;
				tmp.a= 0.5f;
			}else if (player1.moves [i] == playerController.weapons.paper && player2.moves [i] == playerController.weapons.scissors) {
				player2.score+=1;
			}else if (player1.moves [i] == playerController.weapons.rock && player2.moves [i] == playerController.weapons.paper) {
				player2.score+=1;
			}else if (player1.moves [i] == playerController.weapons.paper && player2.moves [i] == playerController.weapons.rock) {
				player1.score+=1;
			}else if (player1.moves [i] == playerController.weapons.scissors && player2.moves [i] == playerController.weapons.paper) {
				player1.score+=1;
			}else if (player1.moves [i] == playerController.weapons.scissors && player2.moves [i] == playerController.weapons.rock) {
				player2.score+=1;
			}
		}
		for (int i=0; i<player1.moves.Length; i++) {
			player1.moves[i]=playerController.weapons.none;
			player2.moves[i]=playerController.weapons.none;
		}
		player1.curPosInMoves = 0;
		player2.curPosInMoves = 0;
		//Array based combat end
		if (player1.score > player2.score) {
			player2.health-= (player1.score-player2.score);
		}

		if (player2.score > player1.score) {
			player1.health-=(player2.score-player1.score);
		}
		print ("Player 1: " + player1.score + "/ Player 2: " + player2.score);
		player1.score = 0;
		player2.score = 0;
	}
	void timer(){

		float a = (Time.time % 3) + 1;
		uiTimer.text = a.ToString();

	}
}
