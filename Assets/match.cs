using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class match : MonoBehaviour {
	public playerController player1;
	public playerController player2;
	public Text uiTimer;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("judge", 1f, 7f);
		InvokeRepeating ("timer", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {

	}
	void judge(){
		/*if (player1.curChoice == playerController.weapons.rock && player2.curChoice == playerController.weapons.scissors) {
			player1.score+=1;
		}else if (player1.curChoice == playerController.weapons.paper && player2.curChoice == playerController.weapons.scissors) {
			player2.score+=1;
		}else if (player1.curChoice == playerController.weapons.rock && player2.curChoice == playerController.weapons.paper) {
			player2.score+=1;
		}else if (player1.curChoice == playerController.weapons.paper && player2.curChoice == playerController.weapons.rock) {
			player1.score+=1;
		}else if (player1.curChoice == playerController.weapons.scissors && player2.curChoice == playerController.weapons.paper) {
			player1.score+=1;
		}else if (player1.curChoice == playerController.weapons.scissors && player2.curChoice == playerController.weapons.rock) {
			player2.score+=1;
		}*/
		//Array based combat
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
		print ("Player 1: " + player1.score + "/ Player 2: " + player2.score);
	}
	void timer(){

		float a = Time.time % 7;
		uiTimer.text = a.ToString();
	}
}
