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

	//if the number of moves per round ends up changing, you will need to edit these arrays below (a1,a2)
	Object[] a1 = new Object[5];
	Object[] a2 = new Object[5];
	// Use this for initialization
	void Start () {
		InvokeRepeating ("judge", 7f, 7f);
		InvokeRepeating ("timer", 0f, 1f);
		//Object test1 = Object.Instantiate (instant,test.transform.position,Quaternion.identity);
		//Object.Destroy (test1);
	}
	
	// Update is called once per frame
	void Update () {
		p1Health.text = "Health:"+player1.health;
		p2Health.text = "Health:"+player2.health;
		print ("reached");
	}
	void judge(){


		for (int i=0; i<player1.moves.Length; i++) {
			Object.Destroy(a1[i]);
			Object.Destroy(a2[i]);
		}	

		for (int i=0; i<player1.moves.Length; i++) {
			if(player1.moves[i]==playerController.weapons.rock){
				a1[i] = Object.Instantiate(rockImg,p1moves[i].transform.position,Quaternion.identity);
			}else if(player1.moves[i]==playerController.weapons.paper){
				a1[i] = Object.Instantiate(paperImg,p1moves[i].transform.position,Quaternion.identity);
			}else if(player1.moves[i]==playerController.weapons.scissors){
				a1[i] = Object.Instantiate(scissImg,p1moves[i].transform.position,Quaternion.identity);
			}

			if(player2.moves[i]==playerController.weapons.rock){
				a2[i] = Object.Instantiate(rockImg,p2moves[i].transform.position,Quaternion.identity);
			}else if(player2.moves[i]==playerController.weapons.paper){
				a2[i] = Object.Instantiate(paperImg,p2moves[i].transform.position,Quaternion.identity);
			}else if(player2.moves[i]==playerController.weapons.scissors){
				a2[i] = Object.Instantiate(scissImg,p2moves[i].transform.position,Quaternion.identity);
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

		float a = Time.time % 7;
		uiTimer.text = a.ToString();

	}
}
