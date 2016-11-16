using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public int playerNumber;
	public int score;

	//11/15//
	public weapons[] moves = new weapons[5];
	public int curPosInMoves;

	//11/15//
	public enum weapons	
	{
		rock,
		paper,
		scissors,
		none
	}

	public weapons curChoice;


	// Use this for initialization
	void Start () {
		curPosInMoves = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNumber == 1) {
			if (Input.GetKeyDown ("a")) {
				curChoice=weapons.rock;
				addToMoves();

			} else if (Input.GetKeyDown ("s")) {
				curChoice=weapons.paper;
				addToMoves();
			} else if (Input.GetKeyDown ("d")) {
				curChoice=weapons.scissors;
				addToMoves();
			}
		} else if (playerNumber == 2) {
			if (Input.GetKeyDown("j")) {
				curChoice=weapons.rock;
				addToMoves();
			} else if (Input.GetKeyDown ("k")) {
				curChoice=weapons.paper;
				addToMoves();
			} else if (Input.GetKeyDown ("l")) {
				curChoice=weapons.scissors;
				addToMoves();
			}

		}

	}
	void addToMoves(){
		if(curPosInMoves<5){
			moves[curPosInMoves]=curChoice;
			curPosInMoves++;
		}
	}
}
